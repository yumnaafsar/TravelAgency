using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sample1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from admintbl Where USERNAME='" + textBox1.Text + "'and PASSWORD ='" + textBox2.Text + "' and GENDER ='" + comboBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select GENDER from admintbl Where USERNAME='" + textBox1.Text + "'and PASSWORD ='" + textBox2.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "FEMALE")
                {
                    Form7 open = new Form7();
                    open.Show();
                    this.Hide();
                }
                else
                {
                    Form7 open = new Form7();
                    open.Show();
                    this.Hide();
                }


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox1;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            gunaCircleButton1.Parent = pictureBox1;
            gunaCircleButton1.BackColor = Color.Transparent;
            gunaCircleButton1.BaseColor = Color.Transparent;
            gunaCircleButton1.BorderColor = Color.Transparent;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();
            this.Hide();
            back.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
