namespace Tunify_Platform
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string PlaylistName { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}