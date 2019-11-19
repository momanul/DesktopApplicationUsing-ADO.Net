using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDDesktopApplication
{
    public partial class UserDecisionControl : UserControl
    {
        public UserDecisionControl()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            productTableData1.BringToFront();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            categoriesControl21.BringToFront();
        }
    }
}
