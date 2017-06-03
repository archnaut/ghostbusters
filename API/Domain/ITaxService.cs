namespace API.Domain
{
    public interface ITaxService
    {
        decimal TaxFor(decimal amount);
    }
}