using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRBS_PROJECT_SDP_200
{
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.PasswordChar == '*')
            {
                button5.BringToFront();
                textBox5.PasswordChar = '\0';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.PasswordChar == '\0')
            {
                button4.BringToFront();
                textBox5.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand mcmd = new MySqlCommand(@"INSERT INTO registration_login (first_name, last_name, mobile_no, email_address, password)
              VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", mcon);

            mcon.Open();
            mcmd.ExecuteNonQuery();
            mcon.Close();
            MessageBox.Show("Register Successfully");
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
