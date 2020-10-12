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
    public partial class FavoriteList : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        DataTable table = new DataTable();
        int ShowID;




        string ordb = "DATA SOURCE=localhost:1521/orcl;USER ID=HR ;Password=hr;";
        OracleConnection conn;
        int MaxListID, NewListID,Custid;
        string ShwTitle,genre;
       

        public FavoriteList(int CustID)
        {
            InitializeComponent();
            Custid = CustID;
            getListID();

            // LoadInfo();
        }



        private void FavoriteList_Load(object sender, EventArgs e)
        {
            table.Columns.Add("List ID", typeof(int));
            table.Columns.Add("Show Title", typeof(string));
            table.Columns.Add("Genre", typeof(string));
            table.Columns.Add("UserID", typeof(int));
            dataGridView1.DataSource = table;

            //// B2

            string query1 = "select SHOWTITLE from TVSHOWS";
             adapter = new OracleDataAdapter(query1, ordb);
            ds = new DataSet();
            adapter.Fill(ds);

            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "showtitle";


            string query = "select * from FAVORITELIST where CUSTOMERID=:id";

            adapter = new OracleDataAdapter(query, ordb);
            adapter.SelectCommand.Parameters.Add("id", Custid);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name], ListSortDirection.Ascending);

        }


        private void geTshwID()
        {
            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select SHOWID from TVSHOWS where SHOWTITLE=:shwtitle";

            c.CommandType = CommandType.Text;

            ////////////////
            DataRowView oDataRowView = comboBox1.SelectedItem as DataRowView;
            string title = "";

            if (oDataRowView != null)
            {
                title = oDataRowView.Row[comboBox1.DisplayMember] as string;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            geTshwID();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShwTitle = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            string query = "select g.contentgenre from genre g join shows_genre sh_g on g.genreid = sh_g.genreid join tvshows sh on sh.showid = sh_g.showid where sh.showtitle = :showtitle";


            OracleDataAdapter adapter2 = new OracleDataAdapter(query, ordb);
            adapter2.SelectCommand.Parameters.Add("showtitle", ShwTitle);
            DataSet ds1 = new DataSet();
            adapter2.Fill(ds1);
            genre = ds1.Tables[0].Rows[0]["contentgenre"].ToString();

            NewListID += 1;



            // add columns to datatable


            // add rows to datatable

            //DataTable dtbl = new DataTable();
            //DataRow row;
            //row = dtbl.NewRow();
            //row["CONTENTID"] = 7;
            //row["CONTENTNAME"] = "ELKEF";
            //row["CONTENTGENRE"] = "DRAMA";
            //row["CUSTOMERID"] = 1;

            //dataGridView1.DataSource = dtbl;


            

            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView1.DataSource;

            DataRow row = dt.NewRow();

            row[0] = NewListID.ToString();
            row[1] = ShwTitle.ToString();
            row[2] = genre.ToString();
            row[3] = Custid.ToString();


            dt.Rows.Add(row);
            // dataGridView1.Rows.Add(7, "alKEf", "DRAMA", 1);





            //  dataGridView1.Rows.Add(NewListID, ShwTitle, genre, Custid);

        }

        public void getListID()
        {


            try
            {
                ////////////// A1
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "select Max(CONTENTID) from FAVORITELIST";
                cmd1.CommandType = CommandType.Text;
                //  cmd.Parameters.Add("id", Custid);


                OracleDataReader drr = cmd1.ExecuteReader();
                if (drr.Read())
                {
                    NewListID = Convert.ToInt32(drr[0].ToString());
                    //NewListID = MaxListID + 1;

                }

            }
            catch (Exception)
            {
                NewListID = 0;
            }




        }



       

        private void button1_Click(object sender, EventArgs e)
        {
            //// B3
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);


            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into FAVORITE_SHOWS values(:showid , :contentid)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("showid", ShowID.ToString());
            cmd.Parameters.Add("contentid", NewListID.ToString());

            cmd.ExecuteReader();








            MessageBox.Show("Your Data Save Successfully");
        }







        //public void LoadInfo()
        //{

           

        //}





    }
}
