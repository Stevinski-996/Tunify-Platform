namespace Tunify_Platform.Modules.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token {get; set; }
        public IList <string> Roles {get; set; }
    }
}