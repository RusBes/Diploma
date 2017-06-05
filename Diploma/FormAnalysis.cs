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
    public partial class FormAnalysis : Form
    {

        public FormAnalysis(GasStation gs, List<Car> cars_)
        {
            InitializeComponent();
            Cars = cars_;
            GasStation = gs;
            n = gs.GasDeliverys.Count;
            m = gs.MaxQueueCount;
        }

        GasStation GasStation;
        List<Car> Cars;
        double T;
        int m;
        int n;

        //bool exp = false;

        List<double> timeMoments = new List<double>();
        List<int> Served = new List<int>();
        List<int> Rejected = new List<int>();
        List<int> Queue = new List<int>();
        List<double> DownTime = new List<double>();
        List<int> NumberOfBusyChanels = new List<int>();

        
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

        Servicing s;
        private void ReculcParametersAndCharacteristicsManualAndShow(List<Car> cars)
        {
            s = Start(cars, GasStation.GasDeliverys.Count);

            for (int i = 0; i < chartServicing.Series.Count; i++)
            {
                chartServicing.Series[i].Points.Clear();
            }
            for (int i = 0; i < s.TimeMoments.Count; i++)
            {
                chartServicing.Series["Обслуговування"].Points.AddY(s.Served[i]);
                chartServicing.Series["Черга"].Points.AddY(s.Queue[i]);
                chartServicing.Series["Зайняті канали"].Points.AddY(s.NumberOfBusyChanels[i]);
            }

            //double T = (DateTime.Now - startTime).TotalMinutes;

            //int carComeCount = 5;
            //double lambda = (double)carComeCount / T;
            //double mu = GetMuFromDB(startTime);
            //int n = GasStation.GasDeliverys.Count;
            //int m = 5;

            //ReCulcCharacteristics(T, lambda, mu, n, m);
        }
        private Servicing Start(List<Car> cars1, int n)
        {
            List<DateTime> timeMoments = new List<DateTime>();
            List<int> Served = new List<int>();
            List<int> Queue = new List<int>();
            List<DateTime> DownTime = new List<DateTime>();
            List<int> NumberOfBusyChanels = new List<int>();

            List<Car> carsInGS = new List<Car>();

            List<Car> cars = new List<Car>();
            for (int i = 0; i < cars1.Count; i++)
            {
                cars.Add(cars1[i]);
            }

            if (carsInGS.Count == 0 && cars.Count > 0)
            {
                Car c = cars.Find(cc => cc.ComeTime == cars.Min(car => car.ComeTime));  // если пришла следующая то записываю ее (из неприбывших с наименьшим временем прибытия)
                cars.Remove(c);
                carsInGS.Add(c);

                timeMoments.Add(c.ComeTime);
                // culc queue
                List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                for (int i = 0; i < busyGD.Count; i++)
                {
                    busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // считаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                }
                Queue.Add(busyGD.Sum());
                //
                Served.Add(0);
                DownTime.Add(c.ComeTime);
                NumberOfBusyChanels.Add(busyGD.Count);
            }

            while (cars.Count > 0 || carsInGS.Count(car => car.LeaveTime != DateTime.MinValue) > 0)
            {
                if (FindFirstLeaveCar(carsInGS) == null)
                {
                    Car c = cars.Find(cc => cc.ComeTime == cars.Min(car => car.ComeTime));  // если пришла следующая то записываю ее (из неприбывших с наименьшим временем прибытия)
                    cars.Remove(c);
                    carsInGS.Add(c);

                    timeMoments.Add(c.ComeTime);
                    // culc queue
                    List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                    for (int i = 0; i < busyGD.Count; i++)
                    {
                        busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // считаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                    }
                    Queue.Add(busyGD.Sum());
                    //
                    Served.Add(Served.Last());
                    DownTime.Add(busyGD.Count == n ? DownTime.Last() : DownTime.Last().Add(c.ComeTime - DownTime.Last()));
                    NumberOfBusyChanels.Add(busyGD.Count);
                }
                else if (cars.Count == 0)
                {
                    Car c = FindFirstLeaveCar(carsInGS);
                    carsInGS.Remove(c);

                    timeMoments.Add(c.ComeTime);
                    // culc queue
                    List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                    for (int i = 0; i < busyGD.Count; i++)
                    {
                        busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // ссчитаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                    }
                    Queue.Add(busyGD.Sum());
                    //
                    Served.Add(Served.Last() + 1);
                    DownTime.Add(busyGD.Count == n ? DownTime.Last() : DownTime.Last().Add(c.LeaveTime - DownTime.Last()));
                    //DownTime.Add(DownTime.Last());
                    NumberOfBusyChanels.Add(busyGD.Count);
                }
                else if (cars.Min(car => car.ComeTime) < carsInGS.Where(car => car.LeaveTime != DateTime.MinValue).Min(car => car.LeaveTime))    // проверяю что случилось раньше, прибытие или отбытие машины
                {
                    Car c = cars.Find(cc => cc.ComeTime == cars.Min(car => car.ComeTime));  // если пришла следующая то записываю ее (из неприбывших с наименьшим временем прибытия)
                    cars.Remove(c);
                    carsInGS.Add(c);

                    timeMoments.Add(c.ComeTime);
                    // culc queue
                    List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                    for (int i = 0; i < busyGD.Count; i++)
                    {
                        busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // считаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                    }
                    Queue.Add(busyGD.Sum());
                    //
                    Served.Add(Served.Last());
                    DownTime.Add(busyGD.Count == n ? DownTime.Last() : DownTime.Last().Add(c.ComeTime - DownTime.Last()));
                    NumberOfBusyChanels.Add(busyGD.Count);
                }
                else
                {
                    Car c = FindFirstLeaveCar(carsInGS);
                    carsInGS.Remove(c);

                    timeMoments.Add(c.ComeTime);
                    // culc queue
                    List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                    for (int i = 0; i < busyGD.Count; i++)
                    {
                        busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // ссчитаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                    }
                    Queue.Add(busyGD.Sum());
                    //
                    Served.Add(Served.Last() + 1);
                    DownTime.Add(busyGD.Count == n ? DownTime.Last() : DownTime.Last().Add(c.LeaveTime - DownTime.Last()));
                    //DownTime.Add(DownTime.Last());
                    NumberOfBusyChanels.Add(busyGD.Count);
                }
            }

            return new Servicing() { TimeMoments = timeMoments, Served = Served, Queue = Queue, DownTime = DownTime, NumberOfBusyChanels = NumberOfBusyChanels };
        }
        Car FindFirstComeCar(List<Car> cars)
        {
            if (cars.Count == 0)
            {
                return null;
            }
            Car res = cars.Find(car => car.ComeTime == cars.Min(c => c.ComeTime));
            return res;
        }
        Car FindFirstLeaveCar(List<Car> cars)
        {
            if (cars.Count == 0)
            {
                return null;
            }
            List<Car> tmp = cars.Where(car => car.LeaveTime != DateTime.MinValue).ToList();
            if (tmp.Count == 0)
            {
                return null;
            }
            Car res = tmp.Find(car => car.LeaveTime == tmp.Min(c => c.LeaveTime));
            return res;
        }


        List<double> Pvid = new List<double>();
        List<double> q = new List<double>();
        List<double> A = new List<double>();
        List<double> z = new List<double>();
        List<double> r = new List<double>();
        List<double> kser = new List<double>();
        List<double> toch = new List<double>();
        List<double> tsyst = new List<double>();


        List<double> service;
        List<double> flow;
        private void RealCharact()
        {
            List<Car> leaveCars = Cars.Where(car => car.LeaveTime != DateTime.MinValue).ToList();

            flow = new List<double>();
            for (int i = 0; i < leaveCars.Count - 1; i++)
            {
                flow.Add((leaveCars[i + 1].ComeTime - leaveCars[i].ComeTime).TotalHours);
            }

            service = new List<double>();
            for (int i = 0; i < leaveCars.Count - 1; i++)
            {
                service.Add((leaveCars[i].LeaveTime - leaveCars[i].ComeTime).TotalHours);
            }



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

            lbRealCharact.Items.Add("Рvidm: " + Math.Round(Pvid_, 4).ToString());
            lbRealCharact.Items.Add("q: " + Math.Round(q_, 4).ToString());
            lbRealCharact.Items.Add("A: " + Math.Round(A_, 4).ToString());
            lbRealCharact.Items.Add("z: " + Math.Round(z_, 4).ToString());
            lbRealCharact.Items.Add("r: " + Math.Round(r_, 4).ToString());
            lbRealCharact.Items.Add("k: " + Math.Round(kser_, 4).ToString());
            lbRealCharact.Items.Add("t_och: " + Math.Round(toch_, 4).ToString());
            lbRealCharact.Items.Add("t_syst: " + Math.Round(tsyst_, 4).ToString());
            lbRealCharact.Items.Add("");

        }

        private void TeorCharact(double lambda, double mu)
        {
            double _p = lambda / mu;

            double p0 = 1;
            double fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
                p0 += Math.Pow(_p, i) / fact;
            }

            lbTeorCharact.Items.Add("Теоретичні характеристики");
            p0 += Math.Pow(_p, n) / fact * (_p / n - Math.Pow(_p / n, m + 1)) / (1 - _p / n);
            p0 = 1 / p0;
            double p_ost = Math.Pow(_p, n + m) / (Math.Pow(n, m) * fact) * p0;
            lbTeorCharact.Items.Add("Рvidm : " + Math.Round(p_ost, 4).ToString());
            double q = 1 - p_ost;
            lbTeorCharact.Items.Add("q : " + Math.Round(q, 4).ToString());
            double A = lambda * q;
            lbTeorCharact.Items.Add("A : " + Math.Round(A, 4).ToString());
            double z_ = A / mu;
            lbTeorCharact.Items.Add("z : " + Math.Round(z_, 4).ToString());
            double r_ = Math.Pow(_p, n + 1) / (n * fact) * p0 * (1 - (m + 1) * Math.Pow(_p / n, m) + m * Math.Pow(_p / n, m + 1)) / Math.Pow(1 - _p / n, 2);
            lbTeorCharact.Items.Add("r : " + Math.Round(r_, 4).ToString());
            double k_ = z_ + r_;
            lbTeorCharact.Items.Add("k : " + Math.Round(k_, 4).ToString());
            double t_och = r_ / lambda;
            lbTeorCharact.Items.Add("t_och : " + Math.Round(t_och, 4).ToString());
            double t_syst = t_och + q / mu;
            lbTeorCharact.Items.Add("t_syst : " + Math.Round(t_syst, 4).ToString());
        }

        private void FormAnalysis_Load(object sender, EventArgs e)
        {
            ReculcParametersAndCharacteristicsManualAndShow(Cars);

            RealCharact();


            TimeSpan time = Cars.Last().ComeTime - Cars.First().ComeTime;
            double lambda = (time.TotalSeconds / Cars.Count) * 3600 ;   // беру секунды, но мне нужно количество машин за час, поэто множу на 3600

            List<Car> leaveCars = Cars.Where(car => car.LeaveTime != DateTime.MinValue).ToList();
            int carLeaveCount = leaveCars.Count();
            double mu = (leaveCars.Sum(car => (car.LeaveTime - car.ComeTime).TotalSeconds) / leaveCars.Count);
            TeorCharact(lambda, mu);
        }
        private void butShowCharactGraphics_Click(object sender, EventArgs e)
        {
            //new FormCharact(flow.Count, T, timeMoments, Pvid, q, A, z, r, kser, toch, tsyst).Show();
        }
    }
}
