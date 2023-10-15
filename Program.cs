namespace RestaurantsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restuarant restuarant = new Restuarant();
            bool running = true;

            Console.WriteLine("============== Restaurant Console App ==============\n");
            do
            {
                if(restuarant.Name == null)
                {
                    Console.WriteLine("\n    ========= Create a Restuarant =========");
                    Console.WriteLine("\t1. Create your restuarant");
                    Console.WriteLine("\t0. Exit");
                    Console.Write("\n\tPlease, enter a choice(0-1): ");
                    string userChoice2 = Console.ReadLine();

                    if (userChoice2 == "0")
                    {
                        running = false;
                    }
                    else if (int.TryParse(userChoice2, out int choice2))
                    {
                        FirstAppMenu(restuarant, choice2);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice, you should be press numbers!");
                    }

                }
                else
                {
                    Console.WriteLine($"\n\t============ {restuarant.Name} ============\n");
                    Console.WriteLine("\t1. Add food");
                    Console.WriteLine("\t2. Add drink");
                    Console.WriteLine("\t3. Add service");
                    Console.WriteLine("\t4. Show all Menu");
                    Console.WriteLine("\t5. Search menu by Price");
                    Console.WriteLine("\t6. Search for drinks by alcohol percentage");
                    Console.WriteLine("\t7. Search for dishes by preparation time");
                    Console.WriteLine("\t8. Search by service type");
                    Console.WriteLine("\t0. Exit");
                    Console.Write("\n\tPlease, enter a choice(0-8): ");
                    string userChoice = Console.ReadLine();
                    if(int.TryParse(userChoice, out int choice))
                    {
                        SecondAppMenu(restuarant, choice);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice, you should be press numbers!");
                    }
                }
            } while (running);
            Console.WriteLine("\n\t    Program has been stopped!\n");
            Console.WriteLine("====================================================");
        }

        public static void FirstAppMenu(Restuarant restuarant, int choice)
        {
            switch (choice)
            {
                case 1:
                    CreateARestuarant(restuarant);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again!");
                    break;
            }
        }
        public static void CreateARestuarant(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Create Restuarant Section ======\n");
            PATH1:
            Console.Write("\nRestuarant name: ");
            string resturantName = Console.ReadLine();
            if(resturantName.Length >= 3)
            {
                restuarant.Name = resturantName;
            }
            else
            {
                Console.WriteLine("\nResturant name should be more over 2 letter!");
                goto PATH1;
            }
        }
        public static void SecondAppMenu(Restuarant restuarant, int choice)
        {
            switch(choice)
            {
                case 1:
                    AddFood(restuarant);
                    break;
                case 2:
                    AddDrink(restuarant);
                    break;
                case 3:
                    AddService(restuarant);
                    break;
                case 4:
                    RestuarantMenu(restuarant);
                    break;
                case 5:
                    MenuRelatedPrice(restuarant);
                    break;
                case 6:
                    GetDrinksByAlcohol(restuarant);
                    break;
                case 7:
                    GetInfosByPreparationTime(restuarant);
                    break;
                case 8:
                    GetInfoByService(restuarant);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again!");
                    break;
            }
        }

        public static void AddFood(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Add Food Section ======\n");
            Console.Write("Food name: ");
            string foodName = Console.ReadLine();
            Console.Write("Food price: ");
            double foodAmount = double.Parse(Console.ReadLine());
            Console.Write("Food preparation time: ");
            double foodPreparationTime = double.Parse(Console.ReadLine());

            Food food = new Food(foodName, foodAmount, foodPreparationTime);

            restuarant.AddFoodMenu(food);
        }
        public static void AddDrink(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Add Drink Section ======\n");
            Console.Write("Drink name: ");
            string drinkName = Console.ReadLine();
            Console.Write("Drink price: ");
            double drinkPrice = double.Parse(Console.ReadLine());
            Console.Write("Drink delivery time: ");
            double drinkDeliveryTime = double.Parse(Console.ReadLine());
            Console.Write("Drink alcohol percentage: ");
            double drinkAlcoholPercentage = double.Parse(Console.ReadLine());

            Drink drink = new Drink(drinkName, drinkPrice, drinkDeliveryTime, drinkAlcoholPercentage);

            restuarant.AddDrinkMenu(drink);
        }
        public static void AddService(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Add Service Section ======\n");
            Console.Write("Service type: ");
            string serviceType = Console.ReadLine();
            Console.Write("Service price: ");
            double serviceAmount = double.Parse(Console.ReadLine());

            Service service = new Service(serviceType, serviceAmount);

            restuarant.AddServiceMenu(service);
        }


        public static void RestuarantMenu(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Restuarant Menu Section ======\n");
            Console.WriteLine("\t1. Food menu");
            Console.WriteLine("\t2. Drink menu");
            Console.WriteLine("\t3. Service menu");
            PATH5:
            Console.Write("\n\tUser choice: ");
            string userChoice = Console.ReadLine();
            if (int.TryParse(userChoice, out int choice))
            {
                switch (userChoice)
                {
                    case "1":
                        GetFoods(restuarant);
                        break;
                    case "2":
                        GetDrinks(restuarant);
                        break;
                    case "3":
                        GetServices(restuarant);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, you should be press numbers!\n");
                goto PATH5;
            }
            
        }
        public static void GetFoods(Restuarant restuarant)
        {
            Console.WriteLine();
            foreach (var item in restuarant.GetAllFood())
            {
                Console.WriteLine($"Food name: {item.Name}");
                Console.WriteLine($"Food price: {item.Price}");
                Console.WriteLine($"Food preparation time: {item.PreparationTime}");
            }
        }
        public static void GetDrinks(Restuarant restuarant)
        {
            Console.WriteLine();
            foreach (var item in restuarant.GetAllDrink())
            {
                Console.WriteLine($"Drink name: {item.Name}");
                Console.WriteLine($"Drink alcohol percentage: {item.AlcoholPercentage}");
                Console.WriteLine($"Drink price: {item.Price}");
                Console.WriteLine($"Drink delivery time: {item.DeliveryTime}");
            }
        }
        public static void GetServices(Restuarant restuarant)
        {
            Console.WriteLine();
            foreach (var item in restuarant.GetAllService())
            {
                Console.WriteLine($"Service type: {item.ServiceType}");
                Console.WriteLine($"Service price: {item.Price}");
            }
        }


        public static void MenuRelatedPrice(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Menu Search Section ======\n");
            Console.WriteLine("\t1. Food menu");
            Console.WriteLine("\t2. Drink menu");
            Console.WriteLine("\t3. Service menu");
            Console.Write("\n\tUser choice: ");
            string userChoice = Console.ReadLine();
            if (int.TryParse(userChoice, out int choice))
            {
                switch (userChoice)
                {
                    case "1":
                        GetFoodsPrice(restuarant);
                        break;
                    case "2":
                        GetDrinksPrice(restuarant);
                        break;
                    case "3":
                        GetServicesPrice(restuarant);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, you should be press numbers!");
            }
        }
        public static void GetFoodsPrice(Restuarant restuarant)
        {
            Console.WriteLine("\nPlease, enter minimum and maximum price for search!\n");
            Console.Write("Minimum price: ");
            double minPrice = double.Parse(Console.ReadLine());
            Console.Write("Maximum price: ");
            double maxPrice = double.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (var item in restuarant.GetAllFood())
            {
                if(item.Price >= minPrice && item.Price <= maxPrice)
                {
                    Console.WriteLine($"Food name: {item.Name}");
                    Console.WriteLine($"Food price: {item.Price}");
                    Console.WriteLine($"Food preparation time: {item.PreparationTime}");
                }
            }
        }
        public static void GetDrinksPrice(Restuarant restuarant)
        {
            Console.WriteLine("\nPlease, enter minimum and maximum price for search!\n");
            Console.Write("Minimum price: ");
            double minPrice = double.Parse(Console.ReadLine());
            Console.Write("Maximum price: ");
            double maxPrice = double.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (var item in restuarant.GetAllDrink())
            {
                if (item.Price >= minPrice && item.Price <= maxPrice)
                {
                    Console.WriteLine($"Drink name: {item.Name}");
                    Console.WriteLine($"Drink alcohol percentage: {item.AlcoholPercentage}");
                    Console.WriteLine($"Drink price: {item.Price}");
                    Console.WriteLine($"Drink delivery time: {item.DeliveryTime}");
                }
            }
        }
        public static void GetServicesPrice(Restuarant restuarant)
        {
            Console.WriteLine("\nPlease, enter minimum and maximum price for search!\n");
            Console.Write("Minimum price: ");
            double minPrice = double.Parse(Console.ReadLine());
            Console.Write("Maximum price: ");
            double maxPrice = double.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (var item in restuarant.GetAllService())
            {
                if (item.Price >= minPrice && item.Price <= maxPrice)
                {
                    Console.WriteLine($"Service type: {item.ServiceType}");
                    Console.WriteLine($"Service price: {item.Price}");
                }
            }
        }


        public static void GetDrinksByAlcohol(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Get Drinks by Alcohol Section ======\n");
            Console.WriteLine("\nPlease, enter alcohol percentage!\n");
            Console.Write("Alcohol percentage: ");
            double alcoholPercentage = double.Parse(Console.ReadLine());

            if(alcoholPercentage > 0)
            {
                Console.WriteLine();
                foreach (var item in restuarant.GetAllDrink())
                {
                    if (item.AlcoholPercentage == alcoholPercentage)
                    {
                        Console.WriteLine($"Drink name: {item.Name}");
                        Console.WriteLine($"Drink alcohol percentage: {item.AlcoholPercentage}");
                        Console.WriteLine($"Drink price: {item.Price}");
                        Console.WriteLine($"Drink delivery time: {item.DeliveryTime}");
                    }
                }
            }
        }


        public static void GetInfosByPreparationTime(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Get Info by Preparation Time Section ======\n");
            Console.WriteLine("\t1. Food preparation time");
            Console.WriteLine("\t2. Drink preparation time");
            PATH3:
            Console.Write("\n\tUser choice: ");
            string userChoice = Console.ReadLine();
            if (int.TryParse(userChoice, out int choice))
            {
                switch (userChoice)
                {
                    case "1":
                        GetFoodsPre(restuarant);
                        break;
                    case "2":
                        GetDrinksPre(restuarant);
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice, try again!\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, you should be press numbers!\n");
                goto PATH3;
            }
        }
        public static void GetFoodsPre(Restuarant restuarant)
        {
            Console.WriteLine("\nPlease, enter delivery time!\n");
            PATH10:
            Console.Write("Foods delivery time(minutes): ");
            double deliveryTime = double.Parse(Console.ReadLine());

            if (deliveryTime > 0)
            {
                Console.WriteLine();
                foreach (var item in restuarant.GetAllFood())
                {
                    if (item.PreparationTime == deliveryTime)
                    {
                        Console.WriteLine($"Food name: {item.Name}");
                        Console.WriteLine($"Food price: {item.Price}");
                        Console.WriteLine($"Food delivery time: {item.PreparationTime}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again\n");
                goto PATH10;
            }
        }
        public static void GetDrinksPre(Restuarant restuarant)
        {
            Console.WriteLine("\nPlease, enter delivery time!\n");
            PATH15:
            Console.Write("Drinks delivery time(minutes): ");
            double deliveryTime = double.Parse(Console.ReadLine());

            if (deliveryTime > 0)
            {
                Console.WriteLine();
                foreach (var item in restuarant.GetAllDrink())
                {
                    if (item.DeliveryTime == deliveryTime)
                    {
                        Console.WriteLine($"Drink name: {item.Name}");
                        Console.WriteLine($"Drink alcohol percentage: {item.AlcoholPercentage}");
                        Console.WriteLine($"Drink price: {item.Price}");
                        Console.WriteLine($"Drink delivery time: {item.DeliveryTime}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid choice, try again\n");
                goto PATH15;
            }
        }


        public static void GetInfoByService(Restuarant restuarant)
        {
            Console.WriteLine("\n    ====== Get Info by Service Section ======\n");
            PATH40:
            Console.Write("Input service type: ");
            string serviceType = Console.ReadLine();

            if (serviceType.Length > 2)
            {
                Console.WriteLine();
                foreach (var item in restuarant.GetAllService())
                {
                    if (item.ServiceType == serviceType)
                    {
                        Console.WriteLine($"Service type: {item.ServiceType}");
                        Console.WriteLine($"Service price: {item.Price}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input, service type should be more over two letter!\n");
                goto PATH40;
            }
        }
    }
}