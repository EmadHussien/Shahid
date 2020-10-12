using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace shahidVersion1
{
    public partial class signinForm : Form
    {
        //public signinForm()
        //{
        //    InitializeComponent();
        //}
        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        string emaildb;
        string passdb;
        string expDate;
        int userID;
        public signinForm()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            panel1.BackColor = Color.FromArgb(200, Color.Black);
            expDate = "1-1-98";
           
        }


        private void signinForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupForm signup = new signupForm();
            signup.Show();
        }


        public void Usersignin()
        {
            string query = "select  ua.email , ua.userpassword , pay.paymentepxpiredate,pay.customerid   from useraccount ua join payment pay ON ua.userid = pay.customerid ";
            try
            {
                OracleDataAdapter adapter = new OracleDataAdapter(query, ordb);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                for(int i=0; i<ds.Tables[0].Rows.Count;i++)
                {
                    if(ds.Tables[0].Rows[i]["email"].ToString()== textBox1.Text && ds.Tables[0].Rows[i]["userpassword"].ToString()== textBox2.Text)
                    {
                        emaildb = ds.Tables[0].Rows[i]["email"].ToString();
                        passdb = ds.Tables[0].Rows[i]["userpassword"].ToString();
                        expDate = ds.Tables[0].Rows[i]["paymentepxpiredate"].ToString();
                        userID = Convert.ToInt32(ds.Tables[0].Rows[i]["customerid"]);
                        break;

                    }
                }
                DateTime dt1 = DateTime.Parse(expDate);
                DateTime dt2 = DateTime.Now;

                if (textBox1.Text == emaildb && textBox2.Text == passdb)
                {
                    if (dt1.Date <= dt2.Date)
                    {
                        MessageBox.Show("Your Subscription ended");
                        signupForm signupform = new signupForm(userID);
                        signupform.Show();
                    }
                    else
                    {
                        MessageBox.Show("Welcome");
                        Profile profile = new Profile(emaildb);
                        profile.Show();
                    }


                }
                else if (textBox1.Text == "Admin@gmail.com" && textBox2.Text == "0000")
                {
                    MessageBox.Show("Welcome");
                    Admin admin = new Admin();
                    admin.Show();
                }
                else
                {
                    MessageBox.Show("Email or Password is Wrong");

                }




            }

            catch 
            {
                MessageBox.Show("Fields Cannot be Empty");

            }



        }


        


        private void button1_Click(object sender, EventArgs e)
        {



            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usersignin();

        }
    }
}
