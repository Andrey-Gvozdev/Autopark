using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Autopark
{
    class Vehicle : IComparable<Vehicle>
    {
        private string modelName;
        private string regNumber;
        private int weight;
        private int manufactureYear;
        private int mileage;
        Colour colour;
        public readonly AbstractEngine engine;
        private VehicleType type;
        public enum Colour
        {
            Blue,
            Green,
            Red,
            White,
            Gray,
            Yellow
        }
        public int Mileage { get { return mileage; } set { mileage = value; } }
        // объем бака(литры/киловатты)
        public Vehicle() { }
        public Vehicle(VehicleType type, AbstractEngine engine, string modelName, string regNumber, int weight, int manufactureYear, int mileage, Colour colour)
        {
            this.type = type;
            this.engine = engine;
            this.modelName = modelName;
            this.regNumber = regNumber;
            this.weight = weight;
            this.manufactureYear = manufactureYear;
            this.mileage = mileage;
            this.colour = colour;
        }
        public double GetCalcTaxPerManth()
        {
            double result;
            result = (weight * 0.0013) + (type.Tax * engine.TaxByEngType * 30) + 5;
            return result;
        }
        public override string ToString() => $"{type.MachineName}; {type.Tax}; {engine.EngineName}({engine.FuelConsumptionPer100},{engine.EngineCapacity}); {modelName}; {regNumber}; {weight}; {manufactureYear}; {mileage}; {colour}; {GetCalcTaxPerManth().ToString("0.00")}";
        public int CompareTo(Vehicle secondVehicle)
        {
            if (GetCalcTaxPerManth() < secondVehicle.GetCalcTaxPerManth())
                return -1;
            else if (GetCalcTaxPerManth() > secondVehicle.GetCalcTaxPerManth())
                return 1;
            else
                return 0;
        }
        public override bool Equals(object obj)
        {
            if (obj is Vehicle && obj != null)
            {
                Vehicle localVehicle = (Vehicle)obj;
                if (this.type == localVehicle.type && this.modelName == localVehicle.modelName)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
