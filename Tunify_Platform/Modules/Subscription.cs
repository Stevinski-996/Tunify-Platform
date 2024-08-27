namespace Tunify_Platform
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public string SubscriptionType { get; set; }
        public decimal Price { get; set; }
        public ICollection<User> Users { get; set; }
    }
}