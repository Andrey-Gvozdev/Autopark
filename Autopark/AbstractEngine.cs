using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    abstract class AbstractEngine
    {
        private string engineName;
        private double taxByEngType;
        public string EngineName{ get { return engineName; } set { engineName = value; } }
        public double TaxByEngType { get { return taxByEngType; } set { taxByEngType = value; } }
        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }
        public AbstractEngine() { }
        public AbstractEngine(string engineName, double taxByEngType) 
        {
            this.engineName = engineName;
            this.taxByEngType = taxByEngType;
        }
        abstract public double GetMaxKilometers(double fuelTankCapacity);
    }
}
