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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form9_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            GetPackageRecords();
        }
        private void GetPackageRecords()
        {
            SqlCommand Cmd = new SqlCommand("Select * from Bookingtbl", Con);
            DataTable dtt = new DataTable();
            Con.Open();
            SqlDataReader sdr = Cmd.ExecuteReader();
            dtt.Load(sdr);
            Con.Close();
            DGV1.DataSource = dtt;
        }
        private void DGV1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form7 add = new Form7();
            this.Hide();
            add.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form10 cc = new Form10();
            this.Hide();
            cc.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
