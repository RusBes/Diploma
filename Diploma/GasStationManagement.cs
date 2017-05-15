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
        public List<Employee> Employees { get; set; }
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
        public GasDeliverType Type { get; private set; }

        public GasDeliver() { }
        public GasDeliver(GasDeliverType type)
        {
            Type = type;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public EmployeePosition Position { get; set; }

        public Employee() { }
        public Employee(string name, EmployeePosition pos)
        {
            Name = name;
            Position = pos;
        }
    }

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
