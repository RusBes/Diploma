namespace Diploma
{
    partial class FormManageGS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGS = new System.Windows.Forms.DataGridView();
            this.groupboxAZS = new System.Windows.Forms.GroupBox();
            this.groupboxColumns = new System.Windows.Forms.GroupBox();
            this.dgvGasDeliveries = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGS)).BeginInit();
            this.groupboxAZS.SuspendLayout();
            this.groupboxColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasDeliveries)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGS
            // 
            this.dgvGS.AllowUserToAddRows = false;
            this.dgvGS.AllowUserToResizeRows = false;
            this.dgvGS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGS.Location = new System.Drawing.Point(6, 19);
            this.dgvGS.Name = "dgvGS";
            this.dgvGS.Size = new System.Drawing.Size(308, 299);
            this.dgvGS.TabIndex = 1;
            this.dgvGS.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGS_UserDeletingRow);
            // 
            // groupboxAZS
            // 
            this.groupboxAZS.Controls.Add(this.dgvGS);
            this.groupboxAZS.Location = new System.Drawing.Point(12, 12);
            this.groupboxAZS.Name = "groupboxAZS";
            this.groupboxAZS.Size = new System.Drawing.Size(320, 324);
            this.groupboxAZS.TabIndex = 2;
            this.groupboxAZS.TabStop = false;
            this.groupboxAZS.Text = "АЗС";
            // 
            // groupboxColumns
            // 
            this.groupboxColumns.Controls.Add(this.dgvGasDeliveries);
            this.groupboxColumns.Location = new System.Drawing.Point(338, 12);
            this.groupboxColumns.Name = "groupboxColumns";
            this.groupboxColumns.Size = new System.Drawing.Size(282, 324);
            this.groupboxColumns.TabIndex = 2;
            this.groupboxColumns.TabStop = false;
            this.groupboxColumns.Text = "Колонки";
            // 
            // dgvGasDeliveries
            // 
            this.dgvGasDeliveries.AllowUserToAddRows = false;
            this.dgvGasDeliveries.AllowUserToResizeRows = false;
            this.dgvGasDeliveries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGasDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGasDeliveries.Location = new System.Drawing.Point(6, 19);
            this.dgvGasDeliveries.Name = "dgvGasDeliveries";
            this.dgvGasDeliveries.Size = new System.Drawing.Size(263, 299);
            this.dgvGasDeliveries.TabIndex = 1;
            this.dgvGasDeliveries.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvGasDeliveries_UserDeletingRow);
            // 
            // FormManageGS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 349);
            this.Controls.Add(this.groupboxColumns);
            this.Controls.Add(this.groupboxAZS);
            this.Name = "FormManageGS";
            this.Text = "Управління АЗС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManageGS_FormClosing);
            this.Load += new System.EventHandler(this.FormManageGS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGS)).EndInit();
            this.groupboxAZS.ResumeLayout(false);
            this.groupboxColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGasDeliveries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvGS;
        private System.Windows.Forms.GroupBox groupboxAZS;
        private System.Windows.Forms.GroupBox groupboxColumns;
        private System.Windows.Forms.DataGridView dgvGasDeliveries;
    }
}