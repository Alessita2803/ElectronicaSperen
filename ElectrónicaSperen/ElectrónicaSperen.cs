using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ElectrónicaSperen
{
    internal class ElectrónicaSperen
    {
        public List<Product> products = new List<Product>();
        public List<Ticket> tickets = new List<Ticket>();

        public void Register(string name, string brand, float price, int quantity)
        {
            var product = new Product(products.Count + 1, name, brand, price, quantity);
            products.Add(product);
        }

        public Product Sell(int id)
        {
            if (id > products.Count || id == 0)
            {
                Console.WriteLine("Product not found");
            }
            else if (products.ElementAt(id - 1).Quantity == 0)
            {
                Console.WriteLine("No stock");
            }
            else
            {
                Console.WriteLine("Sell Quantity: ");
                int quantity = 0;
                if (int.TryParse(Console.ReadLine(), out int sellNumber)) quantity = sellNumber;
                var productSell = products.ElementAt(id - 1);

                if (productSell.Quantity >= quantity)
                {
                    productSell.Quantity -= quantity;
                    Console.WriteLine("Sold");
                    var date = DateOnly.FromDateTime(DateTime.Now);
                    var ticket = new Ticket(date, productSell, quantity);
                    tickets.Add(ticket);
                    ticket.ShowTicket();
                }
                else
                {
                    Console.WriteLine("There isn't enough stock for sell");
                    return null;
                }
            }
            return null;
        }

        public void Availability() // Disponibilidad de productos
        {
            foreach (var product in products)
            {
                Console.WriteLine("ID: "+product.Id+" Name:"+product.Name +" Brand:"+product.Brand +" Price: $"+ product.Price +" Quantity: "+product.Quantity);
            }
        }

        public void SellHistory()
        {
            foreach(var ticket in tickets)
            {
                ticket.ShowTicket();
            }
        }
    }
}
