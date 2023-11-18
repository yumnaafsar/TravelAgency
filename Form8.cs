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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");
        private bool IsValid()
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Package name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 package = new Form5();
            this.Hide();
            package.Show();

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand Cmd = new SqlCommand("INSERT INTO Bookingtbl VALUES(@PackageId,@DateDay,@Email,@ContactNo,@PaymentMethod,@CreditNo)", Con);
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.AddWithValue("@PackageId", textBox1.Text);
                Cmd.Parameters.AddWithValue("@DateDay", dateTimePicker1.Text);
                Cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                Cmd.Parameters.AddWithValue("@ContactNo", textBox3.Text);
                Cmd.Parameters.AddWithValue("@PaymentMethod",comboBox1.Text);
                Cmd.Parameters.AddWithValue("@CreditNo", textBox4.Text);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Booked Successfully!", "Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listBox1.Items.Add("                              ");
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Package Id:       "+ textBox1.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Date Of Travel:       " + dateTimePicker1.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Email:       " + textBox2.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Contact No:       " + textBox3.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Payment Method:       " + comboBox1.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("Credit Card No:       " + textBox4.Text);
                listBox1.Items.Add("                             ");
                listBox1.Items.Add("ENJOY YOUR TRAVEL!");
                listBox1.Items.Add("AMY WISHES YOU AMAZING TOUR.");
                listBox1.Items.Add("DON'T FORGET TO BRING THIS AT THE TIME ");
                listBox1.Items.Add("OF ARRIVING AT OUR COMPANY :)");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedItem = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form2 bv = new Form2();
            this.Hide();
            bv.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form14 img = new Form14();
            this.Hide();
            img.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
