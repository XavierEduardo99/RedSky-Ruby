Public NotInheritable Class AboutBox1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Licencia.Show()
    End Sub

    Private Sub AboutBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Idioma = True Then
            Me.Text = "RedSky Ruby | About..."
            Label2.Text = "RedSky Ruby is protected under the BSD license."
            Label3.Text = "2019.0 (Stable version)"
            Button1.Text = "Accept."
            Label4.Text = "All the logos present here are property of" & vbNewLine & "their respective owners" & vbNewLine & "RedSky Ruby is property of" & vbNewLine & "Vinari Software and DO Development"
            Button2.Text = "Read license agreement."

            TextBox1.Text = "RedSky Ruby is an IDE developed by Vinari Software and DO Development" & vbNewLine & vbNewLine & "RedSky Ruby specializes in the popular programing languaje created in 1995 by Yukihiro Matsumoto called Ruby" & vbNewLine & vbNewLine & "RedSky Ruby is a light and powerful environment, able to develop simple apps, or complex websites, that make Ruby so famous the world around" & vbNewLine & vbNewLine & "Codification: UTF with BOM" & vbNewLine & "Version 2020.0"

        End If
    End Sub
End Class
