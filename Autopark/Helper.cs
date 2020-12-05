using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    static class Helper
    {
        public static void ArrPrinter(object[] arr)
        {
            foreach (var obj in arr)
                Console.WriteLine(obj.ToString());
        }
    }
}
