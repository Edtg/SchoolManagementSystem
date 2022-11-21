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
    public partial class FrmLogin : Form
    {
        private Client client = null;

        public FrmLogin()
        {
            InitializeComponent();

            client = new Client("127.0.0.1", 5555);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Request = "instruction=loginparent|username=" + textUsername.Text + "|password=" + textPassword.Text;
            client.SendData(Request);
        }
    }
}
