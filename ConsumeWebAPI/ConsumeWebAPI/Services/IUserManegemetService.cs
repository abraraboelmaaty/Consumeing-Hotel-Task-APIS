using ConsumeWebAPI.Models;

namespace ConsumeWebAPI.Services
{
    public interface IUserManegemetService
    {
      
        Task SignUp(string firstName, string lastName, string email,
                string password, string userName, string phoneNumber);
        Task<TokenResponse> LoginAsync(string email, string password);
        
    }
}
