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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");
    
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }
        private void GetPackageRecords()
        {
            SqlCommand Cmd = new SqlCommand("Select * from pkgtbl", Con);
            DataTable dtt = new DataTable();
            Con.Open();
            SqlDataReader sdr = Cmd.ExecuteReader();
            dtt.Load(sdr);
            Con.Close();
            DGV1.DataSource = dtt;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            GetPackageRecords();

        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 book = new Form8();
            this.Hide();
            book.Show();


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
    }
}
