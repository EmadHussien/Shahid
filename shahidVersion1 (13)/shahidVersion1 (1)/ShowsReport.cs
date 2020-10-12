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
    public partial class ShowsReport : Form
    {
        MoviesReport mr1;

        public ShowsReport()
        {
            InitializeComponent();
        }

        private void ShowsReport_Load(object sender, EventArgs e)
        {
            mr1 = new MoviesReport();
            crystalReportViewer1.ReportSource = mr1;



        }
    }
}
