namespace HelloWorldWebApi_2.Models.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string PosterLink { get; set; }

        public Movie(string title, int releaseYear, string genre, string posterLink)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Genre = genre;
            PosterLink = posterLink;
        }
    }
}
