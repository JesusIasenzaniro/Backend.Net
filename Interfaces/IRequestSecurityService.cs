namespace Backend.Net.Interfaces
{
    public interface IRequestSecurityService
    {
        bool ValidateToken(string token);
    }
}
