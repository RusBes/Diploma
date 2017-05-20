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
    struct TimeValue
    {
        public double Time { get; set; }
        public double Value { get; set; }
    }
    struct Characteristics
    {
        public double PVidmovy,
        A,
        q,
        r,
        w,
        tSyst,
        tOch,
        tObsl,
        k;
    }
    public partial class FormModeling : Form
    {
        public FormModeling()
        {
            InitializeComponent();
        }

        double T = 0;
        int m = 0;
        int n = 0;

        //bool exp = false;

        List<double> timeMoments = new List<double>();
        List<int> Served = new List<int>();
        List<int> Rejected = new List<int>();
        List<int> Queue = new List<int>();
        List<double> DownTime = new List<double>();
        List<int> NumberOfBusyChanels = new List<int>();

        List<double> flow = new List<double>();
        List<double> service = new List<double>();

        Random rnd = new Random();
        public double NextExp(double Ly)
        {
            return -Math.Log(1 - rnd.NextDouble()) / Ly;
        }

        private int MinTimeInd(double[] arr)
        {
            double min = arr[0];
            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    res = i;
                }
            }
            return res;
        }

        private int ChanelCount(double[] mastime, double time)
        {
            int res = 0;
            for (int i = 0; i < mastime.Length; i++)
                if (mastime[i] > time)
                    res++;
            return res;
        }

        private void Start(double lambda, double mu)
        {
            T = Convert.ToDouble(tbLimTime.Text);
            m = Convert.ToInt32(tbLength.Text);
            n = Convert.ToInt32(tbn.Text);

            this.flow = new List<double>();
            service = new List<double>();

            double queueCount = 0;
            double chanelCount = 0;
            double Time = 0;
            int rejCount = 0;
            double[] queue = new double[0];
            double[] end_serv = new double[n];
            double one_flow = 0;
            double one_serv = 0;

            one_serv = NextExp(mu);
            service.Add(one_serv);
            end_serv[0] = one_serv;

            double time = 0;
            double sum1 = 0;
            int sum = 0;

            timeMoments = new List<double>();
            Served = new List<int>();
            Rejected = new List<int>();
            Queue = new List<int>();
            DownTime = new List<double>();
            NumberOfBusyChanels = new List<int>();

            timeMoments.Add(0);
            Served.Add(0);
            Rejected.Add(0);
            Queue.Add(0);
            DownTime.Add(0);
            NumberOfBusyChanels.Add(0);

            do
            {
                one_flow = NextExp(lambda);
                this.flow.Add(one_flow);
                time += one_flow;
                one_serv = NextExp(mu);
                service.Add(one_serv);

                if (end_serv[MinTimeInd(end_serv)] > time)
                {
                    if (queue.Length + 1 > m)
                    {
                        rejCount++;

                        timeMoments.Add(time);
                        sum++;
                        Served.Add(sum);
                        Rejected.Add(rejCount);
                        Queue.Add(queue.Length);
                        NumberOfBusyChanels.Add(ChanelCount(end_serv, time));
                        DownTime.Add(sum1);

                    }
                    else
                    {
                        Array.Resize(ref queue, queue.Length + 1);
                        queue[queue.Length - 1] = one_serv;

                        timeMoments.Add(time);
                        sum++;
                        Served.Add(sum);
                        Rejected.Add(rejCount);
                        Queue.Add(queue.Length);
                        NumberOfBusyChanels.Add(ChanelCount(end_serv, time));
                        DownTime.Add(sum1);
                    }
                }
                else
                {
                    if (queue.Length != 0)
                    {
                        while ((end_serv[MinTimeInd(end_serv)] < time) && (queue.Length != 0))
                        {
                            end_serv[MinTimeInd(end_serv)] += queue[0];
                            for (int j = 0; j < queue.Length - 1; j++)
                                queue[j] = queue[j + 1];
                            Array.Resize(ref queue, queue.Length - 1);
                            sum++;
                        }
                        if (queue.Length != 0)
                        {
                            Array.Resize(ref queue, queue.Length + 1);
                            queue[queue.Length - 1] = one_serv;

                            timeMoments.Add(time);
                            sum++;
                            Served.Add(sum);
                            Rejected.Add(rejCount);
                            Queue.Add(queue.Length);
                            NumberOfBusyChanels.Add(ChanelCount(end_serv, time));
                            DownTime.Add(sum1);
                        }
                        else
                        {
                            //sum1 += reqTimeMom - SerEndTime[IndOfMinTime(SerEndTime)];
                            sum1 += Math.Abs(time - end_serv[MinTimeInd(end_serv)]);
                            end_serv[MinTimeInd(end_serv)] = time + one_serv;

                            timeMoments.Add(time);
                            sum++;
                            Served.Add(sum);
                            Rejected.Add(rejCount);
                            Queue.Add(queue.Length);
                            NumberOfBusyChanels.Add(ChanelCount(end_serv, time));
                            DownTime.Add(sum1);
                        }
                    }
                    else
                    {

                        sum1 += Math.Abs(time - end_serv[MinTimeInd(end_serv)]);
                        end_serv[MinTimeInd(end_serv)] = time + one_serv;

                        timeMoments.Add(time);
                        sum++;
                        Served.Add(sum);
                        Rejected.Add(rejCount);
                        Queue.Add(queue.Length);
                        NumberOfBusyChanels.Add(ChanelCount(end_serv, time));
                        DownTime.Add(sum1);
                    }

                }

                Time = T;
                chanelCount = ChanelCount(end_serv, time);
                queueCount += queue.Length;
            } while (time < T);

            lbCharact.Items.Clear();
            lbCharact.Items.Add("Кількість обслугованих: " + (Served.Count - rejCount).ToString());
            lbCharact.Items.Add("Кількість Відмов: " + rejCount.ToString());
            lbCharact.Items.Add("");


        }


        List<double> Pvid = new List<double>();
        List<double> q = new List<double>();
        List<double> A = new List<double>();
        List<double> z = new List<double>();
        List<double> r = new List<double>();
        List<double> kser = new List<double>();
        List<double> toch = new List<double>();
        List<double> tsyst = new List<double>();
        private void StatistichniKharakteristiki()
        {
            List<double> _p = new List<double>();

            double sumPar1 = 0;
            double sumPar2 = 0;

            for (int i = 0; i < flow.Count; i++)
            {
                sumPar1 += flow[i];
                sumPar2 += service[i];
                _p.Add(sumPar2 / sumPar1);
            }

            double p0 = 1;
            double faktorial = 1;

            Pvid = new List<double>();
            q = new List<double>();
            A = new List<double>();
            z = new List<double>();
            r = new List<double>();
            kser = new List<double>();
            toch = new List<double>();
            tsyst = new List<double>();

            double Pvid_ = 0;
            double q_ = 0;
            double A_ = 0;
            double z_ = 0;
            double r_ = 0;
            double kser_ = 0;
            double toch_ = 0;
            double tsyst_ = 0;

            sumPar1 = 0;
            sumPar2 = 0;

            for (int j = 0; j < flow.Count; j++)
            {
                p0 = 1;
                faktorial = 1;

                for (int i = 1; i <= n; i++)
                {
                    faktorial = faktorial * i;
                    p0 += Math.Pow(_p[j], i) / faktorial;
                }

                p0 += Math.Pow(_p[j], n) / faktorial * (_p[j] / n - Math.Pow(_p[j] / n, m + 1)) / (1 - _p[j] / n);
                p0 = 1 / p0;

                sumPar1 += flow[j];
                sumPar2 += service[j];

                Pvid.Add(Math.Pow(_p[j], n + m) / (Math.Pow(n, m) * faktorial) * p0);
                q.Add(1 - Pvid[j]);

                A.Add(q[j] * (j + 1) / sumPar1);
                z.Add(A[j] / ((j + 1) / sumPar2));

                r.Add(Math.Pow(_p[j], n + 1) / (n * faktorial) * p0 * (1 - (m + 1) * Math.Pow(_p[j] / n, m) + m * Math.Pow(_p[j] / n, m + 1)) / Math.Pow(1 - _p[j] / n, 2));
                kser.Add(z[j] + r[j]);

                toch.Add(r[j] / ((j + 1) / sumPar1));
                tsyst.Add(toch[j] + q[j] / ((j + 1) / sumPar2));
            }

            //lbCharact.Items.Clear();

            Pvid_ = 0;
            q_ = 0;
            A_ = 0;
            z_ = 0;
            r_ = 0;
            kser_ = 0;
            toch_ = 0;
            tsyst_ = 0;

            for (int i = 0; i < flow.Count; i++)
            {
                Pvid_ += Pvid[i];
                q_ += q[i];
                A_ += A[i];
                z_ += z[i];
                r_ += r[i];
                kser_ += kser[i];
                toch_ += toch[i];
                tsyst_ += tsyst[i];
            }

            Pvid_ /= service.Count;
            q_ /= service.Count;
            A_ /= service.Count;
            z_ /= service.Count;
            r_ /= service.Count;
            kser_ /= service.Count;
            toch_ /= service.Count;
            tsyst_ /= service.Count;

            lbCharact.Items.Add("Рvidm: " + Math.Round(Pvid_, 4).ToString());
            lbCharact.Items.Add("q: " + Math.Round(q_, 4).ToString());
            lbCharact.Items.Add("A: " + Math.Round(A_, 4).ToString());
            lbCharact.Items.Add("z: " + Math.Round(z_, 4).ToString());
            lbCharact.Items.Add("r: " + Math.Round(r_, 4).ToString());
            lbCharact.Items.Add("k: " + Math.Round(kser_, 4).ToString());
            lbCharact.Items.Add("t_och: " + Math.Round(toch_, 4).ToString());
            lbCharact.Items.Add("t_syst: " + Math.Round(tsyst_, 4).ToString());
            lbCharact.Items.Add("");

        }

        private void butStart_Click(object sender, EventArgs e)
        {
            butShowCharactGraphics.Enabled = true;

            T = Convert.ToDouble(tbLimTime.Text);
            double lambda = Convert.ToDouble(tbLambda.Text);
            double mu = Convert.ToDouble(tbMu.Text);
            m = Convert.ToInt32(tbLength.Text);
            n = Convert.ToInt32(tbn.Text);

            Start(lambda, mu);

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart2.Series[0].Points.Clear();

            chart1.ChartAreas[0].AxisX.Minimum = 0.0;
            chart1.ChartAreas[0].AxisX.Maximum = T;
            chart1.ChartAreas[0].AxisY.Minimum = 0.0;

            chart2.ChartAreas[0].AxisX.Minimum = 0.0;
            chart2.ChartAreas[0].AxisX.Maximum = T;

            for (int i = 0; i < timeMoments.Count; i++)
            {
                if (timeMoments[i] < T)
                {
                    chart1.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), Served[i]);
                    chart1.Series[1].Points.AddXY(Math.Round(timeMoments[i], 4), Rejected[i]);
                    chart1.Series[2].Points.AddXY(Math.Round(timeMoments[i], 4), Queue[i]);
                    chart1.Series[3].Points.AddXY(Math.Round(timeMoments[i], 4), NumberOfBusyChanels[i]);
                    chart2.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), DownTime[i]);

                }
            }
            StatistichniKharakteristiki();

            double _p = lambda / mu;

            double p0 = 1;
            double fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
                p0 += Math.Pow(_p, i) / fact;
            }

            lbCharact.Items.Add("Теоретичні характеристики");
            p0 += Math.Pow(_p, n) / fact * (_p / n - Math.Pow(_p / n, m + 1)) / (1 - _p / n);
            p0 = 1 / p0;
            double p_ost = Math.Pow(_p, n + m) / (Math.Pow(n, m) * fact) * p0;
            lbCharact.Items.Add("Рvidm : " + Math.Round(p_ost, 4).ToString());
            double q = 1 - p_ost;
            lbCharact.Items.Add("q : " + Math.Round(q, 4).ToString());
            double A = lambda * q;
            lbCharact.Items.Add("A : " + Math.Round(A, 4).ToString());
            double z_ = A / mu;
            lbCharact.Items.Add("z : " + Math.Round(z_, 4).ToString());
            double r_ = Math.Pow(_p, n + 1) / (n * fact) * p0 * (1 - (m + 1) * Math.Pow(_p / n, m) + m * Math.Pow(_p / n, m + 1)) / Math.Pow(1 - _p / n, 2);
            lbCharact.Items.Add("r : " + Math.Round(r_, 4).ToString());
            double k_ = z_ + r_;
            lbCharact.Items.Add("k : " + Math.Round(k_, 4).ToString());
            double t_och = r_ / lambda;
            lbCharact.Items.Add("t_och : " + Math.Round(t_och, 4).ToString());
            double t_syst = t_och + q / mu;
            lbCharact.Items.Add("t_syst : " + Math.Round(t_syst, 4).ToString());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                tbLength.Enabled = true;
            else
                tbLength.Enabled = false;
        }

        private void butShowCharactGraphics_Click(object sender, EventArgs e)
        {
            new FormCharact(flow.Count, T, timeMoments, Pvid, q, A, z, r, kser, toch, tsyst).Show();
        }
    }
}
