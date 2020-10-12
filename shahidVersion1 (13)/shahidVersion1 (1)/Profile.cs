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
    public partial class Profile : Form
    {
        string Email;
        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        OracleConnection conn;

        public Profile(string email)
        {
            InitializeComponent();
            this.Email = email;
            Retrieve_UserData();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }



        public void Retrieve_UserData()
        {
            string date="";
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from useraccount where email=:mail";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("mail",Email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox4.Text = dr[0].ToString();
                Nameuser.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox1.Text = dr[3].ToString();
                textBox2.Text = dr[4].ToString();

            }
            cmd.Parameters.Clear();
            dr.Close();


            cmd.CommandText = "select PAYMENTEPXPIREDATE from payment where customerid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", textBox4.Text);
            OracleDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                date = dr1[0].ToString();

            }
            dr1.Close();
              String spearator = " 12:00:00 AM" ;
             date= date.Replace(spearator, "");

            
            textBox5.Text = date.ToString();




        }





        public void Userupdate()
        {

            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;

                cmd1.CommandText = "update USERACCOUNT set  username=:name , userpassword=:pass , email=:mail , phonenumber = :phone where USERID = :id";
                cmd1.CommandType = CommandType.Text;


                cmd1.Parameters.Add("name", Nameuser.Text);
                cmd1.Parameters.Add("pass", textBox3.Text);
                cmd1.Parameters.Add("mail", textBox1.Text);
                cmd1.Parameters.Add("phone", textBox2.Text);
                cmd1.Parameters.Add("id", textBox4.Text);

                int r = cmd1.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("User Updated Successfully");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }

        }



        public void UserDelete()
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;


                cmd1.CommandText = "Delete from PAYMENT  where CUSTOMERID = :id";
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("id", textBox4.Text);
                cmd1.ExecuteNonQuery();


                cmd1.Parameters.Clear();


                cmd1.CommandText = "Delete from FAVORITELIST  where CUSTOMERID = :id";
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("id", textBox4.Text);
                cmd1.ExecuteNonQuery();


                cmd1.Parameters.Clear();


                cmd1.CommandText = "Delete from USERACCOUNT  where USERID = :id";
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("id", textBox4.Text);

                int r = cmd1.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("User Deleted  Successfully");
                    this.Hide();
                }
        }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }




}




private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home(1);
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Userupdate();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            UserDelete();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FavoriteList favorite = new FavoriteList(Convert.ToInt32(textBox4.Text));
            favorite.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SuggestActors suggestActors = new SuggestActors();
            suggestActors.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowRate showRate = new ShowRate();
            showRate.Show();
        }
    }
}
