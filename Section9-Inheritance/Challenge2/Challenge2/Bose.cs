using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Bose : Employee
    {
        public string CompanyCar {  get; set; }

        public Bose(string name, string firstname, float salary) : base(name, firstname, salary) { }

        public void Lead() {
            Console.WriteLine("{0} is now leading.", Name);
        }
    }
}
