Public Class Inicio
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.Show()
        Licencia.Close()
    End Sub

    Private Sub LicenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicenciaToolStripMenuItem.Click
        Licencia.Show()
        AboutBox1.Close()
    End Sub

    Private Sub VersiónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Licencia.Close()
        AboutBox1.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim RubyDonwload
        If My.Settings.Idioma = True Then
            RubyDonwload = MsgBox("Do you want to visit the RubyInstaller for Windows page, to get it now?", MsgBoxStyle.YesNo)
        Else
            RubyDonwload = MsgBox("¿Desea visitar la página de RubyInstaller para Windows, para obtenerlo ahora?", MsgBoxStyle.YesNo)
        End If
        If RubyDonwload = DialogResult.Yes Then
            Process.Start("https://rubyinstaller.org/downloads/")
        End If
    End Sub

    Private Sub HolaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolaToolStripMenuItem.Click
        My.Settings.ClicInicio = True
        My.Settings.Save()
        Preferencias.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label7.Visible = False
        Button1.BackColor = Color.FromArgb(185, 0, 0)
        Button2.BackColor = Color.FromArgb(36, 36, 36)
        Button3.BackColor = Color.FromArgb(36, 36, 36)
        Button4.BackColor = Color.FromArgb(36, 36, 36)
        'Configuracion
        If My.Settings.Idioma = True Then
            Label5.Text = "Project: Create and edit a project in the simple and powerful Ruby programming language. Or choose an existing project to make changes to it."
            Label4.Text = "Project"
        Else
            Label5.Text = "Proyecto: Cree y edite un proyecto en el simple y poderoso lenguaje de programación Ruby. O elija algún proyecto existente para realizar cambios en el mismo."
            Label4.Text = "Proyecto"
        End If

        PictureBox2.Image = My.Resources.carpeta
        Button5.Visible = True
        Button6.Visible = True
        Button8.Visible = False
        Label6.Visible = False
        Button9.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim Cierre
        If My.Settings.Idioma = True Then
            Cierre = MsgBox("Are you sure you want to exit RedSky Ruby?", MsgBoxStyle.YesNo)
        Else
            Cierre = MsgBox("¿Está seguro que desea salir de RedSky Ruby?", MsgBoxStyle.YesNo)
        End If
        If Cierre = DialogResult.Yes Then
            Me.Close()
            End
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(185, 0, 0)
        Button1.BackColor = Color.FromArgb(36, 36, 36)
        Button3.BackColor = Color.FromArgb(36, 36, 36)
        Button4.BackColor = Color.FromArgb(36, 36, 36)
        'Configuracion
        If My.Settings.Idioma = True Then
            Label4.Text = "New features"
            Label5.Text = "New features: has frequent updates, which bring added and improvements to the editor."
            Label7.Text = "Version 2020.0 (1.4.0 )" & vbNewLine & vbNewLine & "* Better right clic menu" & vbNewLine & "* Updated to NetFramework 4.6" & vbNewLine & "* Updated to support Ruby 2.6.3" & vbNewLine & "* New color theme added" & vbNewLine & "* Autocomplete menu added" & vbNewLine & "* Better performance" & vbNewLine & "* English support"
        Else
            Label4.Text = "Novedades"
            Label5.Text = "Novedades: RedSky Ruby IDE cuenta con actualizaciones frecuentes, las cuales traen consigo añadidos y mejoras al editor."
        End If

        Label7.Visible = True
        PictureBox2.Image = My.Resources.update
        Button5.Visible = False
        Button6.Visible = False
        Button8.Visible = False
        Label6.Visible = False
        Button9.Visible = False

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Label7.Visible = False
        Button3.BackColor = Color.FromArgb(185, 0, 0)
        Button2.BackColor = Color.FromArgb(36, 36, 36)
        Button1.BackColor = Color.FromArgb(36, 36, 36)
        Button4.BackColor = Color.FromArgb(36, 36, 36)
        'Configuracion
        If My.Settings.Idioma = True Then
            Label5.Text = "Introduction: Ruby is a dynamic and open source programming language focused on simplicity and productivity."
            Label4.Text = "Introduction"
        Else
            Label5.Text = "Introducción: Ruby es un lenguaje de programación dinámico y de código abierto enfocado en la simplicidad y productividad."
            Label4.Text = "Introducción"
        End If

        PictureBox2.Image = My.Resources.intro
        Button5.Visible = False
        Button6.Visible = False
        Button8.Visible = False
        Label6.Visible = True
        Button9.Visible = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label7.Visible = False
        Button4.BackColor = Color.FromArgb(185, 0, 0)
        Button2.BackColor = Color.FromArgb(36, 36, 36)
        Button3.BackColor = Color.FromArgb(36, 36, 36)
        Button1.BackColor = Color.FromArgb(36, 36, 36)
        'Configuracion
        If My.Settings.Idioma = True Then
            Label5.Text = "Ruby: Download from this section the latest version of Ruby, necessary to work within this environment."
            Label4.Text = "Ruby"
        Else
            Label5.Text = "Ruby: Descargue desde este apartado la última versión de Ruby, necesario para trabajar dentro de este entorno."
            Label4.Text = "Ruby"
        End If

        PictureBox2.Image = My.Resources.descRuby
        Button5.Visible = False
        Button6.Visible = False
        Label6.Visible = False
        Button9.Visible = False
        Button8.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        My.Settings.Nuevo = True
        My.Settings.Save()

        Dim ObjectLoad As IDELoad
        ObjectLoad = New IDELoad()
        ObjectLoad.Main()

        Me.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If My.Settings.Idioma = True Then
            IDE.OpenFileDialog1.Title = "Open file..."
            IDE.OpenFileDialog1.Filter = "Ruby script|*.rb"
        End If

        IDE.OpenFileDialog1.InitialDirectory = My.Settings.rutaProyecto
        If IDE.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            IDE.Timer2.Enabled = True
            IDE.Timer2.Start()
            My.Settings.Nuevo = False
            My.Settings.Save()
            IDE.Show()
            Me.Close()
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If My.Settings.Idioma = True Then
            MsgBox("Next, RedSky Ruby will download the Ruby 2.6.1 installer for 64-bit computers.", MessageBoxIcon.Information)
        Else
            MsgBox("A continuación se procederá a descargar el instalador de Ruby 2.6.1 para ordenadores de 64 bits.", MessageBoxIcon.Information)
        End If
        Process.Start("https://github.com/oneclick/rubyinstaller2/releases/download/RubyInstaller-2.6.3-1/rubyinstaller-2.6.3-1-x64.exe")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Process.Start("https://www.ruby-lang.org/es/documentation/")
    End Sub

    Private Sub Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not System.IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RedSky Projects")) Then
            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RedSky Projects")
            My.Settings.rutaProyecto = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RedSky Projects"
            My.Settings.Save()
        End If
        If My.Settings.Idioma = True Then
            Me.Text = "RedSky Ruby | Welcome"
            Label2.Text = "Version 2020.0 (1.4.0)" & vbNewLine & "Stable."
            Label3.Text = "Version 2020.0 (1.4.0)"
            HolaToolStripMenuItem.Text = "Settings"
            AyudaToolStripMenuItem.Text = "Help"
            AcercaDeToolStripMenuItem.Text = "About..."
            LicenciaToolStripMenuItem.Text = "Read licence"
            Button1.Text = "Project."
            Button2.Text = "New features."
            Button3.Text = "Introduction."
            Button4.Text = "Download Ruby."
            Button5.Text = "New project"
            Button6.Text = "Open project"
            Button7.Text = "Exit RedSky Ruby."
            Button8.Text = "Download"
            Button9.Text = "Read more about Ruby"

            Label6.Text = "To know the basic principles of programming" & vbNewLine & "from Ruby, press the button below."
            Label5.Text = "Project: Create and edit a project in the simple and powerful Ruby programming language. Or choose an existing project to make changes to it."
            Label4.Text = "Project"
        End If
    End Sub

End Class