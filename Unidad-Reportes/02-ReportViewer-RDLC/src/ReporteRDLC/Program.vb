Imports System.Windows.Forms

' Punto de entrada de la aplicación.
Module Program

    <STAThread>
    Sub Main()
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FrmReporte())
    End Sub

End Module
