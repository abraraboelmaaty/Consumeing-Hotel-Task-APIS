using ConsumeWebAPI.Models;

namespace ConsumeWebAPI.Repositories
{
    public interface IUserManegementRepository
    {

        Task SignUp(string firstName, string lastName, string email,
                    string encryptedPassword, string userName, string phoneNumber);
        Task<TokenResponse> LoginAsync(string email, string password);
       
    }
}
