using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section6
{
    internal class Car
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
            set { if (value != null && value.Length > 0) _name = value;
                else _name = "Unknown";
            } 
        }
        public Car() 
        {
            Console.WriteLine("Car was created.");
        }

        public void Drive()
        {
            Console.WriteLine("Car is driving.");
        }
    }
}
