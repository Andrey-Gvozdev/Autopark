using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class Orders
    {
        string[] ordersArr;
        Dictionary<string, int> ordersDictionary = new Dictionary<string, int>();

        public Orders()
        {
            ordersArr = LoadArr("orders.csv");
            FillingDictionaryKeys();
            FillingDictionaryValues();
            Console.WriteLine("Active orders: ");
            foreach (var kek in ordersDictionary)
            {
                Console.WriteLine(string.Format("{0,-10}{1}", kek.Key, kek.Value));
            }
        }

        public void FillingDictionaryKeys()
        {
            foreach (var local in ordersArr)
            {
                if (local != null)
                {
                    if (!ordersDictionary.ContainsKey(local))
                    {
                        ordersDictionary.Add(local, 0);
                    }
                }
            }
        }

        string[] LoadArr(string inFile)
        {
            string[] localArr;
            string[] arr = new string[20];
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string localString;
                    int j = 0;
                    while ((localString = sr.ReadLine()) != null)
                    {
                        localArr = localString.Split(",");
                        for (int i = 0; i < localArr.Length; i++)
                        {
                            arr[j] = localArr[i];
                            j++;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Exeption! File {inFile} isn't found.");
            }

            return arr;
        }

        void FillingDictionaryValues()
        {
            ordersDictionary["maslo"] = 1;
            ordersDictionary["os'"] = 1;
            ordersDictionary["svecha"] = 4;
            ordersDictionary["filter"] = 2;
            ordersDictionary["vtylka"] = 4;
            ordersDictionary["val"] = 2;
            ordersDictionary["SHRYS"] = 2;
            ordersDictionary["GRM"] = 1;
        }





        //public Orders()
        //{
        //    ordersArr = FillingOrdersArr(LoadTempArr("orders.csv"));
        //    FillingDictionaryKeys();
        //    foreach (var kek in ordersDictionary)
        //    {
        //        Console.WriteLine(kek.Key);
        //    }
        //}

        //string[] LoadTempArr(string inFile)
        //{
        //    string[] localArr;
        //    string[] arr = { };
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
        //        {
        //            string localString;
        //            int j = 0;
        //            while ((localString = sr.ReadLine()) != null)
        //            {
        //                localArr = localString.Split(",");
        //                for (int i = 0; i < localArr.Length; i++)
        //                {
        //                    arr[j] = localArr[i];
        //                    j++;
        //                }
        //            }
        //        }
        //    }
        //    catch (FileNotFoundException)
        //    {
        //        Console.WriteLine($"Exeption! File {inFile} isn't found.");
        //    }

        //    return arr;
        //}

        //string[] FillingOrdersArr(string[] tempArr)
        //{
        //    string[] arr = { };
        //    int count = 0;
        //    int k = 0;

        //    for (int i = 0; i < tempArr.Length; i++)
        //    {
        //        for (int j = 0; j < arr.Length; j++)
        //        {
        //            if (arr[j] == tempArr[i])
        //            {
        //                count++;
        //            }
        //        }
        //        if (count == 0)
        //        {
        //            arr[k] = tempArr[i];
        //            k++;
        //        }
        //        count = 0;
        //    }

        //    return arr;
        //}

        //void FillingDictionaryKeys()
        //{
        //    foreach (var local in ordersArr)
        //    {
        //        ordersDictionary.Add(local, "");
        //    }
        //}


    }
}
