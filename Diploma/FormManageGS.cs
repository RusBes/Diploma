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
    public partial class FormManageGS : Form
    {
        public FormManageGS()
        {
            InitializeComponent();

            dgvGS.RowHeaderMouseDoubleClick += DgvGS_RowHeaderMouseDoubleClick;
            dgvGasDeliveries.RowHeaderMouseDoubleClick += DgvGS_RowHeaderMouseDoubleClick;
            dgvStaff.RowHeaderMouseDoubleClick += DgvGS_RowHeaderMouseDoubleClick;
            //groupboxColumns.Visible = false;
            //groupboxStaff.Visible = false;
        }

        private void FillDGVFromReader(SqlDataReader reader, DataGridView dgv)
        {
            // clear dgv and set columns
            dgv.Rows.Clear();
            dgv.ColumnCount = reader.FieldCount;
            for (int j = 0; j < reader.FieldCount; j++)
            {
                dgv.Columns[j].Name = reader.GetName(j);
            }
            dgv.Refresh();

            if (reader.HasRows)
            {
                // read data and fill dgv
                for (int i = 0; reader.Read(); i++)
                {
                    dgv.Rows.Add();
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        dgv.Rows[i].Cells[j].Value = reader.GetValue(j);
                    }
                }
            }
        }

        private void FormManageGS_Load(object sender, EventArgs e)
        {
            string selectGS = "select * from gas_station";
            GlobalConnection.ExecReader(selectGS);
            FillDGVFromReader(GlobalConnection.Reader, dgvGS);
            GlobalConnection.CloseReader();
        }
        private void DgvGS_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string GSid;
            GSid = dgvGS.Rows[e.RowIndex].Cells[0].Value.ToString();
            string selectGasDelivers = "select * from gas_deliver where gas_deliver.gas_station_id = " + GSid;
            GlobalConnection.ExecReader(selectGasDelivers);
            FillDGVFromReader(GlobalConnection.Reader, dgvGasDeliveries);
            GlobalConnection.CloseReader();

            //GSid = (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value.ToString();
            string selectStaff = "select * from staff where staff.gas_station_id = " + GSid;
            GlobalConnection.ExecReader(selectStaff);
            FillDGVFromReader(GlobalConnection.Reader, dgvStaff);
            GlobalConnection.CloseReader();
            

            groupboxColumns.Visible = true;
            groupboxStaff.Visible = true;
        }
        private void dgvGS_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            string[] updates = new string[dgv.RowCount - 1];
            for (int i = 0; i < updates.Length; i++)
            {
                updates[i] = "update gas_station set "
                        + " location = " + $"'{ dgv.Rows[i].Cells[1].Value }'"
                        + ", brand = " + $"'{ dgv.Rows[i].Cells[2].Value }'"
                        + " where id = " + dgv.Rows[i].Cells[0].Value;
                SqlCommand command = new SqlCommand(updates[i], GlobalConnection.Connection);
                command.ExecuteNonQuery();
            }

        }
    }
}
