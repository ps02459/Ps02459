Imports System.Data.SqlClient
Public Class frmLogin

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim chuoiketnoi As String = "workstation id=ps02459.mssql.somee.com;packet size=4096;user id=phv1901_SQLLogin_1;pwd=yi4mk6ou7t;data source=ps02459.mssql.somee.com;persist security info=False;initial catalog=ps02459"
        Dim ketnoi As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim sqlAdater As New SqlDataAdapter("select * from nguoi_dung where taikhoan='" & txtUse.Text & "' and matkhau='" & txtPass.Text & "'", ketnoi)
        Dim tb As New DataTable

        Try
            ketnoi.Open()
            sqlAdater.Fill(tb)
            If tb.Rows.Count > 0 Then
                frmDangnhapthanhcong.Show()
                Me.Hide()

            Else
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản hoặc mật khẩu")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUse_TextChanged(sender As Object, e As EventArgs) Handles txtUse.TextChanged
        txtPass.Text = ""
    End Sub

End Class
