using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsConsoleApp
{
    internal class Drink
    {
        public string Name;
        public double Price;
        public double AlcoholPercentage;
        public double DeliveryTime;

        public Drink(string name, double price, double alcoholPercentage, double deliveryTime)
        {
            Name = name;
            Price = price;
            AlcoholPercentage = alcoholPercentage;
            DeliveryTime = deliveryTime;
        }
    }
}
