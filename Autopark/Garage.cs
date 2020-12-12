using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class Garage
    {
        public Garage()
        {
            FillingStack();
            Washing();
        }

        Stack<Vehicle> VehicleStack = new Stack<Vehicle>();
        Collections collection = new Collections(@"types.csv", @"rents.csv", @"vehicles.csv");

        public void FillingStack()
        {
            foreach (var local in collection.VehicleList)
            {
                VehicleStack.Push(local);
                Console.WriteLine("Car[" + (collection.VehicleList.IndexOf(local) + 1) + "] drove into the garage.");
            }
            Console.WriteLine("All cars are parked in the garage.");
        }

        public void Washing()
        {
            int length = VehicleStack.Count;
            for (int i = length; i > 0; i--)
            {
                VehicleStack.Pop();
                Console.WriteLine("Car[" + (i) + "] left the garage.");
            }
        }
    }
}
