using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherClient
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string Request = "instruction=loginteacher|username=" + text_Username.Text + "|password=" + text_Password.Text;
            if (Client.Instance.SendData(Request)[0].Equals("success"))
            {
                Session.Instance.TeacherName = text_Username.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
