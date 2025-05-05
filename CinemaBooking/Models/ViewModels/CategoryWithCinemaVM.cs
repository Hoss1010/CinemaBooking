namespace CinemaBooking.Models.ViewModels
{
    public class CategoryWithCinemaVM
    {
        public Movies movies { get; set; } = null!;
        public List <Category> Categories { get; set; } = [];
        public List<Cinemas> Cinema { get; set; } = [];
    }
}
