Public Class frmSelectServer 

    Private Sub frmSelectServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call con_getsetting()
        TextBox1.Text = con_server
        TextBox2.Text = con_userid
        TextBox3.Text = con_password
        TextBox4.Text = con_database
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call con_savesetting(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        MessageBox.Show("Setting Saved!")
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Button2_Click(Button2, New System.EventArgs)
        TextBox1.Select()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then TextBox2.Focus()
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then TextBox3.Focus()
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then TextBox4.Focus()
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then Button1.Focus()
    End Sub
End Class