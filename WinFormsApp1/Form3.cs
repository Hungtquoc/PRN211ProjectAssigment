using AssigmentPRN211;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 newpage = new Form1();
            newpage.Closed += (s, args) => this.Close();
            newpage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newpage = new Form2();
            newpage.Closed += (s, args) => this.Close();
            newpage.Show();
        }
    }
}