using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TicketAPI
{
    
    public class TicketHub
    {

        [Required(ErrorMessage = "Concert must have an ID.")]
        public int concertId { get; set; } = 0;

        [Required]
        [EmailAddress(ErrorMessage = "A valid email must be provided.")]
        public string email { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[a-zA-Z\s\-]+$", ErrorMessage = "Name can only contain letters, spaces, and hyphens.")]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2 letters.")]
        public string name { get; set; } = string.Empty;

        [Required]
        [Phone(ErrorMessage = "A valid phone number must be provided.")]
        public string phone {  get; set; } = string.Empty;

        [Required]
        [Range(0, 10, MinimumIsExclusive = true, MaximumIsExclusive = false, ErrorMessage = "Minimum selection of 1.")]
        public int quantity { get; set; } = 0;

        [Required]
        //[CreditCard(ErrorMessage = "Credit card number is invalid.")] //Luhn's algorithm doesn't seem to work for 16 digit credit card numbers
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be 16 digits without spaces.")] //used regex instead of Luhn's algorithm
        public string creditCard { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Invalid expiry date. Example: 08/29")] //fix validation
        public string creditExpire { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Security pin can only be 3 numbers.")]
        public string securityCode {  get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address must be at least 5 characters long.")]
        public string address { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[a-zA-Z\s\-']+$", ErrorMessage = "City can only contain letters, spaces, apostrophes, and hyphens.")]
        public string city { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Province can only contain letters.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Province must be 2 characters long. Example: Ontario = ON")]
        public string province { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[ABCEGHJ-NPRSTVXY]\d[ABCEGHJ-NPRSTV-Z][\s\-]?\d[ABCEGHJ-NPRSTV-Z]\d$", ErrorMessage = "Postal code must be in the format A1A 1A1, A1A-1A1, or A1A1A1.")]
        public string postalCode { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[a-zA-Z\s\-']+$", ErrorMessage = "Country can only contain letters, spaces, apostrophes, and hyphens.")]
        public string country { get; set; } = string.Empty;

    }
}
