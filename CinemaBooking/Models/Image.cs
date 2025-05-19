namespace CinemaBooking.Models
{
    public class Image
    {
        public int Id {  get; set; }
        public string ImageUrl { get; set; }
        public Movies movies { get; set; }
        public int MovieId { get; set; }
    }
}
