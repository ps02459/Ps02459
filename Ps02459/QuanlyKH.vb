Imports System.Data.SqlClient
Imports System.Data.DataTable

Public Class frmQuanlyKH
    Dim tb As New DataTable
    Dim connectrs As String = "workstation id=ps02459.mssql.somee.com;packet size=4096;user id=phv1901_SQLLogin_1;pwd=yi4mk6ou7t;data source=ps02459.mssql.somee.com;persist security info=False;initial catalog=ps02459"

    Public Sub loadData()
        Dim ketnoi As New SqlConnection(connectrs)
        Dim sqlAdater As New SqlDataAdapter("select * from KHACH_HANG", ketnoi)
        Try
            sqlAdater.Fill(tb)
        Catch ex As Exception

        End Try
        dgvKH.DataSource = tb
        ketnoi.Close()
    End Sub
    Private Sub frmQuanlyKH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub dgvKH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKH.CellClick
        'Khi nhấp vào 1 dòng bất kỳ, dữ liệu sẽ đổ về các textbox
        Dim index As Integer = dgvKH.CurrentCell.RowIndex
        txtMaKH.Text = dgvKH.Item(0, index).Value
        txtTenKH.Text = dgvKH.Item(1, index).Value
        txtSdt.Text = dgvKH.Item(2, index).Value
        txtDiachi.Text = dgvKH.Item(3, index).Value
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtMaKH.Text = "" OrElse txtTenKH.Text = "" OrElse txtSdt.Text = "" OrElse _
            txtDiachi.Text = "" Then
            MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            Dim ketnoi As New SqlConnection(connectrs)
            ketnoi.Open()

            Dim stradd As String = "insert khach_hang values(@makh, @tenkh, @dt, @diachi)"
            Dim com As New SqlCommand(stradd, ketnoi)
            Try
                'gán dữ liệu vào các biến tạm
                com.Parameters.AddWithValue("@makh", txtMaKH.Text)
                com.Parameters.AddWithValue("@tenkh", txtTenKH.Text)
                com.Parameters.AddWithValue("@dt", txtSdt.Text)
                com.Parameters.AddWithValue("@diachi", txtDiachi.Text)
                'thực thi câu lệnh truy vấn
                com.ExecuteNonQuery()
                ketnoi.Close()
            Catch ex As Exception
            End Try
            'load dữ liệu lại
            tb.Clear()
            dgvKH.DataSource = tb
            dgvKH.DataSource = Nothing
            loadData()
        End If

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        If MessageBox.Show("Bạn chắc chắn muốn sửa dữ liệu này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim ketnoi As New SqlConnection(connectrs)
            ketnoi.Open()

            Dim stradd As String = "update khach_hang set Ten_KH = @tenkh, So_DT = @dt, Dia_Chi = @diachi WHERE MA_KH = @makh"
            Dim com As New SqlCommand(stradd, ketnoi)
            Try
                com.Parameters.AddWithValue("@makh", txtMaKH.Text)
                com.Parameters.AddWithValue("@tenkh", txtTenKH.Text)
                com.Parameters.AddWithValue("@dt", txtSdt.Text)
                com.Parameters.AddWithValue("@diachi", txtDiachi.Text)
                com.ExecuteNonQuery()
                ketnoi.Close()
            Catch ex As Exception
            End Try
            'load dữ liệu lại
            tb.Clear()
            dgvKH.DataSource = tb
            dgvKH.DataSource = Nothing
            loadData()
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If MessageBox.Show("Bạn chắc chắn muốn xóa dữ liệu này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

            Dim ketnoi As New SqlConnection(connectrs)
            ketnoi.Open()

            Dim stradd As String = "delete from Khach_hang where ma_kh = @makh"
            Dim com As New SqlCommand(stradd, ketnoi)
            Try
                com.Parameters.AddWithValue("@makh", txtMaKH.Text)
                com.ExecuteNonQuery()
                ketnoi.Close()
            Catch ex As Exception
            End Try
            'load dữ liệu lại
            tb.Clear()
            dgvKH.DataSource = tb
            dgvKH.DataSource = Nothing
            loadData()
        End If
    End Sub

    Private Sub btnEixt_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDiachi.Text = ""
        txtMaKH.Text = ""
        txtSdt.Text = ""
        txtTenKH.Text = ""
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click, txtFind.TextChanged

        tb.Clear()
        Dim ketnoi As New SqlConnection(connectrs)
        Dim sqlAdater As New SqlDataAdapter("select * from KHACH_HANG where ten_kh like '%" & txtFind.Text & "%'", ketnoi)
        Try
            sqlAdater.Fill(tb)

        Catch ex As Exception

        End Try
        dgvKH.DataSource = tb
        ketnoi.Close()
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        If txtFind.Text = "" Then
            tb.Clear()
            loadData()
        End If

    End Sub
End Class