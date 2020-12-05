using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class ElectricalEngine : AbstractEngine
    {
        private double electricityConsumption;
        public double ElectricityConsumption { get { return electricityConsumption; } set { electricityConsumption = value; } }
        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1)
        {
            this.electricityConsumption = electricityConsumption;
        }
        public override double GetMaxKilometers(double batterySize)
        {
            return batterySize / electricityConsumption;
        }
    }
}
