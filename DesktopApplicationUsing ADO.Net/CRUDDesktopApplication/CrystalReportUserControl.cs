using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryForCrystalReport;
using CrystalDecisions.CrystalReports.Engine;

namespace CRUDDesktopApplication
{
    public partial class CrystalReportUserControl : UserControl
    {
        public CrystalReportUserControl()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\Users\R-40\Desktop\ACRUDDesktopApplication\ClassLibraryForCrystalReport\Products.rpt");

            Class1 db = new Class1();
            rpt.SetDataSource(db.BindData());
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.RefreshReport();
        }
    }
}
