namespace Diploma
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.butManageGS = new System.Windows.Forms.Button();
            this.butCarLeave = new System.Windows.Forms.Button();
            this.butCarCome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butManageGS
            // 
            this.butManageGS.Location = new System.Drawing.Point(12, 12);
            this.butManageGS.Name = "butManageGS";
            this.butManageGS.Size = new System.Drawing.Size(75, 35);
            this.butManageGS.TabIndex = 0;
            this.butManageGS.Text = "Управління АЗС";
            this.butManageGS.UseVisualStyleBackColor = true;
            this.butManageGS.Click += new System.EventHandler(this.butManageGS_Click);
            // 
            // butCarLeave
            // 
            this.butCarLeave.Location = new System.Drawing.Point(6, 48);
            this.butCarLeave.Name = "butCarLeave";
            this.butCarLeave.Size = new System.Drawing.Size(75, 23);
            this.butCarLeave.TabIndex = 0;
            this.butCarLeave.Text = "Відхід";
            this.butCarLeave.UseVisualStyleBackColor = true;
            // 
            // butCarCome
            // 
            this.butCarCome.Location = new System.Drawing.Point(6, 19);
            this.butCarCome.Name = "butCarCome";
            this.butCarCome.Size = new System.Drawing.Size(75, 23);
            this.butCarCome.TabIndex = 0;
            this.butCarCome.Text = "Прихід";
            this.butCarCome.UseVisualStyleBackColor = true;
            this.butCarCome.Click += new System.EventHandler(this.butCarCome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butCarLeave);
            this.groupBox1.Controls.Add(this.butCarCome);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обслуговування авто";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 380);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butManageGS);
            this.Name = "MainForm";
            this.Text = "Управління АЗС";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butManageGS;
        private System.Windows.Forms.Button butCarLeave;
        private System.Windows.Forms.Button butCarCome;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

