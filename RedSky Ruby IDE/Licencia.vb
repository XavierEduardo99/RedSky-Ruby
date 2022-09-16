Public Class Licencia
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Licencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Idioma = True Then
            Me.Text = "RedSky Ruby | License"
            Button1.Text = "Accept."
        End If
    End Sub
End Class