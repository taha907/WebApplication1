namespace WebApplication1.Models
{
    public class Movie
    {
        //prop + 2 tab
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string [] Players { get; set; }
        public string ImageUrl { get; set; }
        public int GenreId { get; set; }
    }
}
