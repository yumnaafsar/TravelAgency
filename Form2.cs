using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            Form6 user = new Form6();
            user.Show();
            this.Hide();
        }



        private void gunaCircleButton4_Click(object sender, EventArgs e)
        {
            Form11 con = new Form11();
            this.Hide();
            con.Show();
        }
        private int imageNumber = 1;
        private void LoadNextImage() {
            if (imageNumber ==14)
            {
                imageNumber = 1;
            }
            SlidePic.ImageLocation = string.Format(@"C:/Users/Maryamm/Images/{0}.jfif", imageNumber);
            imageNumber++;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Parent = panel2;
            label2.BackColor = Color.Transparent;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Parent = SlidePic;
            panel2.BackColor = Color.FromArgb(100,0,0,0);
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Form3 user = new Form3();
            user.Show();
            this.Hide();
        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        {
            Form12 n = new Form12();
            this.Hide();
            n.Show();
        }
    }
}
