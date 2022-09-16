Public Class Preferencias
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop1
            My.Settings.TamanoVentana = FormWindowState.Maximized
        ElseIf RadioButton1.Checked = True Then
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop2
            My.Settings.TamanoVentana = FormWindowState.Normal
        End If
        My.Settings.Save()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If RadioButton2.Checked = True Then
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop1
            My.Settings.TamanoVentana = FormWindowState.Maximized
        ElseIf RadioButton1.Checked = True Then
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop2
            My.Settings.TamanoVentana = FormWindowState.Normal
        End If
        My.Settings.Save()
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs)
        If RadioButton2.Checked = True Then
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop1
            My.Settings.TamanoVentana = FormWindowState.Maximized
        ElseIf RadioButton1.Checked = True Then
            RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
            RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
            PictureBox1.Image = My.Resources.dektop2
            My.Settings.TamanoVentana = FormWindowState.Normal
        End If
        My.Settings.Save()
    End Sub

    Private Sub PorDefectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PorDefectoToolStripMenuItem.Click
        PictureBox2.Image = My.Resources.tema1
        IDE.ToolStripDropDownButton1.ForeColor = Color.White
        IDE.FastColoredTextBox1.SelectAll()
        IDE.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua
        IDE.FastColoredTextBox1.IndentBackColor = Color.FromArgb(50, 50, 50)
        IDE.FastColoredTextBox1.LineNumberColor = Color.Red
        IDE.FastColoredTextBox1.BackColor = Color.FromArgb(30, 30, 30)
        IDE.FastColoredTextBox1.ForeColor = Color.FloralWhite
        IDE.FastColoredTextBox1.LineNumberColor = Color.Crimson
        IDE.MenuStrip1.BackColor = Color.FromArgb(50, 50, 50)
        IDE.MenuStrip1.ForeColor = Color.FromArgb(50, 50, 50)
        IDE.ToolStrip1.BackColor = Color.FromArgb(50, 50, 50)
        IDE.ArchivoToolStripMenuItem.ForeColor = Color.FloralWhite
        IDE.EdiciónToolStripMenuItem.ForeColor = Color.FloralWhite
        IDE.VerToolStripMenuItem.ForeColor = Color.FloralWhite
        IDE.CompilarToolStripMenuItem.ForeColor = Color.FloralWhite
        IDE.AyudaToolStripMenuItem.ForeColor = Color.FloralWhite

        My.Settings.LenguajeSeleccionado = IDE.FastColoredTextBox1.Language
        My.Settings.ColorFondo = IDE.FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = IDE.FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = IDE.FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = IDE.FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = IDE.MenuStrip1.BackColor
    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        PictureBox2.Image = My.Resources.tema2
        IDE.ToolStripDropDownButton1.ForeColor = Color.White
        IDE.FastColoredTextBox1.SelectAll()
        IDE.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP
        IDE.FastColoredTextBox1.IndentBackColor = Color.Maroon
        IDE.FastColoredTextBox1.LineNumberColor = Color.MintCream
        IDE.FastColoredTextBox1.BackColor = Color.Maroon
        IDE.FastColoredTextBox1.ForeColor = Color.Salmon
        IDE.FastColoredTextBox1.LineNumberColor = Color.MintCream
        IDE.MenuStrip1.BackColor = Color.Maroon
        IDE.MenuStrip1.ForeColor = Color.MintCream
        IDE.ToolStrip1.BackColor = Color.Maroon
        IDE.ArchivoToolStripMenuItem.ForeColor = Color.MintCream
        IDE.EdiciónToolStripMenuItem.ForeColor = Color.MintCream
        IDE.VerToolStripMenuItem.ForeColor = Color.MintCream
        IDE.CompilarToolStripMenuItem.ForeColor = Color.MintCream
        IDE.AyudaToolStripMenuItem.ForeColor = Color.MintCream

        My.Settings.LenguajeSeleccionado = IDE.FastColoredTextBox1.Language
        My.Settings.ColorFondo = IDE.FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = IDE.FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = IDE.FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = IDE.FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = IDE.MenuStrip1.BackColor
    End Sub

    Private Sub Ajustes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Idioma = True Then
            Me.Text = "Settings"
            GroupBox1.Text = "Start"
            GroupBox2.Text = "Theme"
            GroupBox3.Text = "Language"
            GroupBox4.Text = "Use logs"

            Label1.Text = "Window state"
            Label2.Text = "Select the state in which the editor should appear when you start RedSky Ruby."
            RadioButton2.Text = "Maximized"
            Label4.Text = "Default theme"
            Label3.Text = "Customize the editor by choosing a theme to change the color of the interface."
            TemaToolStripMenuItem.Text = "Theme"
            PorDefectoToolStripMenuItem.Text = "Default"
            ToolStripMenuItem1.Text = "Light"
            Button1.Text = "Delete use logs"
            Button2.Text = "Read use logs"
            Button3.Text = "Default settings"
            Button4.Text = "OK"

        End If
        RadioButton1.Font = New Font("Proxima Nova Rg", 10, FontStyle.Regular)
        RadioButton2.Font = New Font("Proxima Nova Rg", 10, FontStyle.Bold)
        If My.Settings.TamanoVentana = FormWindowState.Maximized Then
            RadioButton2.Checked = True
            RadioButton1.Checked = False
        ElseIf My.Settings.TamanoVentana = FormWindowState.Normal Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        End If

        If My.Settings.Idioma = False Then
            RadioButton4.Checked = False
            RadioButton5.Checked = True
        Else
            RadioButton5.Checked = False
            RadioButton4.Checked = True
        End If

    End Sub

    Private Sub Ajustes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If RadioButton1.Checked = True Then
            IDE.WindowState = FormWindowState.Normal
        ElseIf RadioButton2.Checked = True Then
            IDE.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        PictureBox2.Image = My.Resources.tema4
        IDE.ToolStripDropDownButton1.ForeColor = Color.White
        IDE.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua
        IDE.FastColoredTextBox1.BackColor = Color.FromArgb(0, 0, 22)
        IDE.FastColoredTextBox1.ForeColor = Color.FloralWhite
        IDE.FastColoredTextBox1.IndentBackColor = Color.FromArgb(0, 0, 22)
        IDE.FastColoredTextBox1.LineNumberColor = Color.BlueViolet
        IDE.MenuStrip1.BackColor = Color.FromArgb(0, 0, 22)
        IDE.ToolStrip1.BackColor = Color.FromArgb(0, 0, 22)
        IDE.ArchivoToolStripMenuItem.ForeColor = Color.White
        IDE.EdiciónToolStripMenuItem.ForeColor = Color.White
        IDE.VerToolStripMenuItem.ForeColor = Color.White
        IDE.CompilarToolStripMenuItem.ForeColor = Color.White
        IDE.AyudaToolStripMenuItem.ForeColor = Color.White

        My.Settings.LenguajeSeleccionado = IDE.FastColoredTextBox1.Language
        My.Settings.ColorFondo = IDE.FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = IDE.FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = IDE.FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = IDE.FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

        My.Settings.Save()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        PictureBox2.Image = My.Resources.tema3
        IDE.ToolStripDropDownButton1.ForeColor = Color.Black
        IDE.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL
        IDE.FastColoredTextBox1.BackColor = Color.MintCream
        IDE.FastColoredTextBox1.ForeColor = Color.Black
        IDE.FastColoredTextBox1.IndentBackColor = Color.Honeydew
        IDE.FastColoredTextBox1.LineNumberColor = Color.Crimson
        IDE.MenuStrip1.BackColor = Color.MintCream
        IDE.ToolStrip1.BackColor = Color.MintCream
        IDE.ArchivoToolStripMenuItem.ForeColor = Color.Black
        IDE.EdiciónToolStripMenuItem.ForeColor = Color.Black
        IDE.VerToolStripMenuItem.ForeColor = Color.Black
        IDE.CompilarToolStripMenuItem.ForeColor = Color.Black
        IDE.AyudaToolStripMenuItem.ForeColor = Color.Black

        My.Settings.LenguajeSeleccionado = IDE.FastColoredTextBox1.Language
        My.Settings.ColorFondo = IDE.FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = IDE.FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = IDE.FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = IDE.FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

        IDE.ToolStrip1.BackColor = My.Settings.ColorFondo
        IDE.ArchivoToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
        IDE.EdiciónToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
        IDE.VerToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
        IDE.CompilarToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
        IDE.AyudaToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
    End Sub

    Private Sub DarkSunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkSunToolStripMenuItem.Click
        PictureBox2.Image = My.Resources.tema5
        IDE.ToolStripDropDownButton1.ForeColor = Color.White
        IDE.FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua
        IDE.FastColoredTextBox1.BackColor = Color.FromArgb(0, 43, 54)
        IDE.FastColoredTextBox1.ForeColor = Color.FloralWhite
        IDE.FastColoredTextBox1.IndentBackColor = Color.FromArgb(0, 43, 54)
        IDE.FastColoredTextBox1.LineNumberColor = Color.MediumTurquoise
        IDE.MenuStrip1.BackColor = Color.FromArgb(0, 43, 54)
        IDE.ToolStrip1.BackColor = Color.FromArgb(0, 43, 54)
        IDE.ArchivoToolStripMenuItem.ForeColor = Color.White
        IDE.EdiciónToolStripMenuItem.ForeColor = Color.White
        IDE.VerToolStripMenuItem.ForeColor = Color.White
        IDE.CompilarToolStripMenuItem.ForeColor = Color.White
        IDE.AyudaToolStripMenuItem.ForeColor = Color.White

        My.Settings.LenguajeSeleccionado = IDE.FastColoredTextBox1.Language
        My.Settings.ColorFondo = IDE.FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = IDE.FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = IDE.FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = IDE.FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

        My.Settings.Save()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("vinari-LogRemover")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Process.Start("vinari-LogReader")
    End Sub

    Dim auxClicInicio As Boolean = False

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If My.Settings.ClicInicio = True Then
            auxClicInicio = True
        Else
            auxClicInicio = False
        End If

        My.Settings.Reset()

        If auxClicInicio = False Then
            MsgBox("Se han cargado las configuraciones por defecto para RedSky Ruby.", MessageBoxIcon.Warning)
            RadioButton5.PerformClick()
        Else
            MsgBox("The default settings for RedSky Ruby have been loaded.", MessageBoxIcon.Warning)
            RadioButton4.PerformClick()
        End If

        My.Settings.ClicInicio = auxClicInicio
        My.Settings.PrimerInicio = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        My.Settings.Idioma = True
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        My.Settings.Idioma = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        My.Settings.Save()
        If My.Settings.ClicInicio = True Then

            Inicio.Close()
            Inicio.Show()

        Else
            Dim aux
            If My.Settings.Idioma = True Then
                aux = MsgBox("The changes will be applied when you restart RedSky Ruby. Do you want to restart it now?", MsgBoxStyle.YesNo)
            Else
                aux = MsgBox("Los cambios se aplicarán al reiniciar RedSky Ruby. ¿Desea reiniciarlo ahora?", MsgBoxStyle.YesNo)
            End If

            If aux = DialogResult.Yes Then

                IDE.Close()
                IDE.Show()

            End If
        End If

        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        RadioButton5.PerformClick()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        RadioButton4.PerformClick()
    End Sub
End Class