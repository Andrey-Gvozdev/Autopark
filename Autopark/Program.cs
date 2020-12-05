using System;

namespace Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = new VehicleType("Bus", 1.2f);
            var car = new VehicleType("Car", 1.0f);
            var rink = new VehicleType("Rink", 1.5f);
            var tractor = new VehicleType("Tractor", 1.3f);
            VehicleType[] vehicleTypesArr = { bus, car, rink, tractor };

            var engineCar1 = new GasolineEngine(75, 8.1);
            var engineCar2 = new GasolineEngine(75, 8.5);
            var engineCar3 = new ElectricalEngine(50);
            engineCar3.EngineCapacity = 150;
            var engineCar4 = new DieselEngine(55, 7.2);
            var engineCar5 = new ElectricalEngine(25);
            engineCar5.EngineCapacity = 70;
            var engineCar6 = new DieselEngine(20, 25);
            var engineCar7 = new DieselEngine(135, 20.1);

            var car1 = new Vehicle(vehicleTypesArr[0], engineCar1, "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Vehicle.Colour.Blue);
            var car2 = new Vehicle(vehicleTypesArr[0], engineCar2, "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, Vehicle.Colour.White);
            var car3 = new Vehicle(vehicleTypesArr[0], engineCar3, "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Vehicle.Colour.Green);
            var car4 = new Vehicle(vehicleTypesArr[1], engineCar4, "Golf 5", "8682 AX-7", 1200, 2006, 230451, Vehicle.Colour.Gray);
            var car5 = new Vehicle(vehicleTypesArr[1], engineCar5, "Tesla Model S 70D", "E001 FF-7", 2200, 2019, 10454, Vehicle.Colour.White);
            var car6 = new Vehicle(vehicleTypesArr[2], engineCar6, "Hamm HD 12 VV", null, 3000, 2016, 122, Vehicle.Colour.Yellow);
            var car7 = new Vehicle(vehicleTypesArr[3], engineCar7, "МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Vehicle.Colour.Red);
            Vehicle[] vehicleArr = { car1, car2, car3, car4, car5, car6, car7};

            PrintVehicleTypes(vehicleTypesArr);
            Console.WriteLine();
            
            Console.WriteLine("Average tax is: " + CalcAverageTax(vehicleTypesArr));

            Console.WriteLine();
            Helper.ArrPrinter(vehicleTypesArr);
            
            Array.Sort(vehicleArr);

            Console.WriteLine();
            Helper.ArrPrinter(vehicleArr);

            Console.WriteLine();
            PrintMaxAndMinMileage(vehicleArr);

            Console.WriteLine();
            FindSameVehicles(vehicleArr);

            Console.WriteLine();
            PrintFurtherDrivingCar(vehicleArr);
        }

        private static void PrintFurtherDrivingCar(Vehicle[] arr)
        {
            int carNum = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1].engine.GetMaxKilometers(arr[i - 1].engine.EngineCapacity) < arr[i].engine.GetMaxKilometers(arr[i].engine.EngineCapacity))
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
