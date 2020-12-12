using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark
{
    class Rent
    {
        private DateTime rentDate;
        private double rentCost;
        public DateTime RentDate{get{ return rentDate; } set{ rentDate = value; } }
        public double RentCost { get { return rentCost; } set { rentCost = value; } }

        public Rent() { }
        public Rent(DateTime rentDate, double rentCost)
        {
            this.rentDate = rentDate;
            this.rentCost = rentCost;
        }
    }
}
