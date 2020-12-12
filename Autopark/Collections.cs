using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class Collections
    {
        public List<VehicleType> VehicleTypesList { get; set; }
        public List<Vehicle> VehicleList { get; set; }

        public Collections(string types, string rents, string vehicles)
        {
            VehicleTypesList = LoadTypes(types);
            //foreach (var kek in VehicleTypesList)
            //{
            //    Console.WriteLine(kek.ToString());
            //}
            VehicleList = LoadVehicles(vehicles);
            //foreach (var kek in VehicleList)
            //{
            //    Console.WriteLine(kek.ToString());
            //}
            LoadRents(rents);
        }

        List<VehicleType> LoadTypes(string inFile)
        {
            List<VehicleType> localList = new List<VehicleType>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string localString;
                    while((localString = sr.ReadLine()) != null)
                    {
                        localList.Add(CreateType(localString));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@$"Exeption! File ""{inFile}"" isn't found.");
            }

            return localList;
        }

        List<Vehicle> LoadVehicles(string inFile)
        {
            List<Vehicle> localList = new List<Vehicle>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string localString;
                    while ((localString = sr.ReadLine()) != null)
                    {
                        localList.Add(CreateVehicle(localString));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Exeption! File {inFile} isn't found.");
            }

            return localList;
        }

        public void LoadRents(string inFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string localString;
                    while ((localString = sr.ReadLine()) != null)
                    {
                        string[] s = localString.Split(",");
                        foreach (var vehicle in VehicleList)
                        {
                            if (vehicle.Id == int.Parse(s[0]))
                            {
                                vehicle.RentList.Add(new Rent(DateTime.Parse(s[1]), double.Parse(s[2], System.Globalization.CultureInfo.InvariantCulture)));
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Exeption! File {inFile} isn't found.");
            }
        }

        public VehicleType CreateType(string csvString)
        {
            string[] s = csvString.Split(",");
            return new VehicleType(int.Parse(s[0]), s[1], float.Parse(s[2], System.Globalization.CultureInfo.InvariantCulture));
        }

        public Vehicle CreateVehicle(string csvString)
        {
            string[] s = csvString.Split(",");
            List<VehicleType> localTypes = LoadTypes(@"types.csv");
            AbstractEngine localEngine = null;
            Vehicle.Colour localColour = (Vehicle.Colour)Enum.Parse(typeof(Vehicle.Colour), s[7]);
            if (s[8] == "Electrical")
            {
                localEngine = new ElectricalEngine(int.Parse(s[9]));
            }
            else if (s[8] == "Gasoline")
            {
                localEngine = new GasolineEngine(double.Parse(s[10], System.Globalization.CultureInfo.InvariantCulture), double.Parse(s[9], System.Globalization.CultureInfo.InvariantCulture));
            }
            else if (s[8] == "Diesel")
            {
                localEngine = new DieselEngine(double.Parse(s[10], System.Globalization.CultureInfo.InvariantCulture), double.Parse(s[9], System.Globalization.CultureInfo.InvariantCulture));
            }

            return new Vehicle(int.Parse(s[0]), localTypes[int.Parse(s[1]) - 1], localEngine, s[2], s[3], int.Parse(s[4]), int.Parse(s[5]), int.Parse(s[6]), localColour, int.Parse(s[11]), new List<Rent>());
        }

        public void Insert(int index, Vehicle v)
        {
            try
            {
                VehicleList.Insert(index, v);
            }
            catch (ArgumentOutOfRangeException)
            {
                VehicleList.Add(v);
            }
        }

        public int Delete(int index)
        {
            try
            {
                VehicleList.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                return -1;
            }
            return index;
        }

        public double SumTotalProfit()
        {
            double sumProfit = 0;

            foreach (var vehicle in VehicleList)
            {
                sumProfit += vehicle.GetTotalProfit();
            }
            
            return sumProfit;
        }

        public void Print()
        {
            //Console.WriteLine(string.Format("ID,-5Type,-10Number,-25Weight (kg),-15Year,-10Milleage,-10Colour,-10Income,-10Tax,-10Profit,-10"));
            foreach (var vehicle in VehicleList)
            {
                Console.WriteLine(string.Format("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                    vehicle.Id,
                    vehicle.Type.MachineName,
                    vehicle.ModelName,
                    vehicle.RegNumber,
                    vehicle.Weight,
                    vehicle.ManuFactureYear,
                    vehicle.Mileage,
                    vehicle.ColourRead,
                    vehicle.GetTotalIncome().ToString("0.00"),
                    vehicle.GetCalcTaxPerManth().ToString("0.00"),
                    vehicle.GetTotalProfit().ToString("0.00")
                )) ;
            }
            Console.WriteLine(string.Format("Total {0,-10}", SumTotalProfit().ToString("0.00")));
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            var d = VehicleList.Count / 2;
            while (d >= 1)
            {
                for (var i = d; i < VehicleList.Count; i++)
                {
                    var j = i;
                    while ((j >= d) && (comparator.Compare(VehicleList[j - d], VehicleList[j]) == -1))
                    {
                        var temp = VehicleList[j];
                        VehicleList[j] = VehicleList[j - d];
                        VehicleList[j - d] = temp;
                        j = j - d;
                    }
                }
                d = d / 2;
            }
        }
    }
}
