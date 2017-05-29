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
    public partial class FormShowServicing : Form
    {
        private GasStation GS;

        public FormShowServicing(GasStation gs)
        {
            InitializeComponent();
            GS = gs;
        }

        private void FormShowServicing_Load(object sender, EventArgs e)
        {
            GlobalConnection.ExecReader("select * from servicing where gas_deliver_id in (select id from gas_deliver where gas_station_id = " + GS.ID + ")" );

            for (int j = 0; j < GlobalConnection.Reader.FieldCount; j++)
            {
                dgvServicing.Columns.Add(GlobalConnection.Reader.GetName(j), GlobalConnection.Reader.GetName(j));
            }
            if (GlobalConnection.Reader.HasRows)
            {
                for (int i = 0; GlobalConnection.Reader.Read(); i++)
                {
                    dgvServicing.Rows.Add();
                    for (int j = 0; j < GlobalConnection.Reader.FieldCount; j++)
                    {
                        dgvServicing.Rows[i].Cells[j].Value = GlobalConnection.Reader[j];
                    }
                }
            }

            GlobalConnection.Reader.Close();
        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            GlobalConnection.ExecReader("select * from servicing where gas_deliver_id in (select id from gas_deliver where gas_station_id = " + GS.ID + ")");

            dgvServicing.Columns.Clear();
            dgvServicing.Refresh();
            for (int j = 0; j < GlobalConnection.Reader.FieldCount; j++)
            {
                dgvServicing.Columns.Add(GlobalConnection.Reader.GetName(j), GlobalConnection.Reader.GetName(j));
            }
            if (GlobalConnection.Reader.HasRows)
            {
                for (int i = 0; GlobalConnection.Reader.Read(); i++)
                {
                    dgvServicing.Rows.Add();
                    for (int j = 0; j < GlobalConnection.Reader.FieldCount; j++)
                    {
                        dgvServicing.Rows[i].Cells[j].Value = GlobalConnection.Reader[j];
                    }
                }
            }

            GlobalConnection.Reader.Close();
        }
    }
}
