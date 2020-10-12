using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace shahidVersion1
{
    public partial class ShowRate : Form
    {
        ShowsRatingrpt SR1;

        public ShowRate()
        {
            InitializeComponent();
        }

        private void ShowRate_Load(object sender, EventArgs e)
        {
            SR1 = new ShowsRatingrpt();

            foreach (ParameterDiscreteValue v in SR1.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SR1.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = SR1;
        }
    }
}
