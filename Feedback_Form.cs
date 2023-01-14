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
    public partial class Feedback_Form : Form
    {
        public Feedback_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand mcmd = new MySqlCommand(@"INSERT INTO feedback (feedback)
            VALUES('" + richTextBox1.Text + "')", mcon);
            mcon.Open();
            mcmd.ExecuteNonQuery();
            mcon.Close();
            MessageBox.Show("Successful");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
