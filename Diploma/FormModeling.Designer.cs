namespace Diploma
{
    partial class FormModeling
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.butShowCharactGraphics = new System.Windows.Forms.Button();
            this.lbCharact = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbn = new System.Windows.Forms.TextBox();
            this.tbLimTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLength = new System.Windows.Forms.TextBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.butStart = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMu = new System.Windows.Forms.TextBox();
            this.tbLambda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // butShowCharactGraphics
            // 
            this.butShowCharactGraphics.Enabled = false;
            this.butShowCharactGraphics.Location = new System.Drawing.Point(717, 353);
            this.butShowCharactGraphics.Name = "butShowCharactGraphics";
            this.butShowCharactGraphics.Size = new System.Drawing.Size(188, 46);
            this.butShowCharactGraphics.TabIndex = 37;
            this.butShowCharactGraphics.Text = "Показати графіки";
            this.butShowCharactGraphics.UseVisualStyleBackColor = true;
            this.butShowCharactGraphics.Click += new System.EventHandler(this.butShowCharactGraphics_Click);
            // 
            // lbCharact
            // 
            this.lbCharact.FormattingEnabled = true;
            this.lbCharact.Location = new System.Drawing.Point(717, 57);
            this.lbCharact.Name = "lbCharact";
            this.lbCharact.Size = new System.Drawing.Size(188, 290);
            this.lbCharact.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "n";
            // 
            // tbn
            // 
            this.tbn.Location = new System.Drawing.Point(161, 35);
            this.tbn.Name = "tbn";
            this.tbn.Size = new System.Drawing.Size(63, 20);
            this.tbn.TabIndex = 38;
            this.tbn.Text = "6";
            // 
            // tbLimTime
            // 
            this.tbLimTime.Location = new System.Drawing.Point(161, 9);
            this.tbLimTime.Name = "tbLimTime";
            this.tbLimTime.Size = new System.Drawing.Size(63, 20);
            this.tbLimTime.TabIndex = 36;
            this.tbLimTime.Text = "24";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Довжина черги";
            // 
            // tbLength
            // 
            this.tbLength.Location = new System.Drawing.Point(256, 35);
            this.tbLength.Name = "tbLength";
            this.tbLength.Size = new System.Drawing.Size(33, 20);
            this.tbLength.TabIndex = 34;
            this.tbLength.Text = "5";
            // 
            // chart2
            // 
            chartArea1.AxisX.Title = "t";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.AxisY.Title = "t_простою";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.CursorX.Interval = 0.1D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.Interval = 0.1D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            legend2.Enabled = false;
            legend2.Name = "Legend2";
            this.chart2.Legends.Add(legend1);
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 353);
            this.chart2.Name = "chart2";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            series1.Legend = "Legend1";
            series1.Name = "Простої";
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(699, 260);
            this.chart2.TabIndex = 32;
            this.chart2.Text = "chart1";
            // 
            // chart1
            // 
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.AxisX.Title = "t";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
            chartArea2.AxisY.Title = "n";
            chartArea2.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.CursorX.Interval = 0.1D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.Interval = 0.1D;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Name = "Legend1";
            legend4.Enabled = false;
            legend4.Name = "Legend2";
            this.chart1.Legends.Add(legend3);
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 61);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.Legend = "Legend1";
            series2.Name = "Обслуговування";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Black;
            series3.Legend = "Legend1";
            series3.Name = "Відмови";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Черга";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Teal;
            series5.Legend = "Legend1";
            series5.Name = "Зайняті канали";
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(699, 286);
            this.chart1.TabIndex = 33;
            this.chart1.Text = "chart1";
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(386, 9);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(115, 46);
            this.butStart.TabIndex = 31;
            this.butStart.Text = "Змоделювати роботу системи";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(256, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "Обмеженa чергa";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "mu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "lambda";
            // 
            // tbMu
            // 
            this.tbMu.Location = new System.Drawing.Point(58, 35);
            this.tbMu.Name = "tbMu";
            this.tbMu.Size = new System.Drawing.Size(63, 20);
            this.tbMu.TabIndex = 27;
            this.tbMu.Text = "400";
            // 
            // tbLambda
            // 
            this.tbLambda.Location = new System.Drawing.Point(58, 9);
            this.tbLambda.Name = "tbLambda";
            this.tbLambda.Size = new System.Drawing.Size(63, 20);
            this.tbLambda.TabIndex = 26;
            this.tbLambda.Text = "70";
            // 
            // FormModeling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 624);
            this.Controls.Add(this.butShowCharactGraphics);
            this.Controls.Add(this.lbCharact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbn);
            this.Controls.Add(this.tbLimTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLength);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMu);
            this.Controls.Add(this.tbLambda);
            this.Name = "FormModeling";
            this.Text = "FormModeling";
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butShowCharactGraphics;
        private System.Windows.Forms.ListBox lbCharact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbn;
        private System.Windows.Forms.TextBox tbLimTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLength;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMu;
        private System.Windows.Forms.TextBox tbLambda;
    }
}