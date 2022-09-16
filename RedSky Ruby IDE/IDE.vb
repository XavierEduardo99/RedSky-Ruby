Imports System.IO
Imports FastColoredTextBoxNS
Public Class IDE

    Dim FileToExecute As String = ""

    Private Sub IDE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\RedSky Projects\RubyDebug.rb")
        Catch ex As Exception
            'DEJAR VACIO
        End Try

        If Me.WindowState = FormWindowState.Maximized Then
            My.Settings.TamanoVentana = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Normal Then
            My.Settings.TamanoVentana = FormWindowState.Normal
        End If
        My.Settings.Save()

        Dim BorrarTemporales As New ProcessStartInfo("vinari-TempRemover")
        BorrarTemporales.WindowStyle = ProcessWindowStyle.Minimized
        Process.Start(BorrarTemporales)

        If My.Settings.Idioma = False Then
            Dim CloseEvent = MsgBox("¿Desea guardar los cambios realizados?" & vbNewLine & "Si no guarda el archivo, estos cambios se perderán...", MsgBoxStyle.YesNoCancel)
            If CloseEvent = DialogResult.Yes Then
                If My.Settings.Nuevo = True Then
                    SaveFileDialog2.FileName = "Sin titulo.rb"
                End If
                SaveFileDialog2.ShowDialog()
                Try
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Catch ex As Exception
                End Try
            ElseIf CloseEvent = DialogResult.No Then
                'DEJAR VACIO
            ElseIf CloseEvent = DialogResult.Cancel Then
                e.Cancel = True
            End If

        ElseIf My.Settings.Idioma = True Then
            Dim CloseEvent = MsgBox("¿Do you want to save the changes?" & vbNewLine & "If you do not save the file, changes will be lost...", MsgBoxStyle.YesNoCancel)
            If CloseEvent = DialogResult.Yes Then
                If My.Settings.Nuevo = True Then
                    SaveFileDialog2.FileName = "Untitled.rb"
                End If
                SaveFileDialog2.ShowDialog()
                Try
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Catch ex As Exception
                End Try
            ElseIf CloseEvent = DialogResult.No Then
                'DEJAR VACIO
            ElseIf CloseEvent = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If

    End Sub

    Public Sub CerrarForm()
        If Me.WindowState = FormWindowState.Maximized Then
            My.Settings.TamanoVentana = FormWindowState.Maximized
        ElseIf Me.WindowState = FormWindowState.Normal Then
            My.Settings.TamanoVentana = FormWindowState.Normal
        End If
        My.Settings.Save()
        Dim BorrarTemporales As New ProcessStartInfo("vinari-TempRemover")
        BorrarTemporales.WindowStyle = ProcessWindowStyle.Minimized
        Process.Start(BorrarTemporales)
        Dim CloseEvent = MsgBox("¿Desea guardar los cambios realizados?" & vbNewLine & "Si no guarda el proyecto, estos cambios se perderán...", MsgBoxStyle.YesNoCancel)
        If CloseEvent = DialogResult.Yes Then
            If My.Settings.Nuevo = True Then
                SaveFileDialog2.FileName = "Sin título.rb"
            End If
            SaveFileDialog2.ShowDialog()
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Catch ex As Exception
            End Try
        ElseIf CloseEvent = DialogResult.No Then
            'DEJAR VACIO
        ElseIf CloseEvent = DialogResult.Cancel Then

        End If
    End Sub

    Private Sub MemoriaUsada()
        Dim mem As Process = Process.GetCurrentProcess()

        Dim cad As String
        Dim aux As Double = (mem.WorkingSet64 / 1024) / 1024
        cad = aux.ToString(“##,##0.00”) & " MB"
        MemoryTxt.Text = cad
    End Sub

    Private Sub IDE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = My.Settings.TamanoVentana
        If Me.WindowState = FormWindowState.Normal Then
            Me.CenterToScreen()
        End If
        SaveFileDialog2.InitialDirectory = My.Settings.rutaProyecto
        OpenFileDialog1.InitialDirectory = My.Settings.rutaProyecto
        Dim registro_ruby As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\RubyInstaller")
        If registro_ruby Is Nothing Then
            Dim resp = MessageBox.Show("No tiene Ruby instalado en su ordenador ¿Desea descargarlo?", "RedSky Ruby", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If resp = DialogResult.Yes Then
                MsgBox("A continuación se procederá a descargar el instalador de Ruby 2.6.1 para ordenadores de 64 bits.", MessageBoxIcon.Information)
                Process.Start("https://github.com/oneclick/rubyinstaller2/releases/download/RubyInstaller-2.6.3-1/rubyinstaller-2.6.3-1-x64.exe")
            Else
                MessageBox.Show("Instale Ruby en su ordenador para continuar.", "Error | RedSky Ruby", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
        Else

            If My.Settings.Nuevo = True Then
                Me.Text = "RedSky Ruby | Editor"
            Else
                Me.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName) + "  RedSky Ruby | Editor"
                SaveFileDialog2.FileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            End If

            Me.WindowState = My.Settings.TamanoVentana
            FastColoredTextBox1.Language = My.Settings.LenguajeSeleccionado
            FastColoredTextBox1.BackColor = My.Settings.ColorFondo
            FastColoredTextBox1.ForeColor = My.Settings.ColorFuentes
            ToolStripDropDownButton1.ForeColor = My.Settings.ColorFuentes
            FastColoredTextBox1.IndentBackColor = My.Settings.ColorIndentacion
            FastColoredTextBox1.LineNumberColor = My.Settings.ColorLineas
            MenuStrip1.BackColor = My.Settings.ColorFondo
            ToolStrip1.BackColor = My.Settings.ColorFondo
            ArchivoToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
            EdiciónToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
            VerToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
            CompilarToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
            AyudaToolStripMenuItem.ForeColor = My.Settings.ColorFuentes
            FastColoredTextBox1.Font = My.Settings.TipoDeFuente
            SaveFileDialog2.InitialDirectory = My.Settings.rutaProyecto

            MemoriaUsada()
            Timer1.Enabled = True
            Timer1.Start()

        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Salir = MsgBox("¿Desea salir de RedSky Ruby? Todo el avance no guardado será perdido...", MsgBoxStyle.YesNo)
        If Salir = DialogResult.Yes Then
            End
        ElseIf Salir = DialogResult.No Then
            SaveFileDialog2.ShowDialog()
        End If
    End Sub

    Private Sub NuevoProyectoEnBlancoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoProyectoEnBlancoToolStripMenuItem.Click
        Dim Salir = MsgBox("¿Realmente desea crear un documento nuevo? Todo el avance no guardado será perdido...", MsgBoxStyle.YesNo)
        If Salir = DialogResult.Yes Then
            FastColoredTextBox1.Clear()
        ElseIf Salir = DialogResult.No Then
            'DEJAR VACIO
        End If
    End Sub

    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        FastColoredTextBox1.Undo()
    End Sub

    Private Sub RehacerçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem1.Click
        FastColoredTextBox1.Redo()
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        FastColoredTextBox1.Copy()
    End Sub

    Private Sub CortarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem.Click
        FastColoredTextBox1.Cut()
    End Sub

    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        FastColoredTextBox1.Paste()
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        FastColoredTextBox1.SelectAll()
    End Sub

    Private Sub IrALineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrALineaToolStripMenuItem.Click
        FastColoredTextBox1.ShowGoToDialog()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        FastColoredTextBox1.ShowFindDialog()
    End Sub

    Private Sub BuscarYReemplazarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarYReemplazarToolStripMenuItem.Click
        FastColoredTextBox1.ShowReplaceDialog()
    End Sub


    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            Me.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName) + "  RedSky Ruby | Editor"
        End If
    End Sub

    Private Sub GuardarProyectoComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarProyectoComoToolStripMenuItem.Click
        Timer2.Enabled = True
        Timer2.Start()
        SaveFileDialog2.FileName = "Sin título.rb"
        SaveFileDialog2.ShowDialog()
        Try
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Try
            FastColoredTextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EjecutarScriptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EjecutarScriptToolStripMenuItem.Click
        FileToExecute = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        FileToExecute = FileToExecute + "\RedSky Projects\RubyDebug.rb"

        Try
            My.Computer.FileSystem.WriteAllText(FileToExecute, FastColoredTextBox1.Text, False)
            Process.Start(FileToExecute)
        Catch ex As Exception
            If My.Settings.Idioma = True Then
                MsgBox("There was an error when we tried to execute the file, please try again" & vbNewLine & "(File should be at 'My Documents\RedSky Projects')", MessageBoxIcon.Error)
            Else
                MsgBox("Hubo un error cuando intentamos ejecutar el archivo, por favor, inténtelo de nuevo" & vbNewLine & "(El archivo debería estar en 'Mis Documentos\RedSky Projects')", MessageBoxIcon.Error)
            End If
        End Try

    End Sub

    Private Sub DeshacerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem1.Click
        FastColoredTextBox1.Undo()
    End Sub

    Private Sub RehacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem.Click
        FastColoredTextBox1.Redo()
    End Sub

    Private Sub CopiarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem1.Click
        FastColoredTextBox1.Copy()
    End Sub

    Private Sub CortarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CortarToolStripMenuItem1.Click
        FastColoredTextBox1.Cut()
    End Sub

    Private Sub PegarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem1.Click
        FastColoredTextBox1.Paste()
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SeleccionarTodoToolStripMenuItem1.Click
        FastColoredTextBox1.SelectAll()
    End Sub

    Private Sub IrALaLineaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrALaLineaToolStripMenuItem.Click
        FastColoredTextBox1.ShowGoToDialog()
    End Sub

    Private Sub BuscarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem1.Click
        FastColoredTextBox1.ShowFindDialog()
    End Sub

    Private Sub BuscarYReemplazarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarYReemplazarToolStripMenuItem1.Click
        FastColoredTextBox1.ShowReplaceDialog()
    End Sub

    Private Sub AbrirProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirProyectoToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub GuardarProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarProyectoToolStripMenuItem.Click
        SaveFileDialog2.ShowDialog()
    End Sub

    Private Sub AbrirConsolaDeRubyTolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirConsolaDeRubyToolStripMenuItem.Click
        Process.Start("irb.cmd")
    End Sub

    Private Sub ConocerVersionDeRubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConocerVersionDeRubyToolStripMenuItem.Click
        Process.Start("vinari-Ruby-Check")
    End Sub

    Private Sub ColorDeFuenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorDeFuenteToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        FastColoredTextBox1.ForeColor = ColorDialog1.Color
        FastColoredTextBox1.LineNumberColor = ColorDialog1.Color
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.Save()
    End Sub

    Private Sub ColorDeFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorDeFondoToolStripMenuItem.Click
        ColorDialog2.ShowDialog()
        FastColoredTextBox1.BackColor = ColorDialog2.Color
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.Save()
    End Sub

    Private Sub NocturnoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FastColoredTextBox1.BackColor = Color.DimGray
        FastColoredTextBox1.ForeColor = Color.FloralWhite
        FastColoredTextBox1.LineNumberColor = Color.Crimson
    End Sub

    Private Sub ClasicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClasicoToolStripMenuItem.Click
        ToolStripDropDownButton1.ForeColor = Color.Black
        FastColoredTextBox1.Language = Language.SQL
        FastColoredTextBox1.BackColor = Color.MintCream
        FastColoredTextBox1.ForeColor = Color.Black
        FastColoredTextBox1.IndentBackColor = Color.Honeydew
        FastColoredTextBox1.LineNumberColor = Color.Red
        MenuStrip1.BackColor = Color.MintCream
        ToolStrip1.BackColor = Color.MintCream
        ArchivoToolStripMenuItem.ForeColor = Color.Black
        EdiciónToolStripMenuItem.ForeColor = Color.Black
        VerToolStripMenuItem.ForeColor = Color.Black
        CompilarToolStripMenuItem.ForeColor = Color.Black
        AyudaToolStripMenuItem.ForeColor = Color.Black
        FastColoredTextBox1.OnTextChanged()

        My.Settings.LenguajeSeleccionado = FastColoredTextBox1.Language
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        ToolStripDropDownButton1.ForeColor = Color.White
        FastColoredTextBox1.Language = Language.PHP
        FastColoredTextBox1.IndentBackColor = Color.Maroon
        FastColoredTextBox1.LineNumberColor = Color.MintCream
        FastColoredTextBox1.BackColor = Color.Maroon
        FastColoredTextBox1.ForeColor = Color.Salmon
        MenuStrip1.BackColor = Color.Maroon
        MenuStrip1.ForeColor = Color.MintCream
        ToolStrip1.BackColor = Color.Maroon
        ArchivoToolStripMenuItem.ForeColor = Color.MintCream
        EdiciónToolStripMenuItem.ForeColor = Color.MintCream
        VerToolStripMenuItem.ForeColor = Color.MintCream
        CompilarToolStripMenuItem.ForeColor = Color.MintCream
        AyudaToolStripMenuItem.ForeColor = Color.MintCream
        FastColoredTextBox1.OnTextChanged()

        My.Settings.LenguajeSeleccionado = FastColoredTextBox1.Language
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

    End Sub

    Private Sub AcercaDeRedSkyRubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeRedSkyRubyToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    Private Sub AcercaDelContratoDeLicenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDelContratoDeLicenciaToolStripMenuItem.Click
        Licencia.Show()
    End Sub

    Private Sub VisitarWebDeVinariSoftwareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitarWebDeVinariSoftwareToolStripMenuItem.Click
        Process.Start("http://vinarisoftware.wixsite.com/vinari")
    End Sub

    Private Sub VisitarWebDeVinariOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitarWebDeVinariOSToolStripMenuItem.Click
        Process.Start("http://vinarisoftware.wixsite.com/vinari-os")
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)
        e.Graphics.DrawString(FastColoredTextBox1.Text, FastColoredTextBox1.Font, Brushes.Black, 100, 100)
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem22.Click
        If SaveFileDialog2.FileName = "" Then
            Timer2.Enabled = True
            Timer2.Start()
            SaveFileDialog2.FileName = "Sin título.rb"
            SaveFileDialog2.ShowDialog()
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        Else
            SaveFileDialog2.DefaultExt = "|*.rb"
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        My.Settings.ClicInicio = False
        My.Settings.Save()
        Preferencias.Show()
    End Sub

    Private Sub NocturnoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NocturnoToolStripMenuItem.Click
        ToolStripDropDownButton1.ForeColor = Color.White
        FastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua
        FastColoredTextBox1.IndentBackColor = Color.FromArgb(50, 50, 50)
        FastColoredTextBox1.LineNumberColor = Color.Red
        FastColoredTextBox1.BackColor = Color.FromArgb(30, 30, 30)
        FastColoredTextBox1.ForeColor = Color.FloralWhite
        FastColoredTextBox1.LineNumberColor = Color.Crimson
        MenuStrip1.BackColor = Color.FromArgb(50, 50, 50)
        MenuStrip1.ForeColor = Color.FromArgb(50, 50, 50)
        ToolStrip1.BackColor = Color.FromArgb(50, 50, 50)
        ArchivoToolStripMenuItem.ForeColor = Color.FloralWhite
        EdiciónToolStripMenuItem.ForeColor = Color.FloralWhite
        VerToolStripMenuItem.ForeColor = Color.FloralWhite
        CompilarToolStripMenuItem.ForeColor = Color.FloralWhite
        AyudaToolStripMenuItem.ForeColor = Color.FloralWhite
        FastColoredTextBox1.OnTextChanged()

        My.Settings.LenguajeSeleccionado = FastColoredTextBox1.Language
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor
    End Sub

    Private Sub MoonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoonToolStripMenuItem.Click
        ToolStripDropDownButton1.ForeColor = Color.White
        FastColoredTextBox1.Language = Language.Lua
        FastColoredTextBox1.BackColor = Color.FromArgb(0, 0, 22)
        FastColoredTextBox1.ForeColor = Color.FloralWhite
        FastColoredTextBox1.IndentBackColor = Color.FromArgb(0, 0, 22)
        FastColoredTextBox1.LineNumberColor = Color.BlueViolet
        MenuStrip1.BackColor = Color.FromArgb(0, 0, 22)
        ToolStrip1.BackColor = Color.FromArgb(0, 0, 22)
        ArchivoToolStripMenuItem.ForeColor = Color.White
        EdiciónToolStripMenuItem.ForeColor = Color.White
        VerToolStripMenuItem.ForeColor = Color.White
        CompilarToolStripMenuItem.ForeColor = Color.White
        AyudaToolStripMenuItem.ForeColor = Color.White

        FastColoredTextBox1.OnTextChanged()

        My.Settings.LenguajeSeleccionado = FastColoredTextBox1.Language
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

        My.Settings.Save()

    End Sub

    Private Sub VerUbicacionDelArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerUbicacionDelArchivoToolStripMenuItem.Click
        Ubicacion.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim Salir = MsgBox("¿Realmente desea crear un documento nuevo? Todo el avance no guardado será perdido...", MsgBoxStyle.YesNo)
        If Salir = DialogResult.Yes Then
            FastColoredTextBox1.Clear()
        ElseIf Salir = DialogResult.No Then
            'DEJAR VACIO
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            Me.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName) + "  RedSky Ruby | Editor"
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Timer2.Enabled = True
        Timer2.Start()
        SaveFileDialog2.FileName = "Sin título.rb"
        SaveFileDialog2.ShowDialog()
        Try
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If SaveFileDialog2.FileName = "" Then
            Timer2.Enabled = True
            Timer2.Start()
            SaveFileDialog2.FileName = "Sin título.rb"
            SaveFileDialog2.ShowDialog()
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        Else
            SaveFileDialog2.DefaultExt = "|*.rb"
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        FastColoredTextBox1.Copy()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        FastColoredTextBox1.Undo()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        FastColoredTextBox1.Redo()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        FastColoredTextBox1.Cut()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        FastColoredTextBox1.Paste()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        FastColoredTextBox1.SelectAll()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        FastColoredTextBox1.ShowGoToDialog()
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        FastColoredTextBox1.ShowFindDialog()
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        FastColoredTextBox1.ShowReplaceDialog()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Ubicacion.Show()
    End Sub

    Private Sub VisitarWebDeDODevelopmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VisitarWebDeDODevelopmentToolStripMenuItem.Click
        MsgBox("Este sitio web está en camino... ", MessageBoxIcon.Information)
    End Sub

    Private Sub DarkSunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DarkSunToolStripMenuItem.Click
        ToolStripDropDownButton1.ForeColor = Color.White
        FastColoredTextBox1.Language = Language.Lua
        FastColoredTextBox1.BackColor = Color.FromArgb(0, 43, 54)
        FastColoredTextBox1.ForeColor = Color.FloralWhite
        FastColoredTextBox1.IndentBackColor = Color.FromArgb(0, 43, 54)
        FastColoredTextBox1.LineNumberColor = Color.MediumTurquoise
        MenuStrip1.BackColor = Color.FromArgb(0, 43, 54)
        ToolStrip1.BackColor = Color.FromArgb(0, 43, 54)
        ArchivoToolStripMenuItem.ForeColor = Color.White
        EdiciónToolStripMenuItem.ForeColor = Color.White
        VerToolStripMenuItem.ForeColor = Color.White
        CompilarToolStripMenuItem.ForeColor = Color.White
        AyudaToolStripMenuItem.ForeColor = Color.White
        FastColoredTextBox1.OnTextChanged()

        My.Settings.LenguajeSeleccionado = FastColoredTextBox1.Language
        My.Settings.ColorFondo = FastColoredTextBox1.BackColor
        My.Settings.ColorFuentes = FastColoredTextBox1.ForeColor
        My.Settings.ColorIndentacion = FastColoredTextBox1.IndentBackColor
        My.Settings.ColorLineas = FastColoredTextBox1.LineNumberColor
        My.Settings.ColorHerramientas = MenuStrip1.BackColor

        My.Settings.Save()
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        EjecutarScriptToolStripMenuItem.PerformClick()
    End Sub


    Private Sub FastColoredTextBox1_TextChanged(sender As Object, e As TextChangedEventArgs) Handles FastColoredTextBox1.TextChanged

        If OpenFileDialog1.FileName IsNot "" Then
            Me.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName) + "*  RedSky Ruby | Editor"
        ElseIf SaveFileDialog2.FileName IsNot "" Then
            Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "*  RedSky Ruby | Editor"
        End If

    End Sub

    Dim tick As Byte = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        tick = tick + 1
        If tick = 20 Then
            MemoriaUsada()
            tick = 0
        End If

    End Sub

    Private Sub PantallaInicialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PantallaInicialToolStripMenuItem.Click
        Inicio.Show()
    End Sub

    Public Sub NuevoArchivo()
        Dim Salir = MsgBox("¿Realmente desea crear un documento nuevo? Todo el avance no guardado será perdido...", MsgBoxStyle.YesNo)
        If Salir = DialogResult.Yes Then
            FastColoredTextBox1.Clear()
        ElseIf Salir = DialogResult.No Then
            'DEJAR VACIO
        End If
    End Sub

    Public Sub AbrirArchivo()
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName.Length > 3 Then
            Me.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName) + "  RedSky Ruby | Editor"
        End If
    End Sub

    Public Sub GuardarComo()
        Timer2.Enabled = True
        Timer2.Start()

        SaveFileDialog2.FileName = "Sin título.rb"
        SaveFileDialog2.ShowDialog()
        Try
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Guardar()
        If SaveFileDialog2.FileName = "" Then
            Timer2.Enabled = True
            Timer2.Start()
            SaveFileDialog2.FileName = "Sin título.rb"
            SaveFileDialog2.ShowDialog()
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        Else
            SaveFileDialog2.DefaultExt = "|*.rb"
            My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog2.FileName, FastColoredTextBox1.Text, False)
                Me.Text = System.IO.Path.GetFileName(SaveFileDialog2.FileName) + "  RedSky Ruby | Editor"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        CerrarForm()
    End Sub

    Dim saveTrigger As Integer = 0

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        saveTrigger += 1
        If saveTrigger = 300000 Then
            Guardar()
            saveTrigger = 0
        End If
    End Sub

    Private Sub SaveFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog2.FileOk

    End Sub
End Class