using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace shahidVersion1
{
    public partial class detailsForm : Form
    {

        // Shows show = new Shows();
        int ID = 0;
        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        OracleConnection conn;

        public detailsForm(int id)
        {
            InitializeComponent();
            ID= id;
            ShowActor();

        }



        public void ShowActor()
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select showtitle, rating, releasedate, contentgenre from tvshows sh join shows_genre ge on sh.showid = ge.showid join genre g on ge.genreid = g.genreid where sh.showid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id",ID.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox4.Text = dr[0].ToString();
                textBox3.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox1.Text = dr[1].ToString();

            }
            cmd.Parameters.Clear();
            dr.Close();



            cmd.CommandText = "select name from tvshows sh join shows_genre ge on sh.showid = ge.showid join genre g on ge.genreid = g.genreid join shows_actors sa on sh.showid = sa.showid join actors ac on ac.actorid = sa.actorid where sh.showid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", ID.ToString());
            OracleDataReader de = cmd.ExecuteReader();
            while (de.Read())
            {
                comboBox1.Items.Add(de[0]);

            }
            de.Close();


        }



        private void detailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
