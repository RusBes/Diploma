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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.butManageGS = new System.Windows.Forms.Button();
            this.butCarLeave = new System.Windows.Forms.Button();
            this.butCarCome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLeaveColumn = new System.Windows.Forms.ComboBox();
            this.cbComeColumn = new System.Windows.Forms.ComboBox();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.labelGS = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butModeling = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // butManageGS
            // 
            this.butManageGS.Location = new System.Drawing.Point(12, 12);
            this.butManageGS.Name = "butManageGS";
            this.butManageGS.Size = new System.Drawing.Size(75, 131);
            this.butManageGS.TabIndex = 0;
            this.butManageGS.Text = "Управління АЗС";
            this.butManageGS.UseVisualStyleBackColor = true;
            this.butManageGS.Click += new System.EventHandler(this.butManageGS_Click);
            // 
            // butCarLeave
            // 
            this.butCarLeave.Location = new System.Drawing.Point(6, 86);
            this.butCarLeave.Name = "butCarLeave";
            this.butCarLeave.Size = new System.Drawing.Size(75, 23);
            this.butCarLeave.TabIndex = 0;
            this.butCarLeave.Text = "Відхід";
            this.butCarLeave.UseVisualStyleBackColor = true;
            this.butCarLeave.Click += new System.EventHandler(this.butCarLeave_Click);
            // 
            // butCarCome
            // 
            this.butCarCome.Location = new System.Drawing.Point(6, 32);
            this.butCarCome.Name = "butCarCome";
            this.butCarCome.Size = new System.Drawing.Size(75, 23);
            this.butCarCome.TabIndex = 0;
            this.butCarCome.Text = "Прихід";
            this.butCarCome.UseVisualStyleBackColor = true;
            this.butCarCome.Click += new System.EventHandler(this.butCarCome_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbLeaveColumn);
            this.groupBox1.Controls.Add(this.cbComeColumn);
            this.groupBox1.Controls.Add(this.cbCarType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBrand);
            this.groupBox1.Controls.Add(this.butCarLeave);
            this.groupBox1.Controls.Add(this.butCarCome);
            this.groupBox1.Location = new System.Drawing.Point(93, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обслуговування авто";
            // 
            // cbLeaveColumn
            // 
            this.cbLeaveColumn.FormattingEnabled = true;
            this.cbLeaveColumn.Location = new System.Drawing.Point(87, 88);
            this.cbLeaveColumn.Name = "cbLeaveColumn";
            this.cbLeaveColumn.Size = new System.Drawing.Size(80, 21);
            this.cbLeaveColumn.TabIndex = 3;
            // 
            // cbComeColumn
            // 
            this.cbComeColumn.FormattingEnabled = true;
            this.cbComeColumn.Location = new System.Drawing.Point(250, 34);
            this.cbComeColumn.Name = "cbComeColumn";
            this.cbComeColumn.Size = new System.Drawing.Size(80, 21);
            this.cbComeColumn.TabIndex = 3;
            // 
            // cbCarType
            // 
            this.cbCarType.FormattingEnabled = true;
            this.cbCarType.Location = new System.Drawing.Point(87, 34);
            this.cbCarType.Name = "cbCarType";
            this.cbCarType.Size = new System.Drawing.Size(80, 21);
            this.cbCarType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Колонка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Колонка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Марка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип";
            // 
            // tbBrand
            // 
            this.tbBrand.Location = new System.Drawing.Point(173, 34);
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(71, 20);
            this.tbBrand.TabIndex = 1;
            // 
            // labelGS
            // 
            this.labelGS.AutoSize = true;
            this.labelGS.Location = new System.Drawing.Point(93, 12);
            this.labelGS.Name = "labelGS";
            this.labelGS.Size = new System.Drawing.Size(0, 13);
            this.labelGS.TabIndex = 2;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 173);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(637, 254);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // butModeling
            // 
            this.butModeling.Location = new System.Drawing.Point(554, 12);
            this.butModeling.Name = "butModeling";
            this.butModeling.Size = new System.Drawing.Size(95, 47);
            this.butModeling.TabIndex = 4;
            this.butModeling.Text = "Моделювання";
            this.butModeling.UseVisualStyleBackColor = true;
            this.butModeling.Click += new System.EventHandler(this.butModeling_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 444);
            this.Controls.Add(this.butModeling);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelGS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butManageGS);
            this.Name = "MainForm";
            this.Text = "Управління АЗС";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butManageGS;
        private System.Windows.Forms.Button butCarLeave;
        private System.Windows.Forms.Button butCarCome;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelGS;
        private System.Windows.Forms.ComboBox cbLeaveColumn;
        private System.Windows.Forms.ComboBox cbComeColumn;
        private System.Windows.Forms.ComboBox cbCarType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button butModeling;
    }
}

