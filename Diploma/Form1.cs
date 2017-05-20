using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diploma
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public List<GasStation> GS = new List<GasStation>();
        public static GasStation GasStation;

        private void SetLabelGS(string text)
        {
            labelGS.Text = "" + text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = true;
            builder.DataSource = "localhost";
            builder.InitialCatalog = "AZS";
            GlobalConnection.SetSQLConnection(new SqlConnection(builder.ConnectionString));
            GlobalConnection.Connection.Open();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalConnection.Connection.Close();
        }
        private void butManageGS_Click(object sender, EventArgs e)
        {
            FormManageGS fManageGS = new FormManageGS(ref GasStation);
            fManageGS.ShowDialog();

            SetLabelGS(GasStation.Location + ", " + GasStation.Brand);
        }
        private void butCarCome_Click(object sender, EventArgs e)
        {

        }

        private void butCarLeave_Click(object sender, EventArgs e)
        {

        }

        private void butModeling_Click(object sender, EventArgs e)
        {

        }
    }
}
