namespace Tunify_Platform
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public int AlbumID { get; set; }
        public Album Album { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
