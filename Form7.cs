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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private int PackageId;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Maryamm\Documents\Login.mdf;Integrated Security=True;Connect Timeout=30");
        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDataSet1.pkgtbl' table. You can move, or remove it, as needed.
            this.pkgtblTableAdapter.Fill(this.loginDataSet1.pkgtbl);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            GetPackageRecords();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PackageId = Convert.ToInt32(DGV1.SelectedRows[0].Cells[0].Value);
            Place.Text = DGV1.SelectedRows[0].Cells[1].Value.ToString();
            Adults.Text = DGV1.SelectedRows[0].Cells[2].Value.ToString();
            Children.Text = DGV1.SelectedRows[0].Cells[3].Value.ToString();
            Description.Text = DGV1.SelectedRows[0].Cells[4].Value.ToString();
            Amount.Text = DGV1.SelectedRows[0].Cells[5].Value.ToString();
            Days.Text = DGV1.SelectedRows[0].Cells[6].Value.ToString();
            Nights.Text = DGV1.SelectedRows[0].Cells[7].Value.ToString();
            Hotels.Text = DGV1.SelectedRows[0].Cells[8].Value.ToString();
            Transport.Text = DGV1.SelectedRows[0].Cells[9].Value.ToString();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand Cmd = new SqlCommand("INSERT INTO pkgtbl VALUES(@AddPlace,@NoAdults,@NoChildren,@Description,@StayAmount,@NoDays,@NoNights,@Hotels,@Transportation)", Con);
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.AddWithValue("@AddPlace", Place.Text);
                Cmd.Parameters.AddWithValue("@NoAdults", Adults.Text);
                Cmd.Parameters.AddWithValue("@NoChildren", Children.Text);
                Cmd.Parameters.AddWithValue("@Description", Description.Text);
                Cmd.Parameters.AddWithValue("@StayAmount", Amount.Text);
                Cmd.Parameters.AddWithValue("@NoDays", Days.Text);
                Cmd.Parameters.AddWithValue("@NoNights", Nights.Text);
                Cmd.Parameters.AddWithValue("@Hotels", Hotels.Text);
                Cmd.Parameters.AddWithValue("@Transportation", Transport.Text);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Added Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPackageRecords();
            }
           
        }
        private bool IsValid()
        {
            if(Place.Text==" ")
            {
                MessageBox.Show("Package name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (PackageId > 0)
            {
                SqlCommand Cmd = new SqlCommand("UPDATE pkgtbl SET AddPlace=@AddPlace,NoAdults=@NoAdults,NoChildren=@NoChildren,Description=@Description,StayAmount=@StayAmount,NoDays=@NoDays,NoNights=@NoNights,Hotels=@Hotels,Transportation=@Transportation WHERE PackageId=@PackageId", Con);
                Cmd.CommandType = CommandType.Text;
                Cmd.Parameters.AddWithValue("@AddPlace", Place.Text);
                Cmd.Parameters.AddWithValue("@NoAdults", Adults.Text);
                Cmd.Parameters.AddWithValue("@NoChildren", Children.Text);
                Cmd.Parameters.AddWithValue("@Description", Description.Text);
                Cmd.Parameters.AddWithValue("@StayAmount", Amount.Text);
                Cmd.Parameters.AddWithValue("@NoDays", Days.Text);
                Cmd.Parameters.AddWithValue("@NoNights", Nights.Text);
                Cmd.Parameters.AddWithValue("@Hotels", Hotels.Text);
                Cmd.Parameters.AddWithValue("@Transportation", Transport.Text);
                Cmd.Parameters.AddWithValue("@PackageId", this.PackageId);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Updated Successfully!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPackageRecords();
            }
            else
            {
                MessageBox.Show("Please Select a record", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (PackageId > 0)
            {
                SqlCommand Cmd = new SqlCommand("DELETE FROM pkgtbl WHERE PackageId=@PackageId", Con);
                Cmd.CommandType = CommandType.Text;
                //Cmd.Parameters.AddWithValue("@PackageId", this.PackageId);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Deleted Successfully!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetPackageRecords();

            }

            else
            {
                MessageBox.Show("Please Select a record to delete", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            PackageId = 0;
            Place.Clear();
            Adults.Clear();
            Children.Clear();
            Description.Clear();
            Amount.Clear();
            Days.Clear();
            Nights.Clear();
            Hotels.Clear();
            Transport.Clear();
            Place.Focus();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 booking = new Form9();
            this.Hide();
            booking.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 cc = new Form10();
            this.Hide();
            cc.Show();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form2 bv = new Form2();
            this.Hide();
            bv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form13 img = new Form13();
            this.Hide();
            img.Show();
        }
    }
}
