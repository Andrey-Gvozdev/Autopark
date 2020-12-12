using System;
using System.Collections.Generic;
using System.IO;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new VehicleType(1, "Bus", 1.2f);
            var car = new VehicleType(2, "Car", 1.0f);
            var rink = new VehicleType(3, "Rink", 1.5f);
            var tractor = new VehicleType(4, "Tractor", 1.3f);
            VehicleType[] vehicleTypesArr = { bus, car, rink, tractor };

            var car1 = new Vehicle(1, vehicleTypesArr[0], new GasolineEngine(8.1, 2), "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Vehicle.Colour.Blue, 75, new List<Rent>());
            var car2 = new Vehicle(2, vehicleTypesArr[0], new GasolineEngine(8.5, 2.18), "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Vehicle.Colour.White, 75, new List<Rent>());
            var car3 = new Vehicle(3, vehicleTypesArr[0], new ElectricalEngine(50), "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Vehicle.Colour.Green, 150, new List<Rent>());
            var car4 = new Vehicle(4, vehicleTypesArr[1], new DieselEngine(7.2, 1.6), "Golf 5", "8682 AX-7", 1200, 2006, 230451, Vehicle.Colour.Gray, 55, new List<Rent>());
            var car5 = new Vehicle(5, vehicleTypesArr[1], new ElectricalEngine(25), "Tesla Model S 70D", "E001 FF-7", 2200, 2019, 10454, Vehicle.Colour.White, 70, new List<Rent>());
            var car6 = new Vehicle(6, vehicleTypesArr[2], new DieselEngine(25, 3.2), "Hamm HD 12 VV", null, 3000, 2016, 122, Vehicle.Colour.Yellow, 20, new List<Rent>());
            var car7 = new Vehicle(7, vehicleTypesArr[3], new DieselEngine(20.1, 4.75), "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Vehicle.Colour.Red, 135, new List<Rent>());
            Vehicle[] vehicleArr = { car1, car2, car3, car4, car5, car6, car7};

            PrintVehicleTypes(vehicleTypesArr);
            Console.WriteLine("###########################");

            Console.WriteLine("Average tax is: " + CalcAverageTax(vehicleTypesArr));

            Console.WriteLine("###########################");
            Helper.ArrPrinter(vehicleTypesArr);

            Array.Sort(vehicleArr);

            Console.WriteLine("###########################");
            Helper.ArrPrinter(vehicleArr);

            Console.WriteLine("###########################");
            PrintMaxAndMinMileage(vehicleArr);

            Console.WriteLine("###########################");
            FindSameVehicles(vehicleArr);

            Console.WriteLine("###########################");
            PrintFurtherDrivingCar(vehicleArr);

            Console.WriteLine("###########################");
            Collections collection = new Collections(@"types.csv", @"rents.csv", @"vehicles.csv");

            Comparer kek = new Comparer();
            collection.Print();
            collection.Insert(-1, new Vehicle(collection.VehicleList.Count + 1, vehicleTypesArr[1], new DieselEngine(27, 4.2), "Mashinka", "0001", 1233, 2021, 345, Vehicle.Colour.Red, 700, new List<Rent>()));
            collection.Delete(1);
            collection.Delete(4);
            Console.WriteLine("###########################");
            collection.Print();
            collection.Sort(kek);
            Console.WriteLine("###########################");
            collection.Print();

            Console.WriteLine("###########################");
            Carwash carWashing = new Carwash();

            Console.WriteLine("###########################");
            Garage garage = new Garage();

            Orders oders = new Orders();
        }

        private static void PrintFurtherDrivingCar(Vehicle[] arr)
        {
            int carNum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].engine.GetMaxKilometers(arr[i - 1].TankCapacity) < arr[i].engine.GetMaxKilometers(arr[i].TankCapacity))
                {
                    carNum = i;
                }
            }
            Console.WriteLine("A car that can travel a long distance: " + arr[carNum]);
        }
        private static void FindSameVehicles(Vehicle[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i].Equals(arr[i - 1]))
                {
                    Console.WriteLine("Vehicles are the same: ");
                    Console.WriteLine(arr[i - 1].ToString());
                    Console.WriteLine(arr[i].ToString());
                }
            }
        }

        private static void PrintMaxAndMinMileage(Vehicle[] arr)
        {
            int maxMileage = 0;
            int minMileage = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (maxMileage < arr[i].Mileage)
                    maxMileage = arr[i].Mileage;
                if (minMileage > arr[i].Mileage)
                    minMileage = arr[i].Mileage;
                if (i == arr.Length - 1)
                {
                    Console.WriteLine("Max mileage: " + maxMileage);
                    Console.WriteLine("Min mileage: " + minMileage);
                }
            }
        }

        private static void PrintVehicleTypes(VehicleType[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Display(arr[i].MachineName, arr[i].Tax);
            }
        }

        private static double CalcAverageTax(VehicleType[] arr)
        {
            float maxTax = 0.0f;
            float averageTaxs = 0.0f;

            for (int i = 0; i < arr.Length; i++)
            {
                maxTax = (maxTax < arr[i].Tax) ? arr[i].Tax : maxTax;
                averageTaxs += arr[i].Tax;
            }
            return averageTaxs /= arr.Length;
        }
    }
}
