using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Models.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required]
        public string UserNameOREmail { get; set; } = null!;
    }
}
