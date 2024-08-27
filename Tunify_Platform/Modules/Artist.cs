namespace Tunify_Platform
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
