namespace Tunify_Platform.Modules.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public IList<string> Roles { get; set; }
        public string Token {get; set; }
    }
}
