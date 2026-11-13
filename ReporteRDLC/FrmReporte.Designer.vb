<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporte
    Inherits System.Windows.Forms.Form

    ' Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    ' Controles del formulario
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnConfigurar As System.Windows.Forms.Button
    Friend WithEvents btnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents lblCarrera As System.Windows.Forms.Label
    Friend WithEvents cboCarrera As System.Windows.Forms.ComboBox
    Friend WithEvents dgvAlumnos As System.Windows.Forms.DataGridView
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents chkHorizontal As System.Windows.Forms.CheckBox

    ' Componentes de impresión (bandeja de componentes)
    Friend WithEvents pdReporte As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdVista As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents psdPagina As System.Windows.Forms.PageSetupDialog
    Friend WithEvents dlgImprimir As System.Windows.Forms.PrintDialog

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.btnVistaPrevia = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.cboCarrera = New System.Windows.Forms.ComboBox()
        Me.dgvAlumnos = New System.Windows.Forms.DataGridView()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.chkHorizontal = New System.Windows.Forms.CheckBox()
        Me.pdReporte = New System.Drawing.Printing.PrintDocument()
        Me.ppdVista = New System.Windows.Forms.PrintPreviewDialog()
        Me.psdPagina = New System.Windows.Forms.PageSetupDialog()
        Me.dlgImprimir = New System.Windows.Forms.PrintDialog()
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        ' lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(20, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(268, 25)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Listado de alumnos – Impresión"
        '
        ' lblCarrera
        '
        Me.lblCarrera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Location = New System.Drawing.Point(596, 25)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Size = New System.Drawing.Size(49, 15)
        Me.lblCarrera.TabIndex = 1
        Me.lblCarrera.Text = "Carrera:"
        '
        ' cboCarrera
        '
        Me.cboCarrera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCarrera.FormattingEnabled = True
        Me.cboCarrera.Location = New System.Drawing.Point(651, 21)
        Me.cboCarrera.Name = "cboCarrera"
        Me.cboCarrera.Size = New System.Drawing.Size(229, 23)
        Me.cboCarrera.TabIndex = 2
        '
        ' btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(20, 56)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(150, 34)
        Me.btnCargar.TabIndex = 3
        Me.btnCargar.Text = "Cargar datos"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        ' btnConfigurar
        '
        Me.btnConfigurar.Enabled = False
        Me.btnConfigurar.Location = New System.Drawing.Point(180, 56)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(150, 34)
        Me.btnConfigurar.TabIndex = 4
        Me.btnConfigurar.Text = "Configurar página"
        Me.btnConfigurar.UseVisualStyleBackColor = True
        '
        ' btnVistaPrevia
        '
        Me.btnVistaPrevia.Enabled = False
        Me.btnVistaPrevia.Location = New System.Drawing.Point(340, 56)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(150, 34)
        Me.btnVistaPrevia.TabIndex = 5
        Me.btnVistaPrevia.Text = "Vista previa"
        Me.btnVistaPrevia.UseVisualStyleBackColor = True
        '
        ' btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Location = New System.Drawing.Point(500, 56)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(150, 34)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        ' dgvAlumnos
        '
        Me.dgvAlumnos.AllowUserToAddRows = False
        Me.dgvAlumnos.AllowUserToDeleteRows = False
        Me.dgvAlumnos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAlumnos.BackgroundColor = System.Drawing.Color.White
        Me.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumnos.Location = New System.Drawing.Point(20, 106)
        Me.dgvAlumnos.MultiSelect = False
        Me.dgvAlumnos.Name = "dgvAlumnos"
        Me.dgvAlumnos.ReadOnly = True
        Me.dgvAlumnos.RowHeadersVisible = False
        Me.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlumnos.Size = New System.Drawing.Size(860, 378)
        Me.dgvAlumnos.TabIndex = 7
        '
        ' lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(20, 504)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(111, 15)
        Me.lblEstado.TabIndex = 8
        Me.lblEstado.Text = "Sin datos cargados"
        '
        ' chkHorizontal
        '
        Me.chkHorizontal.AutoSize = True
        Me.chkHorizontal.Location = New System.Drawing.Point(660, 63)
        Me.chkHorizontal.Name = "chkHorizontal"
        Me.chkHorizontal.Size = New System.Drawing.Size(84, 19)
        Me.chkHorizontal.TabIndex = 9
        Me.chkHorizontal.Text = "Horizontal"
        Me.chkHorizontal.UseVisualStyleBackColor = True
        '
        ' pdReporte
        '
        Me.pdReporte.DocumentName = "Listado de alumnos"
        '
        ' ppdVista
        '
        Me.ppdVista.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdVista.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdVista.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdVista.Document = Me.pdReporte
        Me.ppdVista.Enabled = True
        Me.ppdVista.Name = "ppdVista"
        Me.ppdVista.Text = "Vista previa"
        Me.ppdVista.UseAntiAlias = True
        Me.ppdVista.Visible = False
        '
        ' psdPagina
        '
        Me.psdPagina.Document = Me.pdReporte
        Me.psdPagina.EnableMetric = True
        '
        ' dlgImprimir
        '
        Me.dlgImprimir.Document = Me.pdReporte
        Me.dlgImprimir.UseEXDialog = True
        '
        ' FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.Controls.Add(Me.chkHorizontal)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.dgvAlumnos)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnVistaPrevia)
        Me.Controls.Add(Me.btnConfigurar)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.cboCarrera)
        Me.Controls.Add(Me.lblCarrera)
        Me.Controls.Add(Me.lblTitulo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimumSize = New System.Drawing.Size(760, 480)
        Me.Name = "FrmReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de alumnos – PrintDocument"
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
