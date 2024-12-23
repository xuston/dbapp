using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using Microsoft.Data.SqlClient;


namespace database_application
{
    public partial class Authoritaition : Form
    {
        public static string logon;
        public static string pass;

       
       

        public Authoritaition()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            passwd.UseSystemPasswordChar = true;
            
            
           

        }

        private void confirm_Click(object sender, EventArgs e)
        {

             Database data = new Database();
             logon = logint.Text;
             pass = passwd.Text;
             try
            {             
                 data.connect();
                 Databaseapplication app = new Databaseapplication();
                 this.Hide();
                 app.ShowDialog();
                 this.Close();
             }
             catch (Exception ex)
             {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }            
        }
    }
}
