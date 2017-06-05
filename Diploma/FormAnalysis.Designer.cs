namespace Diploma
{
    partial class FormAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.butShowCharactGraphics = new System.Windows.Forms.Button();
            this.lbRealCharact = new System.Windows.Forms.ListBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartServicing = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTeorCharact = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicing)).BeginInit();
            this.SuspendLayout();
            // 
            // butShowCharactGraphics
            // 
            this.butShowCharactGraphics.Enabled = false;
            this.butShowCharactGraphics.Location = new System.Drawing.Point(717, 514);
            this.butShowCharactGraphics.Name = "butShowCharactGraphics";
            this.butShowCharactGraphics.Size = new System.Drawing.Size(188, 46);
            this.butShowCharactGraphics.TabIndex = 53;
            this.butShowCharactGraphics.Text = "Показати графіки";
            this.butShowCharactGraphics.UseVisualStyleBackColor = true;
            this.butShowCharactGraphics.Click += new System.EventHandler(this.butShowCharactGraphics_Click);
            // 
            // lbRealCharact
            // 
            this.lbRealCharact.FormattingEnabled = true;
            this.lbRealCharact.Location = new System.Drawing.Point(717, 8);
            this.lbRealCharact.Name = "lbRealCharact";
            this.lbRealCharact.Size = new System.Drawing.Size(188, 238);
            this.lbRealCharact.TabIndex = 41;
            // 
            // chart2
            // 
            chartArea3.AxisX.Title = "t";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.AxisY.Title = "t_простою";
            chartArea3.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea3.CursorX.Interval = 0.1D;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.Interval = 0.1D;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend5.Name = "Legend1";
            legend6.Enabled = false;
            legend6.Name = "Legend2";
            this.chart2.Legends.Add(legend5);
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(12, 304);
            this.chart2.Name = "chart2";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series6.Legend = "Legend1";
            series6.Name = "Простої";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(699, 260);
            this.chart2.TabIndex = 48;
            this.chart2.Text = "chart1";
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
            legend7.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend7.Name = "Legend1";
            legend8.Enabled = false;
            legend8.Name = "Legend2";
            this.chartServicing.Legends.Add(legend7);
            this.chartServicing.Legends.Add(legend8);
            this.chartServicing.Location = new System.Drawing.Point(12, 12);
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
            this.chartServicing.Size = new System.Drawing.Size(699, 286);
            this.chartServicing.TabIndex = 49;
            this.chartServicing.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, -23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "mu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-8, -49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "lambda";
            // 
            // lbTeorCharact
            // 
            this.lbTeorCharact.FormattingEnabled = true;
            this.lbTeorCharact.Location = new System.Drawing.Point(717, 270);
            this.lbTeorCharact.Name = "lbTeorCharact";
            this.lbTeorCharact.Size = new System.Drawing.Size(188, 238);
            this.lbTeorCharact.TabIndex = 41;
            // 
            // FormAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 572);
            this.Controls.Add(this.butShowCharactGraphics);
            this.Controls.Add(this.lbTeorCharact);
            this.Controls.Add(this.lbRealCharact);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chartServicing);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "FormAnalysis";
            this.Text = "FormAnalysis";
            this.Load += new System.EventHandler(this.FormAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butShowCharactGraphics;
        private System.Windows.Forms.ListBox lbRealCharact;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartServicing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbTeorCharact;
    }
}