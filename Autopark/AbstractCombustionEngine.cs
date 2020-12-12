using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class AbstractCombustionEngine : AbstractEngine
    {
        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }

        public AbstractCombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient) { }

        public override double  GetMaxKilometers(double TankCapacity)
        {
            return TankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}
