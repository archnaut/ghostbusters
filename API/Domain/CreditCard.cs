namespace API.Domain
{
    public class CreditCard
    {
        public CreditCard(string firstName, string lastName, string number, int securityCode, int expirationMonth, int expirationDay)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            SecurityCode = securityCode;
            ExpirationMonth = expirationMonth;
            ExpirationDay = expirationDay;
        }

        public string FirstName { get; private set; } 
        public string LastName { get; private set; }
        public string Number { get; private set; }
        public int SecurityCode { get; private set; } 
        public int ExpirationMonth { get; private set; }
        public int ExpirationDay { get; private set; }
    }
}