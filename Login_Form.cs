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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand mcmd = new MySqlCommand("select count(*) From registration_login Where Email_Address='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", mcon);
            MySqlDataAdapter msda = new MySqlDataAdapter(mcmd);
            DataTable dt = new DataTable();
            msda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Reservation_Form rf = new Reservation_Form();
                rf.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration_Form r2f = new Registration_Form();
            r2f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                button5.BringToFront();
                textBox2.PasswordChar = '\0';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                button4.BringToFront();
                textBox2.PasswordChar = '*';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
