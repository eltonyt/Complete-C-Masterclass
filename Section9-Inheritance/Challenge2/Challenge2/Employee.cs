using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Employee
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public float Salary { get; set; }

        public bool IsWorking { get; set; }

        public Employee(string name, string firstName, float salary) { 
            this.Name = name;
            this.FirstName = firstName;
            this.Salary = salary;
        }

        public virtual void Work() { 
            if (IsWorking) 
                Console.WriteLine("{0} is working already.", Name);
            else
            {
                IsWorking = true;
                Console.WriteLine("{0} starts to work.", Name);
            }
        }

        public void Pause()
        {
            if (IsWorking)
            {
                Console.WriteLine("{0} pauses working.", Name);
                IsWorking = false;
            }
            else
            {
                Console.WriteLine("{0} is not working.", Name);
            }
        }
    }
}
