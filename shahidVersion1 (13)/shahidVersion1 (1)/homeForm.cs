using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shahidVersion1
{
    public partial class Home : Form
    {
        int Vipflag = 0;

        public Home(int vip)
        {
            InitializeComponent();

           // this.BackColor = Color.White;
           // panel1.BackColor = Color.FromArgb(180, Color.Black);
            this.Vipflag = vip;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(1,Vipflag);
            playform.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
           

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(2 ,Vipflag);
            playform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(3, Vipflag);
            playform.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(4,Vipflag);
            playform.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(5, Vipflag);
            playform.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(6, Vipflag);
            playform.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(7, Vipflag);
            playform.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(8, Vipflag);
            playform.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(9, Vipflag);
            playform.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(10, Vipflag);
            playform.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(11, Vipflag);
            playform.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            playForm playform = new playForm(12, Vipflag);
            playform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(1);
            detailsform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(2);
            detailsform.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(3);
            detailsform.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(4);
            detailsform.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(5);
            detailsform.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(6);
            detailsform.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(7);
            detailsform.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(8);
            detailsform.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(9);
            detailsform.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(10);
            detailsform.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(11);
            detailsform.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            detailsForm detailsform = new detailsForm(12);
            detailsform.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            ShowsReport showsReport = new ShowsReport();
            showsReport.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            signinForm signin = new signinForm();
            signin.Show();
        }
    }
}
