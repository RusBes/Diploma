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
    public partial class FormAddGasDeliver : Form
    {
        DataGridView dgv;
        int GSID;
        public FormAddGasDeliver(DataGridView dgv_, int gsid)
        {
            InitializeComponent();
            dgv = dgv_;
            GSID = gsid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add(null, textBox1.Text, null);

            GlobalConnection.InsertGasDeliver(
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value != null ? dgv.Rows[dgv.RowCount - 1].Cells[1].Value.ToString() : "",
                    GSID);

            SqlCommand cmd = new SqlCommand("select MAX(id) from gas_deliver", GlobalConnection.Connection);
            int ID = Convert.ToInt32(cmd.ExecuteScalar());
            dgv.Rows[dgv.RowCount - 1].Cells[0].Value = ID;             // set id

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
