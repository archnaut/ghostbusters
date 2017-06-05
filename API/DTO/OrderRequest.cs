using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class OrderRequest 
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please provide an Event ID.")]
        public int EventId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a First Name.")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Last Name.")]
        public string LastName { get; set; }

        [Required]
        [CreditCard(ErrorMessage = "Please provide a valid Credit Card Number.")]
        public string CreditCardNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Security Code.")]
        public int SecurityCode { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Please enter a valid Expiration Month between 1 and 12")]
        public int ExpirationMonth { get; set; }

        [Required]
        public int ExpirationYear { get; set; }

        [Required] 
        public IEnumerable<OrderRequestItem> Tickets { get; set; }
    }
}