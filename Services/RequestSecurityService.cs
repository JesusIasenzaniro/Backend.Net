using Backend.Net.Interfaces;

namespace Backend.Net.Services
{
    public class RequestSecurityService : IRequestSecurityService
    {
        public bool ValidateToken(string token)
        {
          
            return true;
        }

    }
}
