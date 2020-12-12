using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Autopark
{
    class Comparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            var xName = x.ModelName.ToCharArray();
            var firsLetterX = xName[0];
            var yName = y.ModelName.ToCharArray();
            var firsLetterY = yName[0];

            if (firsLetterX > firsLetterY)
            {
                return -1;
            }
            else if (firsLetterX < firsLetterY)
            {
                return 1;
            }
            else
            {
                return 0;
            }  
        }
    }
}
