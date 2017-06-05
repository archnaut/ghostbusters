using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Domain
{
    public class Order
    {
        private Order() {}

        private readonly Lazy<decimal> _amountPaid;
        public Order(CreditCard creditCard, DateTime purchaseDate)
            : this(-1, creditCard, purchaseDate) { }

        public Order(int id, CreditCard creditCard, DateTime purchaseDate)
        {
            Id = id;
            CreditCard = creditCard;
            PurchaseDate = purchaseDate;
            OrderItems = new List<OrderItem>();
            _amountPaid = new Lazy<decimal>(()=> OrderItems.Sum(x => x.SalesTax + x.AmountPaid));
        }

        public int Id { get; private set; } 
        public int CreditCardId { get; private set; } 
        public CreditCard CreditCard { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public decimal AmountPaid => _amountPaid.Value;
        public virtual ICollection<OrderItem> OrderItems { get; private set; }

        public void Add(OrderItem item)
        {
            OrderItems.Add(item);
        }
    }
}