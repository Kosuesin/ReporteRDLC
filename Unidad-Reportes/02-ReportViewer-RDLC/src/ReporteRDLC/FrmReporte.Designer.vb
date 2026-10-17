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
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.lblCarrera = New System.Windows.Forms.Label()
        Me.cboCarrera = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnGuardarPdf = New System.Windows.Forms.Button()
        Me.pnlFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.pnlFiltros.Controls.Add(Me.lblCarrera)
        Me.pnlFiltros.Controls.Add(Me.cboCarrera)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Controls.Add(Me.btnGuardarPdf)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1000, 56)
        Me.pnlFiltros.TabIndex = 0
        '
        'lblCarrera
        '
        Me.lblCarrera.AutoSize = True
        Me.lblCarrera.Location = New System.Drawing.Point(16, 19)
        Me.lblCarrera.Name = "lblCarrera"
        Me.lblCarrera.Text = "Carrera:"
        '
        'cboCarrera
        '
        Me.cboCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCarrera.Location = New System.Drawing.Point(80, 15)
        Me.cboCarrera.Name = "cboCarrera"
        Me.cboCarrera.Size = New System.Drawing.Size(260, 23)
        Me.cboCarrera.TabIndex = 0
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(356, 11)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(150, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Generar reporte"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnGuardarPdf
        '
        Me.btnGuardarPdf.Enabled = False
        Me.btnGuardarPdf.Location = New System.Drawing.Point(516, 11)
        Me.btnGuardarPdf.Name = "btnGuardarPdf"
        Me.btnGuardarPdf.Size = New System.Drawing.Size(150, 32)
        Me.btnGuardarPdf.TabIndex = 2
        Me.btnGuardarPdf.Text = "Guardar PDF"
        Me.btnGuardarPdf.UseVisualStyleBackColor = True
        '
        'FrmReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 680)
        Me.Controls.Add(Me.pnlFiltros)
        Me.MinimumSize = New System.Drawing.Size(720, 480)
        Me.Name = "FrmReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de alumnos – ReportViewer"
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents lblCarrera As System.Windows.Forms.Label
    Friend WithEvents cboCarrera As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnGuardarPdf As System.Windows.Forms.Button
End Class
