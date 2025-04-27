namespace CinemaBooking.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int? CinemaId { get; set; }
        public Cinemas? Cinema { get; set; }
        public int? CategoryId { get; set; }
        public Category? Categories { get; set; }
        public bool IsAvailable { get; set; }

    }
}
