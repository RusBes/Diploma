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
        private int selectedGSID;
        private List<GasStation> GS;
        public FormManageGS(List<GasStation> gs)
        {
            InitializeComponent();

            GS = gs;
            _isInsertNeeded = false;
        }

        private void SetDgvGSColumns()
        {
            dgvGS.Columns.Add("", "");
            dgvGS.Columns.Add("", "");
            dgvGS.Columns.Add("", "");
        }
        private void SetDgvGasDeliverColumns()
        {
            dgvGasDeliveries.Columns.Add("", "");

            List<string> tmp = Enum.GetNames(typeof(GasDeliverType)).ToList();
            tmp.RemoveAt(tmp.Count - 1);
            tmp.Add("");
            dgvGasDeliveries.Columns.Add(new DataGridViewComboBoxColumn() { DataSource = tmp });

            dgvGasDeliveries.Columns.Add("", "");
        }
        private void SetDgvStaffColumns()
        {
            dgvStaff.Columns.Add("", "");
            dgvStaff.Columns.Add("", "");

            List<string> tmp = Enum.GetNames(typeof(EmployeePosition)).ToList();
            tmp.RemoveAt(tmp.Count - 1);
            tmp.Add("");
            dgvStaff.Columns.Add(new DataGridViewComboBoxColumn() { DataSource = tmp });

            dgvStaff.Columns.Add("", "");
        }
        private void FillDGVFromReader(DataGridView dgv)
        {
            SqlDataReader reader = GlobalConnection.Reader;
            // clear dgv and set column names
            dgv.Rows.Clear();
            //dgv.ColumnCount = reader.FieldCount;
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
        private void HighlightSelectedGS()
        {
            foreach (DataGridViewRow row in dgvGS.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            foreach (DataGridViewCell cell in dgvGS.Rows[selectedGSID].Cells)
            {
                cell.Style.BackColor = Color.LightGreen;
            }
        }

        private void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Context.ToString());
        }
        private void FormManageGS_Load(object sender, EventArgs e)
        {
            SetDgvGSColumns();
            SetDgvGasDeliverColumns();
            SetDgvStaffColumns();

            dgvGasDeliveries.DataError += Dgv_DataError;
            dgvStaff.DataError += Dgv_DataError;

            dgvGS.RowHeaderMouseDoubleClick += DgvGS_RowHeaderMouseDoubleClick;
            dgvGS.CellEndEdit += DgvGS_CellEndEdit;
            dgvGasDeliveries.CellEndEdit += dgvGasDeliveriesCellEndEdit; ;
            dgvStaff.CellEndEdit += dgvStaffCellEndEdit;
            dgvGS.RowsAdded += dgvRowsAdded;
            dgvGasDeliveries.RowsAdded += dgvRowsAdded;
            dgvStaff.RowsAdded += dgvRowsAdded;

            string selectGS = "select * from gas_station";
            GlobalConnection.ExecReader(selectGS);
            FillDGVFromReader(dgvGS);
            GlobalConnection.CloseReader();
        }
        private void DgvGS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_isInsertNeeded)        // if there is new line added insert new line into database, else update this line
            {
                GlobalConnection.InsertGasStation(
                    dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
                    dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "");
                _isInsertNeeded = false;
            }
            else
            {
                GlobalConnection.UpdateGasStation(
                    dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
                    dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "",
                    Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value));
            }
        }
        private void dgvGasDeliveriesCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_isInsertNeeded)        // if there is new line added insert new line into database, else update this line
            {
                GlobalConnection.InsertGasDeliver(
                    dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value != null ? 
                            ((GasDeliverType)Enum.Parse(typeof(GasDeliverType), dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value.ToString())) : 
                            GasDeliverType.None,
                    Convert.ToInt32(dgvGasDeliveries.Rows[e.RowIndex].Cells[2].Value));
                _isInsertNeeded = false;
            }
            else
            {
                GlobalConnection.UpdateGasDeliver(
                    dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value != null ?
                            ((GasDeliverType)Enum.Parse(typeof(GasDeliverType), dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value.ToString())) :
                            GasDeliverType.None,
                    Convert.ToInt32(dgvGasDeliveries.Rows[e.RowIndex].Cells[2].Value),
                    Convert.ToInt32(dgvGasDeliveries.Rows[e.RowIndex].Cells[0].Value));
            }
        }
        private void dgvStaffCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_isInsertNeeded)        // if there is new line added insert new line into database, else update this line
            {
                GlobalConnection.InsertGasStation(
                    dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
                    dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "");
                _isInsertNeeded = false;
            }
            else
            {
                GlobalConnection.UpdateGasStation(
                    dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
                    dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "",
                    Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value));
            }
        }
        bool _isInsertNeeded;
        private void dgvRowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            dgv.Rows[e.RowIndex].Cells[0].ReadOnly = true;
            if (e.RowIndex == dgv.RowCount - 1 && dgv.RowCount != 1) // this strange condition calculated by set of experiments
            {
                dgvGS.Rows[e.RowIndex - 1].Cells[0].Value = e.RowIndex - 1;
                _isInsertNeeded = true;
            }
            else
            {

            }
        }
        private void DgvGS_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string GSid;
            GSid = dgvGS.Rows[e.RowIndex].Cells[0].Value.ToString();
            string selectGasDelivers = "select * from gas_deliver where gas_deliver.gas_station_id = " + GSid;
            GlobalConnection.ExecReader(selectGasDelivers);
            FillDGVFromReader(dgvGasDeliveries);
            GlobalConnection.CloseReader();

            string selectStaff = "select * from staff where staff.gas_station_id = " + GSid;
            GlobalConnection.ExecReader(selectStaff);
            FillDGVFromReader(dgvStaff);
            GlobalConnection.CloseReader();

            selectedGSID = Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value);
            HighlightSelectedGS();

            groupboxColumns.Visible = true;
            groupboxStaff.Visible = true;
        }
        private void FormManageGS_FormClosing(object sender, FormClosingEventArgs e)
        {
            GS = new List<GasStation>();
            for (int i = 0; i < dgvGS.RowCount; i++)
            {
                GS.Add(new GasStation(Convert.ToInt32(dgvGS.Rows[i].Cells[0].Value),
                    Convert.ToString(dgvGS.Rows[i].Cells[1].Value),
                    Convert.ToString(dgvGS.Rows[i].Cells[2].Value)));
            }
        }
    }
}
