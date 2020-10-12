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
    public partial class signUp2Form : Form
    {
        string Sub,creditnum,passnum;
        int Money,AmountDue;
        int MaxUserID, NewUserID,MaxPayID,NewPayID;
        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        OracleConnection conn;
        string theDate;
        private void button2_Click(object sender, EventArgs e)
        {
            Insertuser();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            theDate = dateTimePicker1.Value.ToShortDateString();
            DateTime dt1 = DateTime.Parse(theDate);

            if (Sub == "Annually")
                theDate = dt1.AddDays(365).ToShortDateString();

            else if (Sub == "Monthly")
                theDate = dt1.AddDays(30).ToShortDateString();
            else if (Sub == "Weekly")
                theDate = dt1.AddDays(7).ToShortDateString();

            textBox5.Text = theDate;
        }

        public signUp2Form(string sub , int money,int Amount,string crednum)
        {
            InitializeComponent();
            this.Sub = sub;
            this.Money = money;
            this.AmountDue = Amount;
            this.creditnum = crednum;

            getUserID();
            getPaymentID();
        }


        public void getUserID()
        {

            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select MAx(UserID) from useraccount";
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MaxUserID = Convert.ToInt32(dr[0].ToString());
                    NewUserID = MaxUserID + 1;
                    
                }

                dr.Close();

            }


            catch (Exception e)
            {
                NewUserID = 1;
            }

            textBox4.Text = NewUserID.ToString();

        }



        public void getPaymentID()
        {

            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select MAx(paymentID) from payment";
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MaxPayID = Convert.ToInt32(dr[0].ToString());
                    NewPayID = MaxPayID + 1;

                }

                dr.Close();

            }


            catch (Exception e)
            {
                NewPayID = 1;
            }


        }






        public void Insertuser()
        {

            //Insert into Table USerAccount
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into USERACCOUNT Values (:userID,:UserName,:Userpass,:UserEmail,:UserPhone)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("userID", NewUserID);
                cmd.Parameters.Add("UserName", Nameuser.Text);
                cmd.Parameters.Add("Userpass", textBox3.Text);
                cmd.Parameters.Add("UserEmail", textBox1.Text);
                cmd.Parameters.Add("UserPhone", textBox2.Text);
                int u = cmd.ExecuteNonQuery();



            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "insert into payment values (:payID,:payExpDate,:payMethod,:payAmount,:subtype,:custID)";
                cmd1.CommandType = CommandType.Text;

                cmd1.Parameters.Add("payID", NewPayID);
                cmd1.Parameters.Add("payExpDate", textBox5.Text);
                cmd1.Parameters.Add("payMethod", payMethod.SelectedItem.ToString());
                cmd1.Parameters.Add("payAmount", AmountDue);
                cmd1.Parameters.Add("subtype", Sub);
                cmd1.Parameters.Add("custID", NewUserID);

                int p = cmd1.ExecuteNonQuery();



            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "update USERCREDIT set credit=:creditt where cardnumber = :crednum";
                cmd2.CommandType = CommandType.Text;

                int CreditNow = Money - AmountDue;

                cmd2.Parameters.Add("creditt", CreditNow);
                cmd2.Parameters.Add("crednum", creditnum);

                int c = cmd2.ExecuteNonQuery();


                if (u != -1 && p != -1 && c != -1)
                    MessageBox.Show("You have successfully registered");


        }

            catch (Exception e)
            {
                MessageBox.Show("Something went Wrong");
            }





}










private void signUp2Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }
    }
}
