using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    internal class ElectricDevice
    {
        public bool isOn { get; set; }
        public string Brand { get; set; }

        public ElectricDevice(bool isOn, string brand)
        {
            this.isOn = isOn;
            this.Brand = brand;
        }

        public void SwitchOn()
        {
            isOn = true;
        }

        public void SwitchOff()
        {
            isOn = false;
        }
    }
}
