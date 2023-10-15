using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsConsoleApp
{
    internal class Food
    {
        public string Name;
        public double Price;
        public double PreparationTime;

        public Food(string name, double price, double preparationTime)
        {
            Name = name;
            Price = price;
            PreparationTime = preparationTime;
        }

    }
}
