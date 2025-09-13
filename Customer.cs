using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatabase.Models
{
    public class Customer // Change 'internal' to 'public' to match the accessibility of 'SalesDatabaseContext'
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public List<Sale> sales { get; set; }
    }
}
