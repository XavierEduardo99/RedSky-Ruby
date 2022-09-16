Public Class IDELoad

    Sub Main()
        If My.Settings.Idioma = True Then
            IDEIngles()
        End If

        IDE.Show()

    End Sub
    Function IDEIngles()
        IDE.ArchivoToolStripMenuItem.Text = "&File"
        IDE.EdiciónToolStripMenuItem.Text = "&Edit"
        IDE.VerToolStripMenuItem.Text = "&View"
        IDE.CompilarToolStripMenuItem.Text = "&Run"
        IDE.AyudaToolStripMenuItem.Text = "&Help"

        IDE.AcercaDeDODevelopmentToolStripMenuItem.Text = "About DO Development"
        IDE.AcercaDelContratoDeLicenciaToolStripMenuItem.Text = "About the license agreement"
        IDE.AcercaDeRedSkyRubyToolStripMenuItem.Text = "About RedSky Ruby"
        IDE.AcercaDeVinariSoftwareToolStripMenuItem.Text = "About Vinari Software"

        IDE.VisitarWebDeDODevelopmentToolStripMenuItem.Text = "Visit DO Development's website"
        IDE.VisitarWebDeVinariOSToolStripMenuItem.Text = "Visit Vinari OS's website"
        IDE.VisitarWebDeVinariSoftwareToolStripMenuItem.Text = "Visit Vinari Software's website"

        IDE.EjecutarScriptToolStripMenuItem.Text = "Run script"
        IDE.AbrirConsolaDeRubyToolStripMenuItem.Text = "Open Ruby's interactive console"
        IDE.ConocerVersionDeRubyToolStripMenuItem.Text = "Get current Ruby version"

        IDE.TemasToolStripMenuItem.Text = "Themes"

        IDE.NocturnoToolStripMenuItem.Text = "Nightly (Default)"
        IDE.ClasicoToolStripMenuItem.Text = "Classic"

        IDE.DeshacerToolStripMenuItem.Text = "Undo"
        IDE.RehacerToolStripMenuItem1.Text = "Redo"
        IDE.CopiarToolStripMenuItem.Text = "Copy"
        IDE.CortarToolStripMenuItem.Text = "Cut"
        IDE.PegarToolStripMenuItem.Text = "Paste"
        IDE.SeleccionarTodoToolStripMenuItem.Text = "Select all"
        IDE.IrALineaToolStripMenuItem.Text = "Go to line..."
        IDE.BuscarToolStripMenuItem.Text = "Search"
        IDE.BuscarYReemplazarToolStripMenuItem.Text = "Search and replace"

        IDE.NuevoProyectoEnBlancoToolStripMenuItem.Text = "New blank file"
        IDE.AbrirToolStripMenuItem.Text = "Open file..."
        IDE.GuardarProyectoComoToolStripMenuItem.Text = "Save file as..."
        IDE.GuardarToolStripMenuItem22.Text = "Save"
        IDE.PantallaInicialToolStripMenuItem.Text = "Main menu"
        IDE.VerUbicacionDelArchivoToolStripMenuItem.Text = "See file location"
        IDE.ConfiguraciónToolStripMenuItem.Text = "Settings"
        IDE.SalirToolStripMenuItem.Text = "Quit"

        IDE.ToolStripDropDownButton1.Text = "Run script"
        IDE.ToolStripDropDownButton1.ToolTipText = "Run"
        IDE.MemoryTxt.ToolTipText = "Memory usage"
        IDE.ToolStripButton14.Text = "See file location"
        IDE.ToolStripButton13.Text = "Search and replace"
        IDE.ToolStripButton12.Text = "Search"
        IDE.ToolStripButton11.Text = "Go to line..."
        IDE.ToolStripButton10.Text = "Select all"
        IDE.ToolStripButton9.Text = "Paste"
        IDE.ToolStripButton8.Text = "Cut"
        IDE.ToolStripButton7.Text = "Copy"
        IDE.ToolStripButton6.Text = "Redo"
        IDE.ToolStripButton5.Text = "Undo"
        IDE.ToolStripButton3.Text = "Save"
        IDE.ToolStripButton4.Text = "Save as..."
        IDE.ToolStripButton1.Text = "Open file..."
        IDE.ToolStripButton2.Text = "New blank file"

        IDE.AbrirProyectoToolStripMenuItem.Text = "Open file"
        IDE.GuardarProyectoToolStripMenuItem.Text = "Save file"
        IDE.DeshacerToolStripMenuItem1.Text = "Undo"
        IDE.RehacerToolStripMenuItem.Text = "Redo"
        IDE.CopiarToolStripMenuItem1.Text = "Copy"
        IDE.CortarToolStripMenuItem1.Text = "Cut"
        IDE.PegarToolStripMenuItem1.Text = "Paste"
        IDE.SeleccionarTodoToolStripMenuItem1.Text = "Select all"
        IDE.IrALaLineaToolStripMenuItem.Text = "Go to line"
        IDE.BuscarToolStripMenuItem1.Text = "Search"
        IDE.BuscarYReemplazarToolStripMenuItem1.Text = "Search and replace"

    End Function

End Class
