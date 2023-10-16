using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsConsoleApp
{
    internal class Restuarant
    {
        public string Name;
        Service[] services;
        Drink[] drinks;
        Food[] foods;

        public Restuarant()
        {
            services = new Service[0];
            drinks = new Drink[0];
            foods = new Food[0];
        }

        public void AddFoodMenu(Food food)
        {
            if(food.Name.Length > 2 && food.Price >= 0 && food.PreparationTime >= 0)
            {
                Array.Resize(ref foods, foods.Length + 1);
                foods[foods.Length - 1] = food;

                Console.WriteLine("\nNew food added to menu");
            }
            else
            {
                Console.WriteLine("\nFood name should be more over 2 letter and price and preparation time should be a positive number!\n");
            }
        }
        public void AddDrinkMenu(Drink drink)
        {
            if (drink.Name.Length > 2 && drink.Price >= 0 && 
                drink.AlcoholPercentage >= 0 && drink.DeliveryTime >= 0)
            {
                Array.Resize(ref drinks, drinks.Length + 1);
                drinks[drinks.Length - 1] = drink;

                Console.WriteLine("\nNew drink added to menu!");
            }
            else
            {
                Console.WriteLine("\nFood name should be more over 2 letter and price, alcohol percentage and delivery time should be a positive number!\n");
            }
        }
        public void AddServiceMenu(Service service)
        {
            if (service.ServiceType.Length > 2 && service.Price >= 0)
            {
                Array.Resize(ref services, services.Length + 1);
                services[services.Length - 1] = service;

                Console.WriteLine("\nNew service added to menu!");
            }
            else
            {
                Console.WriteLine("\nService type should be more over 2 letter and price should be a positive number!\n");
            }
        }
        public Food[] GetAllFood()
        {
            return foods;
        }
        public Drink[] GetAllDrink() 
        { 
            return drinks; 
        }
        public Service[] GetAllService() 
        { 
            return services; 
        }


    }
}
