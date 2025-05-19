namespace CinemaBooking.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio {  get; set; } 
        public string ProfilePicture { get; set;} 
        public string News { get; set; } 
       
        public List<ActorMovie> actorsmovie { get; set; }

    }
}
