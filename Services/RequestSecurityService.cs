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
            // Your existing token validation logic
            return true;
        }
    }
}
