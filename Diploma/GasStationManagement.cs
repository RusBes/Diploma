using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma
{
    public class GasStation
    {
        public int ID { get; set; }
        public List<GasDeliver> GasDeliverys { get; set; }
        //public List<Employee> Employees { get; set; }
        public string Location { get; set; }
        public string Brand { get; set; }

        public GasStation() { }
        public GasStation(int id, string loc, string brand)
        {
            ID = id;
            Location = loc;
            Brand = brand;
        }

    }

    
    public class GasDeliver
    {
        //public delegate void CarAddEventHandler();
        //public event CarAddEventHandler CarAdd;

        public int ID { get; private set; }
        public string Type { get; private set; }
        public List<Car> Cars { get; }

        public GasDeliver(int id) : this(id, "") { }
        public GasDeliver(int id, string type)
        {
            ID = id;
            Type = type;
            Cars = new List<Car>();
        }

        //public void AddCar(Car car)
        //{
        //    Cars.Add(car);
        //    CarAdd();
        //}
    }

    public class Car
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public DateTime ComeTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public GasDeliver GD { get; set; }

        public Car(int id, string type, string brand)
        {
            ID = id;
            Type = type;
            Brand = brand;
        }
        public Car(int id) : this(id, "", "") { }
    }

    //public class Employee
    //{
    //    public string Name { get; set; }
    //    public string Position { get; set; }

    //    public Employee() { }
    //    public Employee(string name, string pos)
    //    {
    //        Name = name;
    //        Position = pos;
    //    }
    //}

    public enum GasDeliverType
    {
        Fuel,
        Gas,
        None
    }
    public enum EmployeePosition
    {
        Refueler,
        Cassier
    }
}
