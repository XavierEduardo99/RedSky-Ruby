Imports System.IO

Public Class Ubicacion

    Dim NotFile As String : Dim Ruta As String = ""

    Private Sub Ubicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Idioma = True Then
            NotFile = "There is no file loaded yet..."
            Button1.Text = "Copy location to clipboard."
            Button2.Text = "Open location"
            Label1.Text = "Curent file location:"
            Me.Text = "RedSky Ruby | File location"
        Else
            NotFile = "Aún no se ha cargado un archivo..."
        End If

        Me.BackColor = My.Settings.ColorFondo
        Label1.BackColor = My.Settings.ColorFondo
        Label1.ForeColor = My.Settings.ColorFuentes
        Button1.BackColor = My.Settings.ColorFondo
        Button1.ForeColor = My.Settings.ColorFuentes

        If IDE.OpenFileDialog1.FileName = "" And IDE.SaveFileDialog2.FileName = "" Then
            TextBox1.Text = NotFile
        Else
            If IDE.SaveFileDialog2.FileName IsNot "" Then
                TextBox1.Text = IDE.SaveFileDialog2.FileName
                Ruta = Path.GetDirectoryName(IDE.SaveFileDialog2.FileName)
            Else
                TextBox1.Text = IDE.OpenFileDialog1.FileName
                Ruta = Path.GetDirectoryName(IDE.OpenFileDialog1.FileName)
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text IsNot "" Then
            TextBox1.Copy()

        Else
            If My.Settings.Idioma = True Then
                MsgBox("The file path is empty.")
            Else
                MsgBox("La ruta del archivo se encuentra vacía.")
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            Process.Start("explorer.exe", Ruta)
        Else
            If My.Settings.Idioma = True Then
                MsgBox("The file path is empty.")
            Else
                MsgBox("La ruta del archivo se encuentra vacía.")
            End If
        End If
    End Sub
End Class