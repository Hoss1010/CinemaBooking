namespace CinemaBooking.Models
{
    public class Cinemas
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string? Description { get; set; }
        public string? CinemaLogo { get; set; }
        public string? Address { get; set; }
        public List<Movies>? Movie { get; set; }


    }
}
