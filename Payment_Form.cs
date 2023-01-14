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
    public partial class Payment_Form : Form
    {
        public Payment_Form(string Str_Value)
        {
            InitializeComponent();
            textBox1.Text = Str_Value;
            textBox1.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            bKash_Form bf = new bKash_Form(textBox4.Text);
            bf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nagad_Form nf = new Nagad_Form(textBox4.Text);
            nf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Payment_Form_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = (float.Parse(textBox1.Text) * 1).ToString();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = ((float.Parse(textBox1.Text) * 35)/100).ToString();
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
