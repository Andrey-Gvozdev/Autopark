using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class AbstractCombustionEngine : AbstractEngine
    {
        public AbstractCombustionEngine(string typeName, double taxCoefficient)
            : base(typeName, taxCoefficient) { }
        public override double  GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}
