using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class Carwash
    {
        public Carwash()
        {
            FillingQueue();
            Washing();
        }

        Queue<Vehicle> VehicleQueue = new Queue<Vehicle>();
        Collections collection = new Collections(@"types.csv", @"rents.csv", @"vehicles.csv");
        
        public void FillingQueue()
        {
            foreach (var local in collection.VehicleList)
            {
                VehicleQueue.Enqueue(local);
                Console.WriteLine("Car[" + (collection.VehicleList.IndexOf(local) + 1) + "] added to the queue.");
            }
        }
        
        public void Washing()
        {
            int length = VehicleQueue.Count;
            for (int i = 0; i < length; i++)
            {
                VehicleQueue.Dequeue();
                Console.WriteLine("Car[" + (i + 1) + "] washed.");
            }
        }
        
        
        
        
        //Queue<VehicleType> LoadTypes(string inFile)
        //{
        //    Queue<VehicleType> localQueue = new Queue<VehicleType>();
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
        //        {
        //            string localString;
        //            while ((localString = sr.ReadLine()) != null)
        //            {
        //                localQueue.Enqueue(CreateType(localString));
        //            }
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine(@$"Exeption! File ""{inFile}"" isn't found.");
        //    }

        //    return localQueue;
        //}
        //public VehicleType CreateType(string csvString)
        //{
        //    string[] s = csvString.Split(",");
        //    return new VehicleType(int.Parse(s[0]), s[1], float.Parse(s[2], System.Globalization.CultureInfo.InvariantCulture));
        //}
        //public Vehicle CreateVehicle(string csvString)
        //{
        //    string[] s = csvString.Split(",");
        //    Queue<VehicleType> localTypes = LoadTypes(@"types.csv");
        //    AbstractEngine localEngine = null;
        //    Vehicle.Colour localColour = (Vehicle.Colour)Enum.Parse(typeof(Vehicle.Colour), s[7]);
        //    if (s[8] == "Electrical")
        //    {
        //        localEngine = new ElectricalEngine(int.Parse(s[9]));
        //    }
        //    else if (s[8] == "Gasoline")
        //    {
        //        localEngine = new GasolineEngine(double.Parse(s[10], System.Globalization.CultureInfo.InvariantCulture), double.Parse(s[9], System.Globalization.CultureInfo.InvariantCulture));
        //    }
        //    else if (s[8] == "Diesel")
        //    {
        //        localEngine = new DieselEngine(double.Parse(s[10], System.Globalization.CultureInfo.InvariantCulture), double.Parse(s[9], System.Globalization.CultureInfo.InvariantCulture));
        //    }

        //    return new Vehicle(int.Parse(s[0]), localTypes[int.Parse(s[1]) - 1], localEngine, s[2], s[3], int.Parse(s[4]), int.Parse(s[5]), int.Parse(s[6]), localColour, int.Parse(s[11]), new List<Rent>());
        //}
    }
}
