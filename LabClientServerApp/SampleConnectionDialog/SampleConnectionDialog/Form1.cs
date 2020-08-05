using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleConnectionDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            Microsoft.Data.ConnectionUI.DataConnectionDialog _dialog = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
            Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(_dialog);
            Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(_dialog);
            txtString.Text = "ConnectionString: " + _dialog.ConnectionString;
        }
    }
}
