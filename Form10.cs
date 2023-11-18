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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form10_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            GetPackageRecords();
        }
        private void GetPackageRecords()
        {
            SqlCommand Cmd = new SqlCommand("Select * from logintbl", Con);
            DataTable dtt = new DataTable();
            Con.Open();
            SqlDataReader sdr = Cmd.ExecuteReader();
            dtt.Load(sdr);
            Con.Close();
            DGV1.DataSource = dtt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form7 bb = new Form7();
            this.Hide();
            bb.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form9 nn = new Form9();
            this.Hide();
            nn.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
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
            Form13 img = new Form13();
            this.Hide();
            img.Show();
        }
    }
}
