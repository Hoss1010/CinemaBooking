namespace CinemaBooking.Models.ViewModels
{
    public class ProductWithCategoryWithBrandVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? ImgUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
         
        public Cinemas? Cinema { get; set; }
         
        public Category? Categories { get; set; }
        public bool IsAvailable { get; set; }
    }
}
