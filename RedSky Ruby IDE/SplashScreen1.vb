Public NotInheritable Class SplashScreen1
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        End
    End Sub

    Private Sub SplashScreen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.Reset()
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value += 5
        If ProgressBar1.Value = 100 Then
            Timer1.Stop()
            If My.Settings.PrimerInicio = True Then
                PrimerInicio.Show()
            ElseIf My.Settings.PrimerInicio = False Then
                Inicio.Show()
            End If
            Me.Close()
        End If
    End Sub
End Class
