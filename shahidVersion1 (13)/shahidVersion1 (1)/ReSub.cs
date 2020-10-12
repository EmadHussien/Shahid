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
    public partial class ReSub : Form
    {
        int UserID, Money, AmountDue , newMoney;
        string Creditnum ,  Sub,theDate;
        OracleConnection conn;
        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";

        private void button2_Click(object sender, EventArgs e)
        {
            newMoney = Money - AmountDue;




            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

               


                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "update payment set PAYMENTEPXPIREDATE=:payExpDate where CUSTOMERID=:custID";
                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.Add("payExpDate", textBox5.Text);
                cmd1.Parameters.Add("custID", UserID);

                int p = cmd1.ExecuteNonQuery();



                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "update USERCREDIT set credit=:creditt where cardnumber = :crednum";
                cmd2.CommandType = CommandType.Text;


                cmd2.Parameters.Add("creditt", newMoney);
                cmd2.Parameters.Add("crednum", Creditnum);

                int c = cmd2.ExecuteNonQuery();


                if (p != -1 && c != -1)
                    MessageBox.Show("Welcome Back");


            }

            catch 
            {
                MessageBox.Show("Something went Wrong");
            }








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
            textBox1.Text = AmountDue.ToString();
        }

        public ReSub(int uID,int money,int amountDue ,string creditNum , string sub)
        {
            InitializeComponent();
            this.UserID = uID;
            this.Money = money;
            this.AmountDue = amountDue;
            this.Creditnum = creditNum;
            this.Sub = sub;

        }

        private void ReSub_Load(object sender, EventArgs e)
        {

        }
    }
}
