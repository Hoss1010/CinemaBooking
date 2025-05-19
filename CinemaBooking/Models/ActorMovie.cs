namespace CinemaBooking.Models
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public Movies movies { get; set; }
        public Actors actors { get; set; }
    }
}
