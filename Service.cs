using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsConsoleApp
{
    internal class Service
    {
        public string ServiceType;
        public double Price;

        public Service(string serviceType, double price)
        {
            ServiceType = serviceType;
            Price = price;
        }
    }
}
