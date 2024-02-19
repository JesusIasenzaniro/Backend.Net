using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Backend.Net.Interfaces;

namespace Backend.Net.Services
{
    public class RequestSecurityService : IRequestSecurityService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public RequestSecurityService()
        {
            _secretKey = Environment.GetEnvironmentVariable("SECRET_KEY")!;
            _issuer = Environment.GetEnvironmentVariable("ISSUER")!;
            _audience = Environment.GetEnvironmentVariable("AUDIENCE")!;

            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_issuer) || string.IsNullOrEmpty(_audience))
            {
                throw new InvalidOperationException("Security settings are not configured properly.");
            }
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,

                ValidateAudience = true,
                ValidAudience = _audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero,
            };
        }
    }
}
