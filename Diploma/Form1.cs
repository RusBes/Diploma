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
            FormManageGS fManageGS = new FormManageGS();
            fManageGS.Show();
        }
    }
}
