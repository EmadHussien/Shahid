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
    public partial class Admin : Form
    {
        AdminReport ad; 

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ad = new AdminReport();
            crystalReportViewer1.ReportSource = ad;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
