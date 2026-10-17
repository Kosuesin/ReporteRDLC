Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports MySqlConnector

Public Class FrmReporte

#Region "1. Visor y constantes"

    ' ReportViewer Core no aparece en el Cuadro de herramientas: se crea por código
    Private ReadOnly rvReporte As New ReportViewer()

    Private Const TODAS As String = "(Todas)"
    Private Const NOMBRE_DATASET As String = "DsAlumnos"   ' = <DataSet Name> del .rdlc

    Private ReadOnly rutaRdlc As String =
        Path.Combine(Application.StartupPath, "Reportes", "RptAlumnos.rdlc")

#End Region

#Region "2. Inicio del formulario"

    Private Sub FrmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' a) Ubicar el visor debajo del panel de filtros
        rvReporte.Dock = DockStyle.Fill
        rvReporte.ShowParameterPrompts = False      ' el parámetro lo envía el código
        Controls.Add(rvReporte)
        rvReporte.BringToFront()                    ' Fill ocupa solo el espacio libre

        ' b) Cargar la definición del reporte (una sola vez)
        If Not File.Exists(rutaRdlc) Then
            MessageBox.Show("No se encontró el reporte:" & vbCrLf & rutaRdlc,
                            "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnGenerar.Enabled = False
            Return
        End If
        Using fs As New FileStream(rutaRdlc, FileMode.Open, FileAccess.Read)
            rvReporte.LocalReport.LoadReportDefinition(fs)
        End Using
        rvReporte.LocalReport.DisplayName = "Listado de alumnos"   ' nombre al exportar

        ' c) Llenar el filtro de carreras
        CargarCarreras()
    End Sub

#End Region

#Region "3. Acceso a datos"

    Private Sub CargarCarreras()
        cboCarrera.Items.Clear()
        cboCarrera.Items.Add(TODAS)
        Try
            Using cn As MySqlConnection = ObtenerConexion(),
                  cmd As New MySqlCommand("SELECT DISTINCT carrera FROM alumnos ORDER BY carrera", cn)
                cn.Open()
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        cboCarrera.Items.Add(dr.GetString(0))
                    End While
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show("Error al consultar MariaDB:" & vbCrLf & ex.Message,
                            "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboCarrera.SelectedIndex = 0
    End Sub

    ' Devuelve los alumnos de una carrera, o de todas
    Private Function ObtenerAlumnos(carrera As String) As DataTable
        Dim filtrar As Boolean = (carrera <> TODAS)
        Dim sql As String = "SELECT carnet, nombres, apellidos, carrera, promedio FROM alumnos"
        If filtrar Then sql &= " WHERE carrera = @carrera"
        sql &= " ORDER BY carrera, apellidos, nombres"

        Dim tabla As New DataTable()
        Using cn As MySqlConnection = ObtenerConexion(),
              da As New MySqlDataAdapter(sql, cn)
            If filtrar Then da.SelectCommand.Parameters.AddWithValue("@carrera", carrera)
            da.Fill(tabla)                       ' el adaptador abre y cierra la conexión
        End Using
        Return tabla
    End Function

#End Region

#Region "4. Generar el reporte"

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim carrera As String = cboCarrera.Text
        Dim tabla As DataTable

        Try
            tabla = ObtenerAlumnos(carrera)
        Catch ex As MySqlException
            MessageBox.Show("Error al consultar MariaDB:" & vbCrLf & ex.Message,
                            "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' a) Datos: el nombre debe coincidir EXACTAMENTE con el DataSet del .rdlc
        rvReporte.LocalReport.DataSources.Clear()
        rvReporte.LocalReport.DataSources.Add(New ReportDataSource(NOMBRE_DATASET, tabla))

        ' b) Parámetro: se muestra en el encabezado del reporte
        rvReporte.LocalReport.SetParameters(New ReportParameter("pCarrera", carrera))

        ' c) Mostrar como se verá impreso y procesar
        rvReporte.SetDisplayMode(DisplayMode.PrintLayout)
        rvReporte.ZoomMode = ZoomMode.PageWidth
        rvReporte.RefreshReport()

        btnGuardarPdf.Enabled = True
    End Sub

#End Region

#Region "5. Exportar a PDF por código"

    ' Además de la barra del visor, el reporte puede exportarse sin abrir menús
    Private Sub btnGuardarPdf_Click(sender As Object, e As EventArgs) Handles btnGuardarPdf.Click
        Using dlg As New SaveFileDialog() With {
                .Filter = "Documento PDF (*.pdf)|*.pdf",
                .FileName = "Listado de alumnos.pdf"}

            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return

            Try
                ' Formatos válidos: "PDF", "EXCELOPENXML", "WORDOPENXML", "IMAGE"...
                Dim bytes As Byte() = rvReporte.LocalReport.Render("PDF")
                File.WriteAllBytes(dlg.FileName, bytes)
                MessageBox.Show("Archivo guardado:" & vbCrLf & dlg.FileName,
                                "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("No se pudo exportar:" & vbCrLf & ex.Message,
                                "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

#End Region

End Class
