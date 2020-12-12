using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Autopark
{
    class Vehicle : IComparable<Vehicle>
    {
        private int id;
        private string modelName;
        private string regNumber;
        private int weight;
        private int manufactureYear;
        private int mileage;
        private double tankCapacity;
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
        public int Id { get { return id; } }
        public string ModelName { get { return modelName; } }
        public VehicleType Type { get { return type; } }
        public string RegNumber { get { return regNumber; } }
        public int Weight { get { return weight; } }
        public int ManuFactureYear { get { return manufactureYear; } }
        public Colour ColourRead { get { return colour; } }
        public List<Rent> RentList { get; set; }
        public int Mileage { get { return mileage; } set { mileage = value; } }
        public double TankCapacity { get { return tankCapacity; } set { tankCapacity = value; } }
        
        public Vehicle() { }
        public Vehicle(int id, VehicleType type, AbstractEngine engine, string modelName, string regNumber, int weight, int manufactureYear, int mileage, Colour colour, int tankCapacity, List<Rent> RentList)
        {
            this.id = id;
            this.type = type;
            this.engine = engine;
            this.modelName = modelName;
            this.regNumber = regNumber;
            this.weight = weight;
            this.manufactureYear = manufactureYear;
            this.mileage = mileage;
            this.colour = colour;
            this.tankCapacity = tankCapacity;
            this.RentList = RentList;
        }
        
        public double GetCalcTaxPerManth()
        {
            double result;
            result = (weight * 0.0013) + (type.Tax * engine.TaxByEngType * 30) + 5;
            return result;
        }
        
        public override string ToString() => $"{id}; {type.MachineName}; {type.Tax}; {engine.EngineName}; {modelName}; {regNumber}; {weight}; {manufactureYear}; {mileage}; {colour}"; //; {GetCalcTaxPerManth().ToString("0.00")}
        
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

        public double GetTotalIncome()
        {
            double rentSum = 0;
            foreach (var rent in RentList)
            {
                rentSum += rent.RentCost;
            }
            return rentSum;
        }

        public double GetTotalProfit()
        {
            return GetTotalIncome() - GetCalcTaxPerManth();
        }
    }
}
