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
        public GasStation GasStation;

        private int selectedGSID;
        public FormManageGS(ref GasStation gs)
        {
            InitializeComponent();
            GasStation = gs;

            ContextMenuStrip cmsGS = new ContextMenuStrip();
            cmsGS.Items.Add("Добавити АЗС");
            cmsGS.Items[0].Click += AddGS_Click;
            dgvGS.ContextMenuStrip = cmsGS;

            ContextMenuStrip cmsGasDel = new ContextMenuStrip();
            cmsGasDel.Items.Add("Добавити колонку");
            cmsGasDel.Items[0].Click += AddGasDeliver_Click;
            dgvGasDeliveries.ContextMenuStrip = cmsGasDel;

            //ContextMenuStrip cmsEmp = new ContextMenuStrip();
            //cmsEmp.Items.Add("Добавити співробітника");
            //cmsEmp.Items[0].Click += AddEmployee_Click;
            //dgvStaff.ContextMenuStrip = cmsEmp;


            //_isInsertNeeded = false;
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
            dgvGasDeliveries.Columns.Add("", "");

            //List<string> tmp = Enum.GetNames(typeof(GasDeliverType)).ToList();
            //tmp.RemoveAt(tmp.Count - 1);
            //tmp.Add("");
            //dgvGasDeliveries.Columns.Add(new DataGridViewComboBoxColumn() { DataSource = tmp });

            dgvGasDeliveries.Columns.Add("", "");
        }
        //private void SetDgvStaffColumns()
        //{
        //    dgvStaff.Columns.Add("", "");
        //    dgvStaff.Columns.Add("", "");
        //    dgvStaff.Columns.Add("", "");

        //    //List<string> tmp = Enum.GetNames(typeof(EmployeePosition)).ToList();
        //    //tmp.RemoveAt(tmp.Count - 1);
        //    //tmp.Add("");
        //    //dgvStaff.Columns.Add(new DataGridViewComboBoxColumn() { DataSource = tmp });

        //    dgvStaff.Columns.Add("", "");
        //}
        private void FillDGVFromList(DataGridView dgv, List<object[]> list) // need to finish
        {
            dgv.Rows.Clear();
            dgv.Refresh();

            for (int i = 0; i < list.Count; i++)
            {
                dgv.Rows.Add();
                for (int j = 0; j < list[0].Length; j++)
                {
                    dgv.Rows[i].Cells[j].Value = list[i][j];
                }
            }
        }
        private void FillDGVFromReader(DataGridView dgv) // need to finish
        {
            SqlDataReader reader = GlobalConnection.Reader;
            // clear dgv and set column names
            dgv.Rows.Clear();
            for (int j = 0; j < reader.FieldCount; j++)
            {
                dgv.Columns[j].HeaderText = reader.GetName(j);
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

            int rowNum = GetRowNumFromGSID();
            foreach (DataGridViewCell cell in dgvGS.Rows[rowNum].Cells)
            {
                cell.Style.BackColor = Color.LightGreen;
            }

            dgvGS.ClearSelection();
        }
        private int GetRowNumFromGSID()
        {
            for (int i = 0; i < dgvGS.RowCount; i++)
            {
                if (Convert.ToInt32(dgvGS.Rows[i].Cells[0].Value) == selectedGSID)
                {
                    return i;
                }
            }
            return -1;
        }
        private GasStation GetSelectedGasStation()
        {
            int rowNum = GetRowNumFromGSID();
            if (rowNum == -1)
            {
                return null;
            }
            GasStation GS = new GasStation(selectedGSID, dgvGS.Rows[rowNum].Cells[1].Value.ToString(), dgvGS.Rows[rowNum].Cells[2].Value.ToString());

            List<GasDeliver> GDList = new List<GasDeliver>();
            List<object[]> tmpGDList = GlobalConnection.ExecReaderToList("select * from gas_deliver where gas_deliver.gas_station_id = " + selectedGSID);
            for (int i = 0; i < tmpGDList.Count; i++)
            {
                GDList.Add(new GasDeliver(tmpGDList[i][1].ToString())); // 0 - id, 1 - type, 2 - gas_station_id
            }

            //List<Employee> employeeList = new List<Employee>();
            //List<object[]> tmpEmployeeList = GlobalConnection.ExecReaderToList("select * from staff where staff.gas_station_id = " + selectedGSID);
            //for (int i = 0; i < tmpEmployeeList.Count; i++)
            //{
            //    employeeList.Add(new Employee(tmpEmployeeList[i][1].ToString(), tmpEmployeeList[i][2].ToString())); // 0 - id, 1 - name, 2 - position, 3 - gas_station_id
            //}

            GS.GasDeliverys = GDList;
            //GS.Employees = employeeList;

            return GS;
        }

        private void FormManageGS_Load(object sender, EventArgs e)
        {
            SetDgvGSColumns();
            SetDgvGasDeliverColumns();
            //SetDgvStaffColumns();

            string selectGS = "select * from gas_station";
            GlobalConnection.ExecReader(selectGS);
            FillDGVFromReader(dgvGS);
            GlobalConnection.CloseReader();

            dgvGS.RowHeaderMouseDoubleClick += DgvGS_RowHeaderMouseDoubleClick;
            dgvGS.CellEndEdit += DgvGS_CellEndEdit;

            dgvGasDeliveries.CellEndEdit += dgvGasDeliveriesCellEndEdit;

            //dgvStaff.CellEndEdit += dgvStaffCellEndEdit;



            if (GasStation != null) // if GasStation was selected earlie imitate selection by double click
            {
                int rowNum = 0;
                for (int i = 0; i < dgvGS.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvGS.Rows[i].Cells[0].Value) == GasStation.ID)
                    {
                        rowNum = i;
                        break;
                    }
                }
                DgvGS_RowHeaderMouseDoubleClick(dgvGS, new DataGridViewCellMouseEventArgs(-1, rowNum, 0, 0, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0)));
            }
        }
        private void DgvGS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (_isInsertNeeded)        // if there is new line added insert new line into database, else update this line
            //{
            //    GlobalConnection.InsertGasStation(
            //        dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
            //        dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "");
            //    _isInsertNeeded = false;
            //}
            //else
            //{
            GlobalConnection.UpdateGasStation(
                dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
                dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "",
                Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value));
            //}
        }
        private void dgvGasDeliveriesCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GlobalConnection.UpdateGasDeliver(
                dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value != null ?
                        dgvGasDeliveries.Rows[e.RowIndex].Cells[1].Value.ToString() :
                        "",
                selectedGSID,
                Convert.ToInt32(dgvGasDeliveries.Rows[e.RowIndex].Cells[0].Value));
        }
        //private void dgvStaffCellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    GlobalConnection.UpdateStaff(
        //        dgvGS.Rows[e.RowIndex].Cells[1].Value != null ? dgvGS.Rows[e.RowIndex].Cells[1].Value.ToString() : "",
        //        dgvGS.Rows[e.RowIndex].Cells[2].Value != null ? dgvGS.Rows[e.RowIndex].Cells[2].Value.ToString() : "",
        //        selectedGSID,
        //        Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value));
        //}
        private void DgvGS_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string GSid;
            GSid = dgvGS.Rows[e.RowIndex].Cells[0].Value.ToString();
            string selectGasDelivers = "select * from gas_deliver where gas_deliver.gas_station_id = " + GSid;
            GlobalConnection.ExecReader(selectGasDelivers);
            FillDGVFromReader(dgvGasDeliveries);
            GlobalConnection.CloseReader();

            //string selectStaff = "select * from staff where staff.gas_station_id = " + GSid;
            //GlobalConnection.ExecReader(selectStaff);
            //FillDGVFromReader(dgvStaff);
            //GlobalConnection.CloseReader();

            selectedGSID = Convert.ToInt32(dgvGS.Rows[e.RowIndex].Cells[0].Value);
            HighlightSelectedGS();

            groupboxColumns.Visible = true;
        }
        private void FormManageGS_FormClosing(object sender, FormClosingEventArgs e)
        {
            GasStation = GetSelectedGasStation();

            if (GasStation == null)
            {
                MessageBox.Show("Оберіть АЗС");
                e.Cancel = true;
                return;
            }
            MainForm.GasStation = GasStation;




            //GS = new List<GasStation>();
            //for (int i = 0; i < dgvGS.RowCount; i++)
            //{
            //    GS.Add(new GasStation(Convert.ToInt32(dgvGS.Rows[i].Cells[0].Value),
            //        Convert.ToString(dgvGS.Rows[i].Cells[1].Value),
            //        Convert.ToString(dgvGS.Rows[i].Cells[2].Value)));
            //}
        }
        private void AddGS_Click(object sender, EventArgs e)
        {
            FormAddGS f = new FormAddGS(dgvGS);
            f.ShowDialog();
        }
        private void AddGasDeliver_Click(object sender, EventArgs e)
        {
            FormAddGasDeliver f = new FormAddGasDeliver(dgvGasDeliveries, selectedGSID);
            f.ShowDialog();
        }
        //private void AddEmployee_Click(object sender, EventArgs e)
        //{
        //    FormAddEmployee f = new FormAddEmployee(dgvStaff, selectedGSID);
        //    f.ShowDialog();
        //}
    }
}
