using System.Collections.Generic;

namespace API.Presentaion
{
    public class PurchaseOrder
    {
        public int EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardNumber { get; set; }
        public int SecurityCode { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public IEnumerable<Dictionary<string, int>> Tickets { get; set; }
    }
}