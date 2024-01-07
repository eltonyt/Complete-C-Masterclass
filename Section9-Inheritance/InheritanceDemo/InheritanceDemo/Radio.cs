using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    internal class Radio : ElectricDevice
    {
        public Radio(bool isOn, string brand):base(isOn, brand) {}
        public void ListenRadio()
        {
            if (isOn)
            {
                Console.WriteLine("Listening to the radio");
            }
            else
            {
                Console.WriteLine("Radio is switched off, switch it on first.");
            }
        }
    }
}
