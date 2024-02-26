using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectrónicaSperen
{
    internal class Ticket
    {
        public DateOnly Date { get; set; }
        public Product ProductSell { get; set; } 
        public int Quantity { get; set; }
        public float Amount { get; set; }
      
        public Ticket(DateOnly date,Product productSell, int quantity)
        {
            Date = date;
            ProductSell = productSell;
            Quantity = quantity;
            Amount = productSell.Price * quantity;
        }
        public void ShowTicket()
        {
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Date :" + Date.ToString("dd/MM/yy"));
            Console.WriteLine(""+ProductSell.Name +""+ ProductSell.Brand +""+ ProductSell.Price);
            Console.WriteLine(Quantity);
            Console.WriteLine(""+Amount);
            Console.WriteLine("------------------------------------------------------------------------");
        }
    }
}
