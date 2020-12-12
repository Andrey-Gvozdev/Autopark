using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class VehicleType
    {
        private string machineName;
        private float tax;
        private int id;

        public VehicleType() { }
        public VehicleType(int id, string machineName, float tax)
        {
            this.id = id;
            this.machineName = machineName;
            this.tax = tax;
        }

        public string MachineName { get { return machineName; } set { machineName = value; } }
        public float Tax { get { return tax; } set { tax = value; } }

        public void Display(string machineName, float tax)
        {
            Console.WriteLine($"TypeName = {machineName}");
            Console.WriteLine($"TaxCoefficient = {tax}");
        }

        public override string ToString() => $"{id};{machineName};{tax}";
    }
}
