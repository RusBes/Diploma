﻿namespace Diploma
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.butCarLeave = new System.Windows.Forms.Button();
            this.butCarCome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbLeaveColumn = new System.Windows.Forms.ComboBox();
            this.cbComeColumn = new System.Windows.Forms.ComboBox();
            this.cbCarType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCapasity = new System.Windows.Forms.TextBox();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.labelGS = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.управлінняАЗСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аналізАЗСToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатиОбслуговуванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моделюванняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartServicing = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbStatCharact = new System.Windows.Forms.ListBox();
            this.lbTeorCharact = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvServicing = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicing)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbCapasity);
            this.groupBox1.Controls.Add(this.tbBrand);
            this.groupBox1.Controls.Add(this.butCarLeave);
            this.groupBox1.Controls.Add(this.butCarCome);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 115);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Міскість";
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
            // tbCapasity
            // 
            this.tbCapasity.Location = new System.Drawing.Point(173, 88);
            this.tbCapasity.Name = "tbCapasity";
            this.tbCapasity.Size = new System.Drawing.Size(71, 20);
            this.tbCapasity.TabIndex = 1;
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
            this.labelGS.Location = new System.Drawing.Point(9, 24);
            this.labelGS.Name = "labelGS";
            this.labelGS.Size = new System.Drawing.Size(0, 13);
            this.labelGS.TabIndex = 2;
            // 
            // chartMain
            // 
            chartArea3.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea3);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartMain.Legends.Add(legend4);
            this.chartMain.Location = new System.Drawing.Point(12, 161);
            this.chartMain.Name = "chartMain";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartMain.Series.Add(series6);
            this.chartMain.Size = new System.Drawing.Size(343, 309);
            this.chartMain.TabIndex = 3;
            this.chartMain.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.управлінняАЗСToolStripMenuItem,
            this.аналізАЗСToolStripMenuItem,
            this.показатиОбслуговуванняToolStripMenuItem,
            this.моделюванняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // управлінняАЗСToolStripMenuItem
            // 
            this.управлінняАЗСToolStripMenuItem.Name = "управлінняАЗСToolStripMenuItem";
            this.управлінняАЗСToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.управлінняАЗСToolStripMenuItem.Text = "Управління АЗС";
            this.управлінняАЗСToolStripMenuItem.Click += new System.EventHandler(this.butManageGS_Click);
            // 
            // аналізАЗСToolStripMenuItem
            // 
            this.аналізАЗСToolStripMenuItem.Name = "аналізАЗСToolStripMenuItem";
            this.аналізАЗСToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.аналізАЗСToolStripMenuItem.Text = "Аналіз АЗС";
            this.аналізАЗСToolStripMenuItem.Click += new System.EventHandler(this.butAnalisysAZS_Click);
            // 
            // показатиОбслуговуванняToolStripMenuItem
            // 
            this.показатиОбслуговуванняToolStripMenuItem.Name = "показатиОбслуговуванняToolStripMenuItem";
            this.показатиОбслуговуванняToolStripMenuItem.Size = new System.Drawing.Size(162, 20);
            this.показатиОбслуговуванняToolStripMenuItem.Text = "Показати обслуговування";
            this.показатиОбслуговуванняToolStripMenuItem.Click += new System.EventHandler(this.butShowServicing_Click);
            // 
            // моделюванняToolStripMenuItem
            // 
            this.моделюванняToolStripMenuItem.Name = "моделюванняToolStripMenuItem";
            this.моделюванняToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.моделюванняToolStripMenuItem.Text = "Моделювання";
            this.моделюванняToolStripMenuItem.Click += new System.EventHandler(this.butModeling_Click);
            // 
            // chartServicing
            // 
            chartArea4.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea4.AxisX.Title = "t";
            chartArea4.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea4.AxisY.Title = "n";
            chartArea4.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.CursorX.Interval = 0.1D;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorY.Interval = 0.1D;
            chartArea4.CursorY.IsUserEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.Name = "ChartArea1";
            this.chartServicing.ChartAreas.Add(chartArea4);
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend5.Name = "Legend1";
            legend6.Enabled = false;
            legend6.Name = "Legend2";
            this.chartServicing.Legends.Add(legend5);
            this.chartServicing.Legends.Add(legend6);
            this.chartServicing.Location = new System.Drawing.Point(361, 27);
            this.chartServicing.Name = "chartServicing";
            series7.BorderWidth = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Lime;
            series7.Legend = "Legend1";
            series7.Name = "Обслуговування";
            series8.BorderWidth = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Black;
            series8.Legend = "Legend1";
            series8.Name = "Відмови";
            series9.BorderWidth = 2;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Red;
            series9.Legend = "Legend1";
            series9.Name = "Черга";
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Teal;
            series10.Legend = "Legend1";
            series10.Name = "Зайняті канали";
            this.chartServicing.Series.Add(series7);
            this.chartServicing.Series.Add(series8);
            this.chartServicing.Series.Add(series9);
            this.chartServicing.Series.Add(series10);
            this.chartServicing.Size = new System.Drawing.Size(558, 286);
            this.chartServicing.TabIndex = 34;
            this.chartServicing.Text = "chart1";
            this.chartServicing.Visible = false;
            // 
            // lbStatCharact
            // 
            this.lbStatCharact.FormattingEnabled = true;
            this.lbStatCharact.Location = new System.Drawing.Point(361, 336);
            this.lbStatCharact.Name = "lbStatCharact";
            this.lbStatCharact.Size = new System.Drawing.Size(202, 134);
            this.lbStatCharact.TabIndex = 35;
            // 
            // lbTeorCharact
            // 
            this.lbTeorCharact.FormattingEnabled = true;
            this.lbTeorCharact.Location = new System.Drawing.Point(569, 336);
            this.lbTeorCharact.Name = "lbTeorCharact";
            this.lbTeorCharact.Size = new System.Drawing.Size(202, 134);
            this.lbTeorCharact.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Статистичні характеристики";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(597, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Теоретичні характеристики";
            // 
            // dgvServicing
            // 
            this.dgvServicing.AllowUserToAddRows = false;
            this.dgvServicing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicing.Location = new System.Drawing.Point(361, 27);
            this.dgvServicing.Name = "dgvServicing";
            this.dgvServicing.Size = new System.Drawing.Size(558, 443);
            this.dgvServicing.TabIndex = 39;
            this.dgvServicing.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvServicing_UserDeletingRow);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 482);
            this.Controls.Add(this.dgvServicing);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbTeorCharact);
            this.Controls.Add(this.lbStatCharact);
            this.Controls.Add(this.chartServicing);
            this.Controls.Add(this.chartMain);
            this.Controls.Add(this.labelGS);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Управління АЗС";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCapasity;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem управлінняАЗСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аналізАЗСToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатиОбслуговуванняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моделюванняToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartServicing;
        private System.Windows.Forms.ListBox lbStatCharact;
        private System.Windows.Forms.ListBox lbTeorCharact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvServicing;
    }
}

