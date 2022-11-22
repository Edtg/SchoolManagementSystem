using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParentClient
{
    public partial class frmLogin : Form
    {
        private Client client = null;

        public frmLogin()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Request = "instruction=loginparent|username=" + textUsername.Text + "|password=" + textPassword.Text;
            if (Client.Instance.SendData(Request)[0].Equals("success"))
            {
                Session.Instance.ParentName = textUsername.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
