using System.Globalization;

namespace TeacherClient
{
    public partial class frmMain : Form
    {
        private string EditingClassName = "";

        private Dictionary<string, int> UpdatedClassMarks = new Dictionary<string, int>();

        public frmMain()
        {
            InitializeComponent();

            HidePanels();
            
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            }

            label_LoggedInValue.Text = Session.Instance.TeacherName;

            panel_Dashboard.Visible = true;
        }

        private void HidePanels()
        {
            panel_Dashboard.Visible = false;
            panel_ClassList.Visible = false;
            panel_Broadcasts.Visible = false;
            panel_EditClass.Visible = false;
        }

        private void btn_ViewClassesMenu_Click(object sender, EventArgs e)
        {
            HidePanels();

            UpdateClassTable();
            cbo_SortBy.SelectedIndex = 0;

            panel_ClassList.Visible = true;
        }

        private void btn_BroadcastsMenu_Click(object sender, EventArgs e)
        {
            HidePanels();

            UpdateBroadcastsPanel();

            panel_Broadcasts.Visible = true;
        }

        private void btn_MessagesMenu_Click(object sender, EventArgs e)
        {
            frmMessages frm = new frmMessages();
            frm.Show();
        }

        private void cbo_SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbo_SortBy.SelectedIndex)
            {
                case 0:
                    UpdateClassTable("name");
                    break;
                case 1:
                    UpdateClassTable("date");
                    break;
                case 2:
                    UpdateClassTable("students");
                    break;
                default:
                    UpdateClassTable();
                    break;
            }
        }

        private void UpdateClassTable(string SortType = "name")
        {
            foreach (Label ClassTableControl in panel_ClassTable.Controls.OfType<Label>().ToList())
            {
                panel_ClassTable.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }
            foreach (Button ClassTableControl in panel_ClassTable.Controls.OfType<Button>().ToList())
            {
                panel_ClassTable.Controls.Remove(ClassTableControl);
                ClassTableControl.Dispose();
            }
            panel_ClassTable.RowStyles.Clear();

            panel_ClassTable.RowCount = 0;
            List<string> Classes = Client.Instance.SendData("instruction=teacherclasses|sort=" + SortType + "|teacher=" + Session.Instance.TeacherName);

            if (Classes[0] != "empty")
            {
                panel_ClassTable.RowCount = Classes.Count;
                for (int i = 0; i < Classes.Count; i++)
                {
                    string ClassName = Classes[i].Split("|")[0];
                    DateTime ClassStartDate = DateTime.ParseExact(Classes[i].Split("|")[1], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime ClassEndDate = DateTime.ParseExact(Classes[i].Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
                    string StudentCount = Classes[i].Split("|")[3];

                    Label ClassNameLabel = new Label();
                    ClassNameLabel.Text = ClassName;
                    panel_ClassTable.Controls.Add(ClassNameLabel, 0, i);

                    Label ClassDtartDateLabel = new Label();
                    ClassDtartDateLabel.Text = ClassStartDate.ToString("dd/MM/yyyy");
                    panel_ClassTable.Controls.Add(ClassDtartDateLabel, 1, i);

                    Label ClassEndDateLabel = new Label();
                    ClassEndDateLabel.Text = ClassEndDate.ToString("dd/MM/yyyy");
                    panel_ClassTable.Controls.Add(ClassEndDateLabel, 2, i);

                    Label ClassStudentCountLabel = new Label();
                    ClassStudentCountLabel.Text = StudentCount;
                    panel_ClassTable.Controls.Add(ClassStudentCountLabel, 3, i);

                    Button ClassEditButton = new Button();
                    ClassEditButton.Text = "Edit";
                    ClassEditButton.Click += (sender, EventArgs) => { ShowClassEdit(sender, EventArgs, ClassName); };
                    panel_ClassTable.Controls.Add(ClassEditButton, 4, i);

                    panel_ClassTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                }
            }
        }

        private void btn_NewClass_Click(object sender, EventArgs e)
        {

            frmNewClass frm = new frmNewClass();
            frm.ShowDialog();

            UpdateClassTable();
        }

        private void ShowClassEdit(object sender, EventArgs e, string ClassName)
        {
            foreach (Label MarksTableControl in panel_EditingClassMarks.Controls.OfType<Label>().ToList())
            {
                panel_EditingClassMarks.Controls.Remove(MarksTableControl);
                MarksTableControl.Dispose();
            }
            foreach (TextBox MarksTableControl in panel_EditingClassMarks.Controls.OfType<TextBox>().ToList())
            {
                panel_EditingClassMarks.Controls.Remove(MarksTableControl);
                MarksTableControl.Dispose();
            }
            panel_EditingClassMarks.RowStyles.Clear();


            EditingClassName = ClassName;
            UpdatedClassMarks = new Dictionary<string, int>();
            text_EditClassName.Text = EditingClassName;

            string EditingClass = Client.Instance.SendData("instruction=getclass|classname=" + EditingClassName)[0];
            if (EditingClass.Equals(""))
            {
                EditingClassName = "";
                return;
            }
            date_EditStartDate.Value = DateTime.ParseExact(EditingClass.Split("|")[1], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
            date_EditEndDate.Value = DateTime.ParseExact(EditingClass.Split("|")[2], "yyyyMMdd:HH:mm:ss", CultureInfo.InvariantCulture);
            text_EditJoinCode.Text = EditingClass.Split("|")[3];

            List<string> EditingClassMarks = Client.Instance.SendData("instruction=getclassmarks|classname=" + EditingClassName);

            panel_EditingClassMarks.RowCount = EditingClassMarks.Count;

            if (!EditingClassMarks[0].Equals("empty"))
            {
                for (int i = 0; i < EditingClassMarks.Count; i++)
                {
                    string StudentName = EditingClassMarks[i].Split("|")[0];
                    Label StudentMarkLabel = new Label();
                    StudentMarkLabel.Text = StudentName;
                    panel_EditingClassMarks.Controls.Add(StudentMarkLabel, 0, i);

                    TextBox StudentMarkTextBox = new TextBox();
                    StudentMarkTextBox.Text = EditingClassMarks[i].Split("|")[1];
                    StudentMarkTextBox.TextChanged += (sender, EventArgs) => { UpdatedClassMarks[StudentName] = Int32.Parse(StudentMarkTextBox.Text); };
                    panel_EditingClassMarks.Controls.Add(StudentMarkTextBox, 1, i);

                    panel_EditingClassMarks.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                }
            }

            HidePanels();

            panel_EditClass.Visible = true;
        }

        private void btn_SaveClassEdit_Click(object sender, EventArgs e)
        {
            string UpdateClassRequest = "instruction=updateclass";
            UpdateClassRequest += "|classname=" + EditingClassName;
            UpdateClassRequest += "|name=" + text_EditClassName.Text;
            DateTime ClassStartDate = date_EditStartDate.Value;
            UpdateClassRequest += "|startdate=" + ClassStartDate.ToString("yyyyMMdd:HH:mm:ss");
            DateTime ClassEndDate = date_EditEndDate.Value;
            UpdateClassRequest += "|enddate=" + ClassEndDate.ToString("yyyyMMdd:HH:mm:ss");
            UpdateClassRequest += "|code=" + text_EditJoinCode.Text;

            Client.Instance.SendData(UpdateClassRequest);

            foreach (var Marks in UpdatedClassMarks)
            {
                Client.Instance.SendData("instruction=updatemarks|classname=" + EditingClassName + "|student=" + Marks.Key + "|marks=" + Marks.Value);
            }

            EditingClassName = "";

            MessageBox.Show("Class saved");
        }

        private void btn_DeleteEditingClass_Click(object sender, EventArgs e)
        {
            string Result = Client.Instance.SendData("instruction=removeclass|classname=" + EditingClassName)[0];

            if (Result.Equals("success"))
            {
                EditingClassName = "";

                HidePanels();

                UpdateClassTable();

                panel_ClassList.Visible = true;

                MessageBox.Show("Class deleted");
            }
            else
            {
                MessageBox.Show("Error deleting class");
            }
        }

        private void btn_SetDate_Click(object sender, EventArgs e)
        {
            string Result = Client.Instance.SendData("instruction=setsimulateddate|date=" + date_SimulationDate.Value.ToString("yyyyMMdd:HH:mm:ss"))[0];

            if (Result.Equals("success"))
            {
                MessageBox.Show("Date set to " + date_SimulationDate.Value.ToString("dd/MM/yyyy"));
            }
            else
            {
                MessageBox.Show("Error setting date");
            }
        }

        private void UpdateBroadcastsPanel()
        {
            List<string> Classes = Client.Instance.SendData("instruction=teacherclasses|sort=name|teacher=" + Session.Instance.TeacherName);

            if (Classes.Count > 0)
            {
                foreach (string Class in Classes)
                {
                    cbo_BroadcastReceiver.Items.Add(Class.Split("|")[0]);
                }
                cbo_BroadcastReceiver.SelectedIndex = 0;
            }
        }

        private void btn_SendBroadcast_Click(object sender, EventArgs e)
        {
            string Result = Client.Instance.SendData("instruction=sendbroadcast|sender=" + Session.Instance.TeacherName + "|classname=" + cbo_BroadcastReceiver.SelectedItem.ToString() + "|content=" + text_Broadcast.Text)[0];

            if (Result.Equals("success"))
            {
                MessageBox.Show("Broadcast sent");
            }
            else
            {
                MessageBox.Show("Error sending broadcast");
            }
        }
    }
}