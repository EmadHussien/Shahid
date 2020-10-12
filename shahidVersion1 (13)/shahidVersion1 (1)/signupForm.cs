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
    public partial class signupForm : Form
    {

        string  sub ;
        int  creditval=0 ,AmountDue=0,userID,ResubFlag;
         


        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        OracleConnection conn;

        public signupForm(int id)
        {
            InitializeComponent();
            userID = id;
            ResubFlag = 1;

        }
        public signupForm()
        {
            InitializeComponent();
            ResubFlag = 0;

        }



        public void signUP()
        {
           
            sub = SubType.SelectedItem.ToString();
            try
            {
                //// A4
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "GetCredit";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("cardnum", CreditNum.Text);
                cmd.Parameters.Add("cardsec", Password.Text);

                cmd.Parameters.Add("cn", OracleDbType.Int32, ParameterDirection.Output);
                cmd.Parameters.Add("pas", OracleDbType.Varchar2, 10, null, ParameterDirection.Output);
                cmd.Parameters.Add("cdt", OracleDbType.Int32, ParameterDirection.Output);

                cmd.ExecuteNonQuery();


           
                creditval = Convert.ToInt32(cmd.Parameters["cdt"].Value.ToString());

                    

            if (sub == "Annually" && creditval >= 349 || sub == "Monthly" && creditval >= 49 || sub == "Weekly" && creditval >= 14)
            {
                    if (sub == "Annually")
                        AmountDue = 349;
                    else if (sub == "Monthly")
                        AmountDue = 49;
                    else
                        AmountDue = 14;

                MessageBox.Show("You have Enough money to subscribe");
                   
            }
                        else
                            MessageBox.Show("You  do not have Enough money to subscribe");




                    


                }
                catch(Exception e)
                {
                    MessageBox.Show("Make sure You entered correct information");
                }





        }



        private void signupForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            signUP();

            if (ResubFlag == 0)
            {
                signUp2Form signup2Form = new signUp2Form(sub, creditval, AmountDue, CreditNum.Text);
                signup2Form.Show();

            }
            else if (ResubFlag == 1)
            {
                ReSub reSub = new ReSub(userID,creditval,AmountDue,CreditNum.Text,sub);
                reSub.Show();


            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
