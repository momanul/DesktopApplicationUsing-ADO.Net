using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace CRUDDesktopApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.BringToFront();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button1.Height;
            slidePanel.Top = button1.Top;
            userControl11.BringToFront();
        }

        private void ButtonCircular1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button2.Height;
            slidePanel.Top = button2.Top;
            userControl31.BringToFront();
            
        }

        private void BtnViewInfo_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnViewInfo.Height;
            slidePanel.Top = btnViewInfo.Top;
            infoUserControl1.BringToFront();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnAbout.Height;
            slidePanel.Top = btnAbout.Top;
            about1.BringToFront();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button5.Height;
            slidePanel.Top = button5.Top;
            productTableData2.BringToFront();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button6.Height;
            slidePanel.Top = button6.Top;
            categoriesControl21.BringToFront();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            crystalReportUserControl1.BringToFront();
            slidePanel.Height = button7.Height;
            slidePanel.Top = button7.Top;
        }
    }
}
