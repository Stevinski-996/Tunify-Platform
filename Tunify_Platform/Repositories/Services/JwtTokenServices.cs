using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Tunify_Platform.Modules;

namespace Tunify_Platform.Repositories.Services
{
    public class JwtTokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenServices(IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration)
            };
        }

        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret key is missing");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(secretBytes);
        }

        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan timeSpan)
        {
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincipal == null)
            {
                return null;
            }

            var signInKey = GetSecurityKey(_configuration);
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + timeSpan,
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                claims: userPrincipal.Claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
