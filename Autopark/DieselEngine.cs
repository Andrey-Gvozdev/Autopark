using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100)
            : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}
