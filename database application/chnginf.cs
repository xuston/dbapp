using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_application
{
    public partial class chnginf : Form
    {
        public string[] lablet = new string[5];
        public string[] textbt = new string[5];
        public string id;
        public string columnname;
        public chnginf()
        {
            InitializeComponent();
        }

        private void chnginf_Load(object sender, EventArgs e)
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
                textBox1.Text = textbt[0];
                textBox2.Text = textbt[1];
                textBox3.Text = textbt[2];
                textBox4.Text = textbt[3];
                textBox5.Text = textbt[4];
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
                textBox1.Text = textbt[0];
                textBox2.Text = textbt[1];
                textBox3.Text = textbt[2];
                textBox4.Text = textbt[3];
                textBox5.Text = textbt[4];
            }
            lablet[4] = null;
            textbt[4]= null;
        }

        private void addbut_Click(object sender, EventArgs e)
        {
            Database data = new Database();
            try
            {
                if (label5.Text == "")
                {
                    Database.changing(textBox1.Text, textBox2.Text,
                        textBox3.Text, textBox4.Text, label1.Text, label2.Text, label3.Text, label4.Text,id,columnname);
                }
                else
                {
                    Database.changing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, 
                        textBox5.Text, label1.Text, label2.Text, label3.Text, label4.Text, label5.Text,id,columnname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка проверьте правильность введенных даных, " + ex.Message);
                return;
            }

            this.Hide();




        }
    }
}
