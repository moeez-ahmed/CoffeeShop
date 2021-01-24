using System;

namespace CoffeeShop
{
    interface User
    {
        string Name { get; }
        int userLiking { get; }
    }

    public class CoffeeShopClass : User
    {
        private int numberOfChocolateCoffee = 50; 
        private int numberOfVanillaCoffee = 50;

        private readonly int priceOfCoffee = 60; //IMMUTABLES

        private readonly int priceOfTopping = 10; //IMMUTABLES

        private static int totalAmount;

        private String message; //MUTABLES
        private readonly String thanks = "\nWe will await your return."; //IMMUTABLES
        private readonly String comeBack = "\nMake sure to come back again!"; //IMMUTABLES

        private string userName;
        private int userLike;


        public string Name
        {
            get { return userName; }
            private set { userName = value; }
        }

        public int userLiking
        {
            get { return userLike; }
        }

        public CoffeeShopClass(int amountVanilla, int amountChocolate, string paymentType, int paymentCredit, string toppings)
        {
            TotalAmountOfCoffee(amountVanilla, amountChocolate, toppings);
            Console.WriteLine(CustomerPaymentMethod(paymentType, paymentCredit));
        }



        private String CustomerPaymentMethod(string paymentType, int paymentCredit)
        {
            int remaining = CheckPayment(paymentCredit);

            if (paymentType == "debit".ToLower() && remaining >= 0)
            {
                message = "Thank you for buying from us." + thanks; //Concatination, MUTABLE.
            }
            else if (paymentType == "hand".ToLower() && remaining >= 0)
            {
                message = ("Thank you for buying from us. Here is your remaining change = " + remaining); //Concatination, MUTABLE.
            }

            message += comeBack; //Performed concatination, MUTABLE

            return message;
        }

        public int CheckPayment(int paymentCredit)
        {
            if (paymentCredit >= totalAmount)
            {
                paymentCredit -= totalAmount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough credit provided.");
            }

            return paymentCredit;
        }


        private int TotalAmountOfCoffee(int amount1, int amount2, string toppings)
        {
            int totalCoffees = 100 - TotalNumberOfCoffeesInStock(amount1, amount2);
            totalAmount = totalCoffees * priceOfCoffee;

            if (toppings == "yes".ToLower())
            {
                int amount = TotalAmountOfTopping(totalCoffees);

                totalAmount += amount;
            }

            return totalAmount;
        }

        private int TotalAmountOfTopping(int totalCoffees)
        {
            int totalAmountOfToppings = totalCoffees * priceOfTopping;

            return totalAmountOfToppings;
        }


        public int TotalNumberOfCoffeesInStock(int amountOfVanillaCoffee, int amountOfChocolateCoffee)
        {
            if ((amountOfChocolateCoffee + amountOfVanillaCoffee) <= (numberOfChocolateCoffee + numberOfVanillaCoffee))
            {
                if ((numberOfChocolateCoffee - amountOfChocolateCoffee) != numberOfChocolateCoffee)
                {
                    userLike = 1;
                }
                else if ((numberOfVanillaCoffee - amountOfVanillaCoffee) != numberOfVanillaCoffee)
                {
                    userLike = 2;
                }

                numberOfChocolateCoffee -= amountOfChocolateCoffee;
                numberOfVanillaCoffee -= amountOfVanillaCoffee;

                int totalNumberOfCoffee = numberOfVanillaCoffee + numberOfChocolateCoffee;
                return totalNumberOfCoffee;
            }
            else
            {
                throw new ArgumentOutOfRangeException("This much stock is not available.");
            }
        }


        public static void Main()
        {
            CustomerEntering();
        }

        private static void CustomerEntering()
        {
            int amountOfVanilla, amountOfChocolate, paymentCredit;
            string paymentType, toppings;

            Console.WriteLine("Please enter amount of Vanilla Coffee you want to buy : ");
            amountOfVanilla = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter amount of Chocolate Coffee you want to buy : ");
            amountOfChocolate = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter if you want any extra topping (yes/no): ");
            toppings = (Console.ReadLine());

            Console.WriteLine("Please enter your payment method (debit/hand) : ");
            paymentType = (Console.ReadLine());

            Console.WriteLine("Please enter currency amount you are paying : ");
            paymentCredit = int.Parse(Console.ReadLine());

            CoffeeShopClass customerOne = new CoffeeShopClass(amountOfVanilla, amountOfChocolate, paymentType, paymentCredit, toppings);
        }
    }
}



