using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElectrónicaSperen
{
    internal class Menu
    {
        public Menu() { }
         
        public void Main()
        {
            int option = 0;
            var inventory = new ElectrónicaSperen();
            do
            {
                Console.WriteLine("Welcome to ElectrónicaSperen");
                Console.WriteLine("Select one of the following options:");
                Console.WriteLine("1. Register Product");
                Console.WriteLine("2. Sell Product");
                Console.WriteLine("3. Check Availability");
                Console.WriteLine("4. Check Sell History");
                Console.WriteLine("5. EXIT");

                if (int.TryParse(Console.ReadLine(), out int optionNumber)) option = optionNumber;

                switch(option)
                {
                    case 1:
                        Console.Clear();

                        Console.WriteLine("Insert the product data:");
                        Console.WriteLine("Insert name: ");
                        var name = Console.ReadLine();
                        if (name == null) name = "";
                        Console.WriteLine("Insert brand name:");
                        var brand = Console.ReadLine();
                        if (brand == null) brand = "";
                        Console.WriteLine("Insert the price:");
                        Console.Write("$");
                        float price = 0;
                        if(float.TryParse(Console.ReadLine(), out float priceNumber)) price = priceNumber;
                        Console.WriteLine("Insert the quantity: ");
                        int quantity = 0;
                        if(int.TryParse(Console.ReadLine(), out int  quantityNumber)) quantity = quantityNumber;

                        inventory.Register(name,brand,price,quantity);

                        break;

                    case 2:
                        Console.Clear();
                        inventory.Availability();
                        int optionTwo = 0;

                        do
                        {
                            Console.WriteLine("1. Sell Product");
                            Console.WriteLine("2. Back to main menu");

                            if (int.TryParse(Console.ReadLine(), out int optionTwoNumber)) optionTwo = optionTwoNumber;

                            if (optionTwo == 1)
                            {
                                Console.WriteLine("Insert product id:");
                                int id = 0;
                                if (int.TryParse(Console.ReadLine(), out int idSell)) id = idSell;

                                inventory.Sell(id);
                            }
                        } while (optionTwo < 2);
                        break;

                    case 3:
                        Console.Clear();
                        inventory.Availability();
                        break;
                    case 4:
                        Console.Clear();
                        inventory.SellHistory();
                        break;
                }
            } while (option < 5);
        }
    }
}
