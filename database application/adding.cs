using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace database_application
{
    public partial class adding : Form
    {
        public string[] lablet = new string[5];
        public adding()
        {
            InitializeComponent();
        }

        private void adding_Load(object sender, EventArgs e)
        {
            Databaseapplication app = new Databaseapplication();
            if (lablet[4] == null)
            {
                label5.Hide();
                textBox5.Hide();
                label1.Text = lablet[0];
                label2.Text = lablet[1];
                label3.Text = lablet[2];
                label4.Text = lablet[3];
                label5.Text = lablet[4];           
            }
            else
            {
                label5.Show();
                textBox5.Show();
                label1.Text = lablet[0];
                label2.Text = lablet[1];
                label3.Text = lablet[2];
                label4.Text = lablet[3];
                label5.Text = lablet[4];
            }
            lablet[4] = null;
        }

        private void addbut_Click(object sender, EventArgs e)
        {

           
            Database data = new Database();
            try
            {
                if (label5.Text == "")
                {
                    Database.adding(textBox1.Text, textBox2.Text,
                        textBox3.Text, textBox4.Text, label1.Text, label2.Text, label3.Text, label4.Text);
                }
                else
                {
                    Database.adding(textBox1.Text, textBox2.Text,
                        textBox3.Text, textBox4.Text, textBox5.Text, label1.Text, label2.Text, label3.Text, label4.Text, label5.Text);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка проверьте правильность введенных даных. " +
                    "Возможно идентификаторов, которые вы вводите не существует, " + ex.Message);
                return;
            }
            
            this.Hide();
           
            
        }
    }
}
