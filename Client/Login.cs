using Client.SocketConnection;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : MetroForm
    {

        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string id = idTextbox.Text;
            string pw = pwTextbox.Text;

            SocketManager.sendData(id + ',' + pw);
            string receive = SocketManager.getData();

            if(receive == "Success")
            {
                this.DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show("다시 확인해 주세요.", "알림");
                ActiveControl = idTextbox;
                idTextbox.Text = "";
                pwTextbox.Text = "";
            }
        }

        private void pwTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
          
        }

        private void idTextbox_Enter(object sender, EventArgs e)
        {
            idTextbox.Text = "";
        }

        private void pwTextbox_Enter(object sender, EventArgs e)
        {
            pwTextbox.Text = "";
        }

    }

}
