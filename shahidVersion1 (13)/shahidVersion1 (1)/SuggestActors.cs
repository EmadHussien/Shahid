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
    public partial class SuggestActors : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        OracleConnection conn;
        int ShowID,ActorID;

        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";

        public SuggestActors()
        {
            InitializeComponent();
        }

        private void comboRefresh()
        {

            comboBox1.Items.Clear();

            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            //cmd.CommandText = "select ActorID from Actors";
            //cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Actor_IDs";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("ID",OracleDbType.RefCursor,ParameterDirection.Output);
            


            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();





        }


        private void SuggestActors_Load(object sender, EventArgs e)
        {


            comboRefresh();






            ////////////////// A1
            string query1 = "select SHOWID, SHOWTITLE from TVSHOWS";
            adapter = new OracleDataAdapter(query1, ordb);
            ds = new DataSet();
            adapter.Fill(ds);

            comboBox2.DataSource = ds.Tables[0];
            comboBox2.DisplayMember = "showtitle";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select name,age from Actors where ActorID=:id";
            c.CommandType = CommandType.Text;
            ActorID = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            c.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
            dr.Close();

            c.Parameters.Clear();
            /////////////////////////
            c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = " select sh.showtitle from tvshows sh join shows_actors sa  on sh.showid = sa.showid  join actors ac  on ac.actorid = sa.actorid where ac.actorid =:ActorID";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("ActorID", comboBox1.SelectedItem.ToString());
            OracleDataReader dr1 = c.ExecuteReader();
            if (dr1.Read())
            {
                comboBox2.Text = dr1[0].ToString();
            }
            dr1.Close();

            geTshwID();











        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERTACTOR";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ID", comboBox1.Text);
                cmd.Parameters.Add("Name", textBox1.Text);
                cmd.Parameters.Add("Age", textBox2.Text);
                cmd.ExecuteNonQuery();
                ///////// insert into showActors tabel
                cmd.Parameters.Clear();

                conn = new OracleConnection(ordb);
                conn.Open();

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into SHOWS_ACTORS values (:showID , :ActorID)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("showID", ShowID);
                cmd.Parameters.Add("ActorID",comboBox1.Text);

                cmd.ExecuteReader();
                comboRefresh();





                MessageBox.Show("Actor Added Successfully");
            }
            catch(Exception f)
            {
                MessageBox.Show("Fields Cannot be Empty");
            }











            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE_ACTORS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ID", comboBox1.SelectedItem.ToString());
                cmd.Parameters.Add("Name", textBox1.Text);
                cmd.Parameters.Add("Age", textBox2.Text);
                cmd.ExecuteNonQuery();
                ///////// insert into showActors tabel

                comboRefresh();


                MessageBox.Show("Actor Updated Successfully");
            }
            catch (Exception f)
            {
                MessageBox.Show("Fields Cannot be Empty");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {

                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from SHOWS_ACTORS where SHOWID=:showID AND ACTORID=:ActorID";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("showID", ShowID.ToString());
                cmd.Parameters.Add("ActorID", comboBox1.SelectedItem.ToString());

                cmd.ExecuteReader();

             
                ///////// insert into showActors tabel
                cmd.Parameters.Clear();
                conn = new OracleConnection(ordb);
                conn.Open();

                 cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE_ACTORS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ID", comboBox1.SelectedItem.ToString());

                cmd.ExecuteNonQuery();

                comboRefresh();





                MessageBox.Show("Actor Deleted Successfully");
            }
            catch (Exception f)
            {
                MessageBox.Show("Fields Cannot be Empty");
            }











        }


        private void geTshwID()
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select SHOWID from TVSHOWS where SHOWTITLE=:shwtitle";

            c.CommandType = CommandType.Text;

            ////////////////
            DataRowView oDataRowView = comboBox2.SelectedItem as DataRowView;
            string title = "";

            if (oDataRowView != null)
            {
                title = oDataRowView.Row[comboBox2.DisplayMember] as string;
            }
            ////////////////////
            c.Parameters.Add("shwtitle", title);
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                ShowID = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();


        }
     


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            geTshwID();

        }
    }
}
