Public Class frmMain

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Hide()
        frmLogin.Show()
    End Sub

    Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
        Me.Close()
    End Sub

    Private Sub btnQuanlyKH_Click(sender As Object, e As EventArgs) Handles btnQuanlyKH.Click
        Dim ql As New frmQuanlyKH
        ql.Show()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hiển thị Ten đăng nhập và vai trò
        lblTendangnhap.Text = frmLogin.txtUse.Text
        If frmLogin.txtUse.Text = "admin" Then
            lblVaitro.Text = "Quản trị viên"
        Else
            lblVaitro.Text = "Nhân viên"
        End If
    End Sub
End Class