using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace sample1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox1;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            checkBox1.BackColor = Color.Transparent;
            gunaCircleButton1.Parent = pictureBox1;
            gunaCircleButton1.BackColor = Color.Transparent;
            gunaCircleButton1.BaseColor = Color.Transparent;
            gunaCircleButton1.BorderColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                PASSWORD.UseSystemPasswordChar = true;
            }
            else
            {
                PASSWORD.UseSystemPasswordChar = false;
            }
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "Insert into logintbl values('"+ USERNAME.Text+ "','" + PASSWORD.Text + "','" + GENDER.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully");
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 login = new Form3();
            this.Hide();
            login.Show();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form2 back = new Form2();
            this.Hide();
            back.Show();
        }
    }
}
