using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma
{
    public partial class FormCharact : Form
    {
        //double T;
        //List<double> timeMoments, Pvid, q, A, z, r, kser, toch, tsyst;
        public FormCharact(int N, double T, List<double> timeMoments, List<double> Pvid, List<double> q, List<double> A, List<double> z, List<double> r, List<double> kser, List<double> toch, List<double> tsyst)
        {
            InitializeComponent();

            chart1.ChartAreas[0].AxisX.Maximum = T;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = T;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            for (int i = 1; i < N; i++)
            {
                if (timeMoments[i] < T)
                {
                    chart1.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), Pvid[i]);
                    chart1.Series[1].Points.AddXY(Math.Round(timeMoments[i], 4), q[i]);
                    chart1.Series[2].Points.AddXY(Math.Round(timeMoments[i], 4), A[i]);
                    chart1.Series[3].Points.AddXY(Math.Round(timeMoments[i], 4), z[i]);

                    chart2.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), r[i]);
                    chart2.Series[1].Points.AddXY(Math.Round(timeMoments[i], 4), kser[i]);
                    chart2.Series[2].Points.AddXY(Math.Round(timeMoments[i], 4), toch[i]);
                    chart2.Series[3].Points.AddXY(Math.Round(timeMoments[i], 4), tsyst[i]);
                }
            }

        }
    }
}
