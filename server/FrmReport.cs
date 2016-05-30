using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace server
{
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            cbxReoprt.SelectedIndex = 0;
        }

        private void cbxReoprt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string report = "无适配器报表";
            if (cbxReoprt.SelectedIndex == 0)
            {
                NetworkAdapterUtil adapter = new NetworkAdapterUtil();
                report = adapter.ReportByAdapters(adapter.GetEthernetWirelessNetworkAdaptersUP());
            }
            else if (cbxReoprt.SelectedIndex == 1)
            {
                NetworkAdapterUtil adapter = new NetworkAdapterUtil();
                report = adapter.ReportByAdapters(adapter.GetAllNetworkAdapters());
            }
            txtReport.Text = report;
            txtReport.SelectionStart = 0;
        }
    }
}
