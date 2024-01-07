using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    internal class TV : ElectricDevice
    {
        public TV(bool isOn, string brand):base(isOn, brand) {}
        public void listenRadio()
        {
            if (isOn)
            {
                Console.WriteLine("Watching the TV.");
            }
            else
            {
                Console.WriteLine("TV is switched off, switch it on first.");
            }
        }

    }
}
