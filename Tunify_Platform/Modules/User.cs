namespace Tunify_Platform
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public int SubscriptionID { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}