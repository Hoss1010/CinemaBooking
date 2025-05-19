using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Models.ViewModels
{
    public class ResendEmailConfirmationVM
    {
        [Required]
        public string UserNameOREmail { get; set; } = null!;
    }
}
