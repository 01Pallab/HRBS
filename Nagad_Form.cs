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
    public partial class Nagad_Form : Form
    {
        public Nagad_Form(string Str_Value)
        {
            InitializeComponent();
            textBox1.Text = Str_Value;
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand mcmd = new MySqlCommand(@"INSERT INTO Nagad_Form (Amount, Nagad_Mobile_No, PIN)
              VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", mcon);

            mcon.Open();
            mcmd.ExecuteNonQuery();
            mcon.Close();
            MessageBox.Show("Payment Successful \nA message is sent to your Nagad Mobile No.");
            this.Hide();
            Feedback_Form ff = new Feedback_Form();
            ff.Show();
        }

    

 
        private void Nagad_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
