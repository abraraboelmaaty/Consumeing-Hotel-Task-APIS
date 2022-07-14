using ConsumeWebAPI.Models;
using Flurl;
using Flurl.Http;


namespace ConsumeWebAPI.Repositories
{
    public class UserManegementRepository : IUserManegementRepository
    {
        Uri BaseURL = new Uri("http://localhost:57163/api/");
        HttpClient client;
        public UserManegementRepository()
        {
            client = new HttpClient();
            client.BaseAddress = BaseURL;
        }
        public async Task<TokenResponse> LoginAsync(string email, string password)
        {
            var userLogin = new LoginViewModel
            {
                Email = email,
                Password = password
            };
            return await "http://localhost:57163/"
                     .AppendPathSegment("/api/Account/Login")
                     .PostJsonAsync(userLogin).ReceiveJson<TokenResponse>();
        }

        public async Task SignUp(string firstName, string lastName, string email,
                           string password, string userName,
                           string phoneNumber)
        {
            var userSignUp = new RegisterViewModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Username = userName,
                PhoneNumber = phoneNumber
            };

            await "http://localhost:57163/"
                   .AppendPathSegment("/api/Account/register")
                   .PostJsonAsync(userSignUp);
        }
    }
}
