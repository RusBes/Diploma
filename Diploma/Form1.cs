using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diploma
{
    public partial class MainForm : Form
    {
        public List<GasStation> GS = new List<GasStation>();
        public static GasStation GasStation;
        private readonly string[] carTypes = new string[] { "Легкова", "Вантажна" };
        DateTime startTime = DateTime.Now;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private bool CheckGasDeliverExistence()
        {
            if (GasStation.GasDeliverys.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SetLabelGS(string text)
        {
            labelGS.Text = "" + text;
        }
        private void GasStationSelectedEvent()
        {
            SetLabelGS(GasStation.Location + ", " + GasStation.Brand);

            chartMain.Series[0].Points.Clear();
            for (int i = 0; i < GasStation.GasDeliverys.Count; i++)
            {
                chartMain.Series[0].Points.Add(0);
                chartMain.Series[0].Points[i].AxisLabel = GasStation.GasDeliverys[i].Type + "-" + (i + 1);
            }

            // clear all 
            cbCarType.Text = "";
            cbComeColumn.Text = "";
            tbBrand.Text = "";
            cbLeaveColumn.Text = "";
            tbCapasity.Text = "";
            // set items to comboboxes
            cbComeColumn.Items.Clear();
            cbLeaveColumn.Items.Clear();
            for (int i = 0; i < GasStation.GasDeliverys.Count; i++)
            {
                cbComeColumn.Items.Add(i + 1);
                cbLeaveColumn.Items.Add(i + 1);
            }
            cbCarType.Items.Clear();
            for (int i = 0; i < carTypes.Length; i++)
            {
                cbCarType.Items.Add(carTypes[i]);
            }
            cbCarType.SelectedIndex = 0;

            startTime = DateTime.Now;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.IntegratedSecurity = true;
            builder.DataSource = "localhost";
            builder.InitialCatalog = "AZS";
            GlobalConnection.SetSQLConnection(new SqlConnection(builder.ConnectionString));
            GlobalConnection.Connection.Open();

            SqlCommand cmd = new SqlCommand("delete from servicing where car_leave_time is null", GlobalConnection.Connection);
            cmd.ExecuteNonQuery();

            try
            {
                //get id from file
                int gsID;
                using (StreamReader sr = new StreamReader("Help.txt"))
                {
                    gsID = Convert.ToInt32(sr.ReadLine().Split('=')[1]);
                }

                // create gas station (select)
                string loc = "";
                string brand = "";
                string selectGS = "select * from gas_station where id = " + gsID;
                GlobalConnection.ExecReader(selectGS);
                if (GlobalConnection.Reader.HasRows)
                {
                    for (int i = 0; GlobalConnection.Reader.Read(); i++)
                    {
                        loc = GlobalConnection.Reader.GetValue(1).ToString();
                        brand = GlobalConnection.Reader.GetValue(2).ToString();
                    }
                }
                GlobalConnection.CloseReader();
                GasStation = new GasStation(gsID, loc, brand);
                List<GasDeliver> GDList = new List<GasDeliver>();
                List<object[]> tmpGDList = GlobalConnection.ExecReaderToList("select * from gas_deliver where gas_deliver.gas_station_id = " + gsID);
                for (int i = 0; i < tmpGDList.Count; i++)
                {
                    GDList.Add(new GasDeliver(Convert.ToInt32(tmpGDList[i][0]), tmpGDList[i][1].ToString())); // 0 - id, 1 - type, 2 - gas_station_id
                }
                GasStation.GasDeliverys = GDList;

                GasStationSelectedEvent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalConnection.Connection.Close();
        }
        private void butManageGS_Click(object sender, EventArgs e)
        {
            FormManageGS fManageGS = new FormManageGS(ref GasStation);
            fManageGS.ShowDialog();

            if (GasStation != null)
            {
                GasStationSelectedEvent();

                using (StreamWriter sw = new StreamWriter("Help.txt", false))
                {
                    sw.WriteLine("selected_gas_station_id=" + GasStation.ID);
                }
            }
            else
            {
                SetLabelGS("");

                cbCarType.Text = "";
                cbComeColumn.Text = "";
                tbBrand.Text = "";
                cbLeaveColumn.Text = "";
                tbCapasity.Text = "";

                chartMain.Series[0].Points.Clear();
                using (StreamWriter sw = new StreamWriter("Help.txt", false))
                {
                    sw.WriteLine("");
                }
            }
        }
        private void butCarCome_Click(object sender, EventArgs e)
        {
            if (!CheckGasDeliverExistence())
            {
                MessageBox.Show("На станції повинна бути хоча б одна колонка!");
                return;
            }

            try
            {
                SqlCommand cmdInserCar = new SqlCommand($"insert into car values ('{ cbCarType.Text }', '{ tbBrand.Text }')", GlobalConnection.Connection);
                cmdInserCar.ExecuteNonQuery();

                int gdNum;  // number of gasdeliver
                if (cbComeColumn.Text.Length > 0)   // if text in combobox exists
                {
                    gdNum = Convert.ToInt32(cbComeColumn.Text) - 1; // take this number
                }
                else    // if text in combobox not exists
                {
                    if (GasStation.GasDeliverys.Where(x => x.Cars.Count > 0).Count() > 0)   // check all gd if there at least one car, if true select gd where minimum cars
                    {
                        int min = GasStation.GasDeliverys.Min(x => x.Cars.Count);
                        gdNum = GasStation.GasDeliverys.IndexOf(GasStation.GasDeliverys.Where(x => x.Cars.Count == min).Take(1).Single());
                    }
                    else     // if all gd clear take first
                    {
                        gdNum = 0;
                    }
                }

                SqlCommand cmdSelectCarID = new SqlCommand("select MAX(ID) from car", GlobalConnection.Connection); // select latest car id
                int carID = Convert.ToInt32(cmdSelectCarID.ExecuteScalar());

                SqlCommand cmdInsertServicing = new SqlCommand($"insert into servicing (gas_deliver_id, car_id, car_come_time) values ({ GasStation.GasDeliverys[gdNum].ID }, { carID }, GETDATE())", GlobalConnection.Connection);
                cmdInsertServicing.ExecuteNonQuery();

                GasStation.GasDeliverys[gdNum].Cars.Add(new Car(carID, cbCarType.Text, tbBrand.Text));

                chartMain.Series[0].Points.Clear();
                for (int i = 0; i < GasStation.GasDeliverys.Count; i++)
                {
                    chartMain.Series[0].Points.Add(GasStation.GasDeliverys[i].Cars.Count);
                    chartMain.Series[0].Points[i].AxisLabel = GasStation.GasDeliverys[i].Type + "-" + (i + 1);
                }

                cbComeColumn.Text = "";
                tbBrand.Text = "";


                ////////////////
                List<Car> cars = GetCars();
                ReculcParametersAndCharacteristicsManual(cars);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            string cmdText = "SELECT * FROM servicing WHERE car_come_time > @start";
            SqlCommand cmd = new SqlCommand(cmdText, GlobalConnection.Connection);
            cmd.Parameters.AddWithValue("@start", startTime.ToShortDateString() + " " + startTime.ToShortTimeString());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Car c = new Car(Convert.ToInt32(ds.Tables[0].Rows[i]["car_id"]));
                c.ComeTime = DateTime.Parse(ds.Tables[0].Rows[i]["car_come_time"].ToString());
                if (ds.Tables[0].Rows[i]["car_leave_time"].ToString() != "")
                {
                    c.LeaveTime = DateTime.Parse(ds.Tables[0].Rows[i]["car_leave_time"].ToString());
                }
                else
                {
                    c.LeaveTime = DateTime.MinValue;
                }
                c.GD = new GasDeliver(Convert.ToInt32(ds.Tables[0].Rows[i]["gas_deliver_id"]));
                cars.Add(c);
            }
            return cars;
        }
        private double GetMuFromDB(DateTime start)
        {
            //MessageBox.Show(start.ToLongDateString() + "\n" + start.ToLongTimeString() + "\n" + start.ToShortDateString() + "\n" + start.ToShortTimeString());

            //SqlCommand cmdd = new SqlCommand("select car_come_time from servicing", GlobalConnection.Connection);
            //MessageBox.Show(cmdd.ExecuteScalar().ToString());

            string cmdText = "select SUM(DATEDIFF(s, car_come_time, car_leave_time)) from servicing where car_come_time > @start and car_leave_time is not null";
            SqlCommand cmd = new SqlCommand(cmdText, GlobalConnection.Connection);
            //cmd.Parameters.AddWithValue("@start", "CONVERT(datetime, " + start.ToShortDateString() +  " " + start.ToShortTimeString() + ", 104)");
            cmd.Parameters.AddWithValue("@start", start.ToShortDateString() + " " + start.ToShortTimeString());
            //MessageBox.Show(start.ToShortDateString() + " " + start.ToShortTimeString());
            //MessageBox.Show(cmd.ExecuteScalar().ToString());
            double time = -1;
            object tmpForTime = cmd.ExecuteScalar();
            if(tmpForTime != DBNull.Value)
                time = Convert.ToDouble(tmpForTime) / 60; // возвращает время в секнудах, поэтому делим на 60 чтобы получить минуты

            //cmdText = "select COUNT(*) from servicing where car_come_time > @start and car_leave_time is not null";
            //cmd = new SqlCommand(cmdText, GlobalConnection.Connection);
            //cmd.Parameters.AddWithValue("@start", start);
            //int count = Convert.ToInt32(cmd.ExecuteScalar());

            return time;
        }
        List<double> timeMoments = new List<double>();
        List<int> Served = new List<int>();
        List<int> Rejected = new List<int>();
        List<int> Queue = new List<int>();
        List<double> DownTime = new List<double>();
        List<int> NumberOfBusyChanels = new List<int>();
        List<double> flow = new List<double>();
        List<double> service = new List<double>();
        Random rnd = new Random();
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
        public double NextExp(double Ly)
        {
            return -Math.Log(1 - rnd.NextDouble()) / Ly;
        }
        private int ChanelCount(double[] mastime, double time)
        {
            int res = 0;
            for (int i = 0; i < mastime.Length; i++)
                if (mastime[i] > time)
                    res++;
            return res;
        }
        private void Start(double T, double lambda, double mu, int n, int m)
        {

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

            //lbCharact.Items.Clear();
            //lbCharact.Items.Add("Кількість обслугованих: " + (Served.Count - rejCount).ToString());
            //lbCharact.Items.Add("Кількість Відмов: " + rejCount.ToString());
            //lbCharact.Items.Add("");


        }
        //private DateTime GetMinComeTime(GasStation gs)
        //{
        //    try
        //    {
        //        DateTime min = gs.GasDeliverys.Find(gd => gd.Cars.Count > 0).Cars[0].ComeTime;
        //        for (int i = 0; i < gs.GasDeliverys.Count; i++)
        //        {
        //            for (int j = 0; j < gs.GasDeliverys[i].Cars.Count; j++)
        //            {
        //                if (gs.GasDeliverys[i].Cars[j].ComeTime < min)
        //                {
        //                    min = gs.GasDeliverys[i].Cars[j].ComeTime;
        //                }
        //            }
        //        }
        //        return min;
        //    }
        //    catch
        //    {
        //        return DateTime.MinValue;
        //    }
        //}
        Servicing s;
        private void ReculcParametersAndCharacteristicsManual(List<Car> cars)
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
        private Servicing Start(List<Car> cars, int n)
        {
            List<DateTime> timeMoments = new List<DateTime>();
            List<int> Served = new List<int>();
            List<int> Queue = new List<int>();
            List<DateTime> DownTime = new List<DateTime>();
            List<int> NumberOfBusyChanels = new List<int>();

            List<Car> carsInGS = new List<Car>();



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
                if (cars.Min(car => car.ComeTime) < carsInGS.Where(car => car.LeaveTime != DateTime.MinValue).Min(car => car.LeaveTime))    // проверяю что случилось раньше, прибытие или отбытие машины
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
                    Car c = carsInGS.Find(cc => cc.LeaveTime == carsInGS.Min(car => car.LeaveTime));
                    carsInGS.Remove(c);
                    // culc queue
                    List<int> busyGD = carsInGS.Select(car => car.GD.ID).Distinct().ToList();
                    for (int i = 0; i < busyGD.Count; i++)
                    {
                        busyGD[i] = carsInGS.Count(car => car.GD.ID == busyGD[i]) - 1;   // ссчитаю сколько машин в очереди на каждой из колонок (-1 чтобы не учитывать ту что обслуживается)
                    }
                    Queue.Add(busyGD.Sum());
                    //
                    Served.Add(Served.Last() + 1);
                    DownTime.Add(busyGD.Count == n ? DownTime.Last() : DownTime.Last().Add(c.ComeTime - DownTime.Last()));
                    //DownTime.Add(DownTime.Last());
                    NumberOfBusyChanels.Add(busyGD.Count);
                }
            }

            return new Servicing() { TimeMoments = timeMoments, Served = Served, Queue = Queue, DownTime = DownTime, NumberOfBusyChanels = NumberOfBusyChanels };
        }
        private void ReCulcCharacteristics(double T, double lambda, double mu, int n, int m)
        {
            Start(T, lambda, mu, n, m);

            chartServicing.Series[0].Points.Clear();
            chartServicing.Series[1].Points.Clear();
            chartServicing.Series[2].Points.Clear();
            chartServicing.Series[3].Points.Clear();
            //chart2.Series[0].Points.Clear();

            chartServicing.ChartAreas[0].AxisX.Minimum = 0.0;
            chartServicing.ChartAreas[0].AxisX.Maximum = T;
            chartServicing.ChartAreas[0].AxisY.Minimum = 0.0;

            //chart2.ChartAreas[0].AxisX.Minimum = 0.0;
            //chart2.ChartAreas[0].AxisX.Maximum = T;

            for (int i = 0; i < timeMoments.Count; i++)
            {
                if (timeMoments[i] < T)
                {
                    chartServicing.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), Served[i]);
                    chartServicing.Series[1].Points.AddXY(Math.Round(timeMoments[i], 4), Rejected[i]);
                    chartServicing.Series[2].Points.AddXY(Math.Round(timeMoments[i], 4), Queue[i]);
                    chartServicing.Series[3].Points.AddXY(Math.Round(timeMoments[i], 4), NumberOfBusyChanels[i]);
                    //chart2.Series[0].Points.AddXY(Math.Round(timeMoments[i], 4), DownTime[i]);

                }
            }
            //StatistichniKharakteristiki();

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

        private void butCarLeave_Click(object sender, EventArgs e)
        {
            if (!CheckGasDeliverExistence())
            {
                MessageBox.Show("На станції повинна бути хоча б одна колонка!");
                return;
            }
            if (GasStation.GasDeliverys.All(gd => gd.Cars.Count == 0))
            {
                MessageBox.Show("Немає автомобілів!");
                return;
            }
            
            try
            {
                string capasity = tbCapasity.Text.Length > 0 ? tbCapasity.Text : null;
                int ID;
                if (cbLeaveColumn.Text.Length > 0)          // якщо задано номер колонки то з неї виїжає машина яка приїхала першою, якщо не задано, то виїжає машина яка приїхала першою взагалі (на будь-яку колонку)
                {
                    int gdID = Convert.ToInt32(cbLeaveColumn.Text);
                    SqlCommand cmd = new SqlCommand($"select id from servicing where id = (select MIN(id) from servicing where car_leave_time is null and gas_deliver_id = { gdID })", GlobalConnection.Connection);
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select id from servicing where id = (select MIN(id) from servicing where car_leave_time is null)", GlobalConnection.Connection);
                    ID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                SqlCommand cmdCarleave;
                if (capasity == null)
                {
                    cmdCarleave = new SqlCommand($"update servicing set car_leave_time = GETDATE(), capacity = null where id = { ID }", GlobalConnection.Connection);
                }
                else
                {
                    cmdCarleave = new SqlCommand($"update servicing set car_leave_time = GETDATE(), capacity = { capasity.Replace(',', '.') } where id = { ID }", GlobalConnection.Connection);
                }
                cmdCarleave.ExecuteNonQuery();

                int gdID1 = Convert.ToInt32(new SqlCommand($"select gas_deliver_id from servicing where id = { ID }", GlobalConnection.Connection).ExecuteScalar());
                GasDeliver GD = GasStation.GasDeliverys.Where(gd => gd.ID == gdID1).Take(1).Single();
                GD.Cars.Remove(
                    GD.Cars.Where(car => car.ID == Convert.ToInt32(new SqlCommand($"select car_id from servicing where id = { ID }", GlobalConnection.Connection).ExecuteScalar()))
                    .Take(1).Single());


                chartMain.Series[0].Points.Clear();
                for (int i = 0; i < GasStation.GasDeliverys.Count; i++)
                {
                    chartMain.Series[0].Points.Add(GasStation.GasDeliverys[i].Cars.Count);
                    chartMain.Series[0].Points[i].AxisLabel = GasStation.GasDeliverys[i].Type + "-" + (i + 1);
                }

                /////////
                List<Car> cars = GetCars();
                ReculcParametersAndCharacteristicsManual(cars);
                ///////////

                cbLeaveColumn.Text = "";
                tbCapasity.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void butModeling_Click(object sender, EventArgs e)
        {
            FormModeling f = new FormModeling();
            f.Show();
        }
        private void butAnalisysAZS_Click(object sender, EventArgs e)
        {

        }
        private void butShowServicing_Click(object sender, EventArgs e)
        {
            FormShowServicing f = new FormShowServicing(GasStation);
            f.Show();
        }
    }

    public struct Servicing
    {
        public List<DateTime> TimeMoments;
        public List<int> Served;
        public List<int> Queue;
        public List<DateTime> DownTime;
        public List<int> NumberOfBusyChanels;
        public List<int> Rejected;
    }
}