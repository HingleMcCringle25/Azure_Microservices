using System.ComponentModel.DataAnnotations;

namespace TicketAPI
{
    public class Ticket
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(10)]
        public string LastName { get; set; } = String.Empty;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = String.Empty;

    }
}
