using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace HRBS_PROJECT_SDP_200
{
    public partial class Reservation_Form : Form
    {
        public Reservation_Form()
        {
            InitializeComponent();
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlquerylocation = "Select * From location";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquerylocation, sqlconn);
            sqlconn.Open();
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Location_name";
            comboBox1.ValueMember = "L_ID";
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox1.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryhotel = "Select * From hotel Where L_ID=@L_ID";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryhotel, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@L_ID",comboBox1.SelectedValue.ToString());
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Hotel_name";
            comboBox2.ValueMember = "H_ID";
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox1.Enabled = false;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryroom = "Select * From room Where H_ID=@H_ID";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryroom, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@H_ID", comboBox2.SelectedValue.ToString());
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "Room_Price";
            comboBox3.ValueMember = "R_ID";
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = false;
            textBox1.Enabled = false;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection sqlconn = new MySqlConnection(mainconn);
            string sqlqueryamount = "Select * From amount Where R_ID=@R_ID";
            MySqlCommand sqlcomm = new MySqlCommand(sqlqueryamount, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@R_ID", comboBox3.SelectedValue.ToString());
            MySqlDataAdapter sdr = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            comboBox4.DataSource = dt;
            comboBox4.DisplayMember = "Amount";
            comboBox4.ValueMember = "A_ID";
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            textBox1.Enabled = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand sqlcomm = new MySqlCommand("Select * From amount where amount = '" + comboBox4.Text + "'", mcon);
            mcon.Open();
            sqlcomm.ExecuteNonQuery();
            MySqlDataReader dr;
            dr = sqlcomm.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Enabled = true;
                string amount = (string)dr["amount"].ToString();
                textBox1.Text = amount;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mcon = new MySqlConnection("server=localhost;user id=root;database= hrbs;password=Chamak@Cse99515");
            MySqlCommand mcmd = new MySqlCommand(@"INSERT INTO reservation (Location, Hotel, Room, Amount, Check_in, Check_out, Day, Vehicle_Description, Members, Adults,Children, Full_Name, Mobile_No, NID, Email_Address, Room_Amount, Total_Amount)
            VALUES('" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "' , '" + dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "','" + textBox2.Text + "','" + richTextBox1.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "' , '" + textBox7.Text + "' , '" + textBox8.Text + "' , '" + textBox9.Text + "','" + textBox1.Text + "','" + textBox10.Text + "')", mcon);
            mcon.Open();
            mcmd.ExecuteNonQuery();
            mcon.Close();
            MessageBox.Show("Reservation Successful");
            this.Hide();
            Payment_Form pf = new Payment_Form(textBox10.Text);
            pf.Show();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Reservation_Form_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime sdt = dateTimePicker1.Value.Date;
            DateTime edt = dateTimePicker2.Value.Date;

            TimeSpan ts = edt - sdt;
            int days = ts.Days;
            textBox2.Text = days.ToString()+"";

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox10.Text = (float.Parse(textBox1.Text) * float.Parse(textBox2.Text)).ToString();
            }
            catch
            {

            }
        }
        private void label16_Click(object sender, EventArgs e)
        {
           

            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

