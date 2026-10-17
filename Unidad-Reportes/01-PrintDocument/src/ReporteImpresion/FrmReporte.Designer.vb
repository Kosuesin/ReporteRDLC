<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento.
    'Se puede modificar usando el Diseñador; no lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.btnVistaPrevia = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dgvAlumnos = New System.Windows.Forms.DataGridView()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.pdReporte = New System.Drawing.Printing.PrintDocument()
        Me.ppdVista = New System.Windows.Forms.PrintPreviewDialog()
        Me.psdPagina = New System.Windows.Forms.PageSetupDialog()
        Me.dlgImprimir = New System.Windows.Forms.PrintDialog()
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.Location = New System.Drawing.Point(16, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Text = "Listado de alumnos – Impresión"
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(16, 52)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(150, 34)
        Me.btnCargar.TabIndex = 0
        Me.btnCargar.Text = "Cargar datos"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'btnConfigurar
        '
        Me.btnConfigurar.Location = New System.Drawing.Point(176, 52)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(150, 34)
        Me.btnConfigurar.TabIndex = 1
        Me.btnConfigurar.Text = "Configurar página"
        Me.btnConfigurar.UseVisualStyleBackColor = True
        '
        'btnVistaPrevia
        '
        Me.btnVistaPrevia.Location = New System.Drawing.Point(336, 52)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(150, 34)
        Me.btnVistaPrevia.TabIndex = 2
        Me.btnVistaPrevia.Text = "Vista previa"
        Me.btnVistaPrevia.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(496, 52)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(150, 34)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dgvAlumnos
        '
        Me.dgvAlumnos.AllowUserToAddRows = False
        Me.dgvAlumnos.AllowUserToDeleteRows = False
        Me.dgvAlumnos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumnos.Location = New System.Drawing.Point(16, 96)
        Me.dgvAlumnos.Name = "dgvAlumnos"
        Me.dgvAlumnos.ReadOnly = True
        Me.dgvAlumnos.RowHeadersVisible = False
        Me.dgvAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlumnos.Size = New System.Drawing.Size(868, 420)
        Me.dgvAlumnos.TabIndex = 4
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(16, 528)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Text = "Sin datos cargados"
        '
        'pdReporte
        '
        Me.pdReporte.DocumentName = "Listado de alumnos"
        '
        'ppdVista
        '
        Me.ppdVista.Document = Me.pdReporte
        Me.ppdVista.Name = "ppdVista"
        Me.ppdVista.UseAntiAlias = True
        '
        'psdPagina
        '
        Me.psdPagina.Document = Me.pdReporte
        Me.psdPagina.EnableMetric = True
        '
        'dlgImprimir
        '
        Me.dlgImprimir.Document = Me.pdReporte
        Me.dlgImprimir.UseEXDialog = True
        '
        'FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 560)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnConfigurar)
        Me.Controls.Add(Me.btnVistaPrevia)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvAlumnos)
        Me.Controls.Add(Me.lblEstado)
        Me.MinimumSize = New System.Drawing.Size(760, 480)
        Me.Name = "FrmReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de alumnos – PrintDocument"
        CType(Me.dgvAlumnos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnConfigurar As System.Windows.Forms.Button
    Friend WithEvents btnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dgvAlumnos As System.Windows.Forms.DataGridView
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents pdReporte As System.Drawing.Printing.PrintDocument
    Friend WithEvents ppdVista As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents psdPagina As System.Windows.Forms.PageSetupDialog
    Friend WithEvents dlgImprimir As System.Windows.Forms.PrintDialog
End Class
