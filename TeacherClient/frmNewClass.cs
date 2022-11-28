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
    public partial class frmNewClass : Form
    {
        public frmNewClass()
        {
            InitializeComponent();

            date_ClassStartDate.Value = DateTime.Now;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            Client.Instance.SendData("instruction=createclass|name=" + text_ClassName.Text
                + "|date=" + date_ClassStartDate.Value.ToString("yyyyMMdd:HH:mm:ss")
                + "|enddate=" + date_ClassEndDate.Value.ToString("yyyyMMdd:HH:mm:ss")
                + "|teacher=" + Session.Instance.TeacherName
                + "|code=" + text_JoinCode.Text);

            Close();
        }
    }
}
