using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CinemaBooking.Models
{
    public class Movies
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        //public ICollection<Image> ImgUrl { get; set; }
        public String ImgUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CinemaId { get; set; }
        [ValidateNever]
        public Cinemas? Cinema { get; set; }
        public int? CategoryId { get; set; }
        [ValidateNever]
        public Category? Categories { get; set; }
        public bool IsAvailable { get; set; }
        public List<ActorMovie> actorMovies { get; set; }

    }
}
