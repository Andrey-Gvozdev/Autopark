using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class VehicleType
    {
        private string machineName;
        private float tax;

        public VehicleType(string machineName, float tax)
        {
            this.machineName = machineName;
            this.tax = tax;
        }

        public string MachineName { get { return machineName; } set { machineName = value; } }
        public float Tax { get { return tax; } set { tax = value; } }

        public VehicleType() { }
        public void Display(string machineName, float tax)
        {
            Console.WriteLine($"TypeName = {machineName}");
            Console.WriteLine($"TaxCoefficient = {tax}");
        }

        public override string ToString() => $"{machineName};{tax}";
    }
}
