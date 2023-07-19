using WinFormsApp1.Model;

namespace AssigmentPRN211
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var context = new Prn211Context();
            User u = new User();
            
            string? username = cb_username.Text;
            string? password = cb_password.Text;
            if(username != String.Empty && password != String.Empty)
            {
                var Userexit= context.Users.FirstOrDefault(x => x.Username == username);
                if(Userexit != null)
                {
                    if(Userexit.Password == password)
                    {
                        this.Hide();
                        Form2 newpage = new Form2();
                        newpage.Closed += (s, args) => this.Close();
                        newpage.Show();
                        

                    }
                    else
                    {
                        MessageBox.Show("Missing password");
                    }
                }
                else
                {
                    MessageBox.Show("Missing Username");
                }
            }
            else
            {
                MessageBox.Show("Insert fulfill");
            }
            
            
            context.SaveChanges();
            

        }
    }
}