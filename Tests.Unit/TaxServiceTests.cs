using API.Domain;
using Xunit;

namespace Tests.Unit
{
    public class TaxServiceTests
    {
        [Theory]
        [InlineData(0.00, 1.00, 0.00)]
        [InlineData(0.01, 0.00, 0.00)]
        [InlineData(0.01, 1.00, 0.01)]
        [InlineData(0.10, 1.00, 0.10)]
        [InlineData(1.00, 1.00, 1.00)]
        public void TaxFor(decimal taxRate, decimal amount, decimal expected)
        {
            // Arrange 
            var taxService = new TaxService(taxRate);

            // Act
            var actual = taxService.TaxFor(amount);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
