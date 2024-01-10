using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Trainee : Employee
    {
        public float WorkingHours {  get; set; }
        public float SchoolHours { get; set; }

        public Trainee(string name, string firstname, float salary) : base(name, firstname, salary) { }

        public void Learn()
        {
            Console.WriteLine("{0} is now learning.", Name);
        }

        public override void Work()
        {
            Console.WriteLine("{0} is working. Already worked {1} hours", Name, WorkingHours);
        }

    }
}
