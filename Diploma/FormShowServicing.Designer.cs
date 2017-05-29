namespace Diploma
{
    partial class FormShowServicing
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.butRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvServicing = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicing)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butRefresh});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(640, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // butRefresh
            // 
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(74, 20);
            this.butRefresh.Text = "Обновити";
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // dgvServicing
            // 
            this.dgvServicing.AllowUserToAddRows = false;
            this.dgvServicing.AllowUserToDeleteRows = false;
            this.dgvServicing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicing.Location = new System.Drawing.Point(0, 24);
            this.dgvServicing.Name = "dgvServicing";
            this.dgvServicing.RowHeadersVisible = false;
            this.dgvServicing.Size = new System.Drawing.Size(640, 415);
            this.dgvServicing.TabIndex = 1;
            // 
            // FormShowServicing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 439);
            this.Controls.Add(this.dgvServicing);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormShowServicing";
            this.Text = "Обслуговування";
            this.Load += new System.EventHandler(this.FormShowServicing_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem butRefresh;
        private System.Windows.Forms.DataGridView dgvServicing;
    }
}