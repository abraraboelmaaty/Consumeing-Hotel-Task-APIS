using ConsumeWebAPI.Models;
using ConsumeWebAPI.Repositories;

namespace ConsumeWebAPI.Services
{
    public class UserManegementService : IUserManegemetService
    {
        private readonly IUserManegementRepository _userManagementRepository;

        public UserManegementService(IUserManegementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        public async Task<TokenResponse> LoginAsync(string email, string password)
        {
            return await _userManagementRepository.LoginAsync(email, password);
        }

        public async Task SignUp(string firstName, string lastName,
                           string email, string password, string userName,
                           string phoneNumber)
        {
            await _userManagementRepository.SignUp(firstName, lastName, email,
                                                   password,
                                                   userName, phoneNumber);
        }
    }
}
