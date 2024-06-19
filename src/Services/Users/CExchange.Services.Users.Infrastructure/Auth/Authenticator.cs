using CExchange.Services.Users.Application.DTO;
using CExchange.Services.Users.Application.PasswordSecurity;
using CExchange.Services.Users.Core.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CExchange.Services.Users.Infrastructure.Auth
{
    internal sealed class Authenticator : IAuthenticator
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly TimeSpan _expiry;
        private readonly SigningCredentials _signinCredentials;
        private readonly IClock _clock;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new();

        public Authenticator(IOptions<AuthOptions> options, IClock clock)
        {
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
            _signinCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey)),
                SecurityAlgorithms.HmacSha256);
            _clock = clock;
        }
        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = _clock.Current();
            var expires = now.Add(_expiry);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, userId.ToString()),
                new (JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new (ClaimTypes.Role, role)
            };

            var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signinCredentials);
            var accesToken = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JwtDto
            {
                AccessToken = accesToken,
            };
        }
    }
}
