Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms
Imports MySqlConnector

Public Class FrmReporte

#Region "1. Variables del formulario"

    ' Datos que se mostrarán en la grilla y se imprimirán
    Private tablaAlumnos As New DataTable()

    ' Control de paginación: en qué fila vamos y qué página dibujamos
    Private filaActual As Integer = 0
    Private numeroPagina As Integer = 0

    ' Recursos de dibujo: se crean en BeginPrint y se liberan en EndPrint
    Private fuenteTitulo As Font
    Private fuenteEncabezado As Font
    Private fuenteDetalle As Font
    Private fuentePie As Font
    Private logo As Image

    ' Definición de columnas del reporte (campo, título y ancho relativo)
    Private ReadOnly columnas() As String = {"carnet", "nombres", "apellidos", "carrera", "promedio"}
    Private ReadOnly titulos() As String = {"Carnet", "Nombres", "Apellidos", "Carrera", "Promedio"}
    Private ReadOnly proporciones() As Single = {0.14F, 0.22F, 0.22F, 0.3F, 0.12F}   ' suman 1.0

    Private ReadOnly colorAzul As Color = Color.FromArgb(0, 58, 128)

#End Region

#Region "2. Carga de datos"

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Márgenes en centésimas de pulgada (60 = 0.6")
        pdReporte.DefaultPageSettings.Margins = New Margins(60, 60, 60, 80)
        HabilitarImpresion(False)
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim sql As String = "SELECT carnet, nombres, apellidos, carrera, promedio " &
                            "FROM alumnos ORDER BY apellidos, nombres"
        Try
            Using cn As MySqlConnection = ObtenerConexion()
                Using da As New MySqlDataAdapter(sql, cn)
                    tablaAlumnos = New DataTable()
                    da.Fill(tablaAlumnos)          ' el adaptador abre y cierra la conexión
                End Using
            End Using

            dgvAlumnos.DataSource = tablaAlumnos
            lblEstado.Text = "Registros cargados: " & tablaAlumnos.Rows.Count
            HabilitarImpresion(tablaAlumnos.Rows.Count > 0)

        Catch ex As MySqlException
            MessageBox.Show("Error al consultar MariaDB:" & vbCrLf & ex.Message,
                            "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HabilitarImpresion(valor As Boolean)
        btnConfigurar.Enabled = valor
        btnVistaPrevia.Enabled = valor
        btnImprimir.Enabled = valor
    End Sub

#End Region

#Region "3. Botones de impresión"

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs) Handles btnConfigurar.Click
        ' Modifica pdReporte.DefaultPageSettings (papel, orientación, márgenes)
        psdPagina.ShowDialog(Me)
    End Sub

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        ppdVista.WindowState = FormWindowState.Maximized
        ppdVista.ShowDialog(Me)          ' dispara BeginPrint → PrintPage… → EndPrint
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dlgImprimir.ShowDialog(Me) = DialogResult.OK Then
            Try
                pdReporte.Print()            ' vuelve a disparar BeginPrint → PrintPage… → EndPrint
                lblEstado.Text = "Documento enviado a: " & pdReporte.PrinterSettings.PrinterName
            Catch ex As InvalidPrinterException
                MessageBox.Show("Impresora no válida: " & ex.Message, "Impresión",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub

#End Region

#Region "4. Eventos del PrintDocument"

    ' Se ejecuta UNA vez, antes de la primera página
    Private Sub pdReporte_BeginPrint(sender As Object, e As PrintEventArgs) Handles pdReporte.BeginPrint
        filaActual = 0                   ' ¡clave! reinicia la paginación en cada impresión
        numeroPagina = 0

        fuenteTitulo = New Font("Segoe UI", 16, FontStyle.Bold)
        fuenteEncabezado = New Font("Segoe UI", 10, FontStyle.Bold)
        fuenteDetalle = New Font("Segoe UI", 10)
        fuentePie = New Font("Segoe UI", 8)

        Dim rutaLogo As String = Path.Combine(Application.StartupPath, "Recursos", "logo-uni.png")
        If File.Exists(rutaLogo) Then logo = Image.FromFile(rutaLogo)
    End Sub

    ' Se ejecuta UNA vez POR CADA página
    Private Sub pdReporte_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pdReporte.PrintPage
        Dim g As Graphics = e.Graphics
        Dim area As Rectangle = e.MarginBounds      ' zona útil dentro de los márgenes
        Dim y As Single = area.Top                  ' "cursor" vertical
        numeroPagina += 1

        Using fIzq As New StringFormat(), fDer As New StringFormat(), fCen As New StringFormat()
            ConfigurarFormato(fIzq, StringAlignment.Near)
            ConfigurarFormato(fDer, StringAlignment.Far)
            ConfigurarFormato(fCen, StringAlignment.Center)

            ' ---- a) Encabezado: logo + título + institución y fecha ----
            Const ALTO_ENCABEZADO As Single = 55
            If logo IsNot Nothing Then
                Dim anchoLogo As Single = logo.Width * ALTO_ENCABEZADO / logo.Height
                g.DrawImage(logo, area.Left, y, anchoLogo, ALTO_ENCABEZADO)
            End If
            g.DrawString("Listado de Alumnos", fuenteTitulo, Brushes.Black,
                         New RectangleF(area.Left, y, area.Width, 30), fCen)
            g.DrawString("Universidad Nacional de Ingeniería · " & Date.Now.ToString("dd/MM/yyyy"),
                         fuentePie, Brushes.DimGray,
                         New RectangleF(area.Left, y + 30, area.Width, 20), fCen)
            y += ALTO_ENCABEZADO + 10

            ' ---- b) Fila de títulos de columna ----
            Dim altoFila As Single = fuenteDetalle.GetHeight(g) + 8
            Using fondoTitulos As New SolidBrush(colorAzul)
                g.FillRectangle(fondoTitulos, area.Left, y, area.Width, altoFila)
            End Using
            DibujarFila(g, titulos, fuenteEncabezado, Brushes.White, area, y, altoFila, fIzq, fDer)
            y += altoFila

            ' ---- c) Filas de detalle: mientras haya datos Y quepan en la página ----
            Using fondoAlterno As New SolidBrush(Color.FromArgb(235, 240, 248))
                Do While filaActual < tablaAlumnos.Rows.Count AndAlso y + altoFila <= area.Bottom
                    Dim fila As DataRow = tablaAlumnos.Rows(filaActual)

                    If filaActual Mod 2 = 1 Then
                        g.FillRectangle(fondoAlterno, area.Left, y, area.Width, altoFila)
                    End If

                    Dim valores(columnas.Length - 1) As String
                    For i As Integer = 0 To columnas.Length - 1
                        valores(i) = fila(columnas(i)).ToString()
                    Next
                    DibujarFila(g, valores, fuenteDetalle, Brushes.Black, area, y, altoFila, fIzq, fDer)

                    y += altoFila
                    filaActual += 1
                Loop
            End Using
            g.DrawLine(Pens.Gray, area.Left, y, area.Right, y)

            ' ---- d) Pie de página (se dibuja dentro del margen inferior) ----
            Dim yPie As Single = area.Bottom + 10
            g.DrawLine(Pens.LightGray, area.Left, yPie, area.Right, yPie)
            Dim rectPie As New RectangleF(area.Left, yPie + 4, area.Width, 20)
            g.DrawString("Programación de Aplicaciones de Escritorio", fuentePie, Brushes.DimGray, rectPie, fIzq)
            g.DrawString("Página " & numeroPagina, fuentePie, Brushes.DimGray, rectPie, fDer)

            ' ---- e) ¿Quedan filas? → otra página ----
            e.HasMorePages = filaActual < tablaAlumnos.Rows.Count
            If Not e.HasMorePages Then
                g.DrawString("Total de alumnos: " & tablaAlumnos.Rows.Count,
                             fuentePie, Brushes.DimGray, rectPie, fCen)
            End If
        End Using
    End Sub

    ' Se ejecuta UNA vez, al terminar la última página
    Private Sub pdReporte_EndPrint(sender As Object, e As PrintEventArgs) Handles pdReporte.EndPrint
        fuenteTitulo?.Dispose()
        fuenteEncabezado?.Dispose()
        fuenteDetalle?.Dispose()
        fuentePie?.Dispose()
        logo?.Dispose()
        logo = Nothing
    End Sub

#End Region

#Region "5. Métodos auxiliares de dibujo"

    ' Dibuja una fila de celdas repartiendo el ancho según "proporciones"
    Private Sub DibujarFila(g As Graphics, textos() As String, fuente As Font, pincel As Brush,
                            area As Rectangle, y As Single, alto As Single,
                            fIzq As StringFormat, fDer As StringFormat)
        Dim x As Single = area.Left
        For i As Integer = 0 To textos.Length - 1
            Dim ancho As Single = area.Width * proporciones(i)
            Dim celda As New RectangleF(x + 4, y, ancho - 8, alto)
            ' La última columna (Promedio) es numérica: se alinea a la derecha
            Dim formato As StringFormat = If(i = textos.Length - 1, fDer, fIzq)
            g.DrawString(textos(i), fuente, pincel, celda, formato)
            x += ancho
        Next
    End Sub

    ' Alineación horizontal + centrado vertical + "…" si el texto no cabe
    Private Sub ConfigurarFormato(f As StringFormat, alineacion As StringAlignment)
        f.Alignment = alineacion
        f.LineAlignment = StringAlignment.Center
        f.Trimming = StringTrimming.EllipsisCharacter
        f.FormatFlags = StringFormatFlags.NoWrap
    End Sub

#End Region

End Class
