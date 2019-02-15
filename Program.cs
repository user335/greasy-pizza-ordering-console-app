using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace greasy_pizza_orderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Greasy Pizza Boys, please place an order");
            Console.Write("Greasy pizza is free! How many slices would you like? ");
            bool sliceCountReceived = false;
            int answer1 = 0;
            while (!sliceCountReceived)
            {
                try
                {
                    answer1 = Convert.ToInt16(Console.ReadLine());
                    if (answer1 > 0) sliceCountReceived = true;
                    else PrintCustomErrorMessage();
                }
                catch (Exception)
                {
                    PrintCustomErrorMessage();
                }
            }
            Console.WriteLine(answer1 + " slices of greasy pizza coming right up!");
            Console.WriteLine("How many napkins would you like? You don't need to answer at all if you would like to receive the default quantity of 3 napkins per slice of pizza!");
            Console.WriteLine("Note: Napkins are $1 each ");
            string answer2string = Console.ReadLine();
            int price = 0;
            try
            {
                int answer2 = Convert.ToInt16(answer2string);
                Console.WriteLine("Alright, " + answer2 + " napkins to go with your " + answer1 + " slices of greasy pizza.");
                price = OrderPlacer.OrderGreasyPizza(answer1, answer2);
            }
            catch (Exception)
            {
                Console.WriteLine("...putting you down for the default order of " + answer1 * 3 + " napkins.");
                price = OrderPlacer.OrderGreasyPizza(answer1);
            }
            if (price > 0) Console.WriteLine("That'll be $" + price + " dollars, please");
            else Console.WriteLine("Your order is free! But your pants will suffer ;)");
            Console.ReadKey();



            void PrintCustomErrorMessage()
            {
                Console.WriteLine("Uh, what? How many slices of greasy pizza would you like ? ");
            }
        }
    }
    class OrderPlacer
    {
        public static int OrderGreasyPizza(int slices, int napkins = 3)
        {
            return slices * napkins;
        }
    }
}
