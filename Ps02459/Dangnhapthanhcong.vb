Public Class frmDangnhapthanhcong
    
    Private Sub frmDangnhapthanhcong_Load(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        frmMain.Show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        System.Threading.Thread.Sleep(2000)
        Timer1.Enabled = False
        Me.Close()
    End Sub
End Class