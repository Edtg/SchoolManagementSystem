namespace ParentClient
{
    public partial class Form1 : Form
    {
        private Client client = null;
        public Form1()
        {
            InitializeComponent();

            client = new Client("127.0.0.1", 5555);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            client.SendData(text_Input.Text);
        }
    }
}