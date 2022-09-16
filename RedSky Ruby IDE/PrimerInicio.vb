Public Class PrimerInicio
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        My.Settings.PrimerInicio = False
        My.Settings.Save()
        If My.Settings.Idioma = True Then
            MsgBox("Language set correctly.", MessageBoxIcon.Information)
        Else
            MsgBox("Idioma establecido correctamente.", MessageBoxIcon.Information)
        End If
        Inicio.Show()
        Me.Close()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        My.Settings.Idioma = True
        Label1.Text = "Welcome to RedSky Ruby, please select the language of your choice."
        MetroButton1.Text = "OK"
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        My.Settings.Idioma = False
        Label1.Text = "Bienvenido a RedSky Ruby, a continuación seleccione el idioma de su preferencia."
        MetroButton1.Text = "Aceptar"
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        RadioButton4.PerformClick()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        RadioButton5.PerformClick()
    End Sub
End Class