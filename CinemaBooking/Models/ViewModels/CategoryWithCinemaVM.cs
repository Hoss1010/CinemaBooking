namespace CinemaBooking.Models.ViewModels
{
    public class CategoryWithCinemaVM
    {
        public Movies movies { get; set; } = null!;
        public string ImgUrl { get; set; }
        public List <Category> Categories { get; set; } = [];
        public List<Cinemas> Cinema { get; set; } = [];
        public List<Actors> actors { get; set; } = [];
        public List<int> ActorsId { get; set; } = [];

    }
}
