namespace API.Domain
{
    public class TaxService : ITaxService
    {
        private readonly decimal _taxRate;

        public TaxService(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public decimal TaxFor(decimal amount)
        {
            return _taxRate*amount;
        }
    }
}