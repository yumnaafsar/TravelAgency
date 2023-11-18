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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;");
        string imageUrl = null;
        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDataSet.imgtbl' table. You can move, or remove it, as needed.
            this.imgtblTableAdapter.Fill(this.loginDataSet.imgtbl);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd=new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr=(byte[])converter.ConvertTo(img,typeof(byte[]));
            Con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO imgtbl (Id,Photo,PhotoUrl) VALUES (@Id,@Photo,@PhotoUrl)", Con);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@Photo", arr);
            cmd.Parameters.AddWithValue("@PhotoUrl", imageUrl);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product Saved");

            SqlCommand cmd2 = new SqlCommand("select * from imgtbl", Con);
            DataTable dt = new DataTable();
            dt.Load(cmd2.ExecuteReader());
            dataGridView1.DataSource = dt;
            Con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Click Package image to delete");

                }
                else
                {
                    Con.Open();
                    string query = "delete from imgtbl where Id=" + textBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Package image deleted successfully");
                    Con.Close();
                    GetPackageRecords();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetPackageRecords()
        {
            SqlCommand Cmd = new SqlCommand("Select * from imgtbl", Con);
            DataTable dtt = new DataTable();
            Con.Open();
            SqlDataReader sdr = Cmd.ExecuteReader();
            dtt.Load(sdr);
            Con.Close();
            dataGridView1.DataSource = dtt;
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form7 bk = new Form7();
            this.Hide();
            bk.Show();
        }
    }
}
