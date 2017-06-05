namespace API.Domain
{
    public class CreditCard
    {
        private CreditCard() { }

        public CreditCard(string firstName, string lastName, string number, int securityCode, int expirationMonth, int expirationYear)
            : this(-1, firstName, lastName, number, securityCode, expirationMonth, expirationYear) { }

        public CreditCard(int id, string firstName, string lastName, string number, int securityCode, int expirationMonth, int expirationYear)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            SecurityCode = securityCode;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Number { get; private set; }
        public int SecurityCode { get; private set; }
        public int ExpirationMonth { get; private set; }
        public int ExpirationYear { get; private set; }

        public void Update(string firstName, string lastName, int securityCode, int expirationMonth, int expirationYear)
        {
            FirstName = string.IsNullOrEmpty(firstName)
                ? FirstName
                : firstName;

            LastName = string.IsNullOrEmpty(lastName)
                ? LastName
                : lastName;

            SecurityCode = securityCode;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
        }
    }
}