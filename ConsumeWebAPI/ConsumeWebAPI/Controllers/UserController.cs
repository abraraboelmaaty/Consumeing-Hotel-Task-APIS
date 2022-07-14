using ConsumeWebAPI.Models;
using ConsumeWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

//using Microsoft.VisualBasic;

namespace ConsumeWebAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManegemetService _userManagementService;

        public UserController(IUserManegemetService userManagementService)
        {
            _userManagementService = userManagementService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConfirmationReminder()
        {
            return View("ConfirmationReminder");
        }

        public IActionResult SignUp()
        {
            var viewModel = new RegisterViewModel();

            return View("SignUp", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUpPost(RegisterViewModel viewModel)
        {
           
            await _userManagementService.SignUp(viewModel.FirstName, viewModel.LastName,
                                                viewModel.Email, viewModel.Password,
                                                viewModel.Username, viewModel.PhoneNumber);
            return RedirectToAction("ConfirmationReminder");
        }

        [HttpPost]
        [ActionName("LoginPostAsync")]
        public async Task<IActionResult> LoginPostAsync(LoginViewModel viewModel)
        {
            var tokenResponse = await _userManagementService
                                .LoginAsync(viewModel.Email, viewModel.Password);
            Response.Cookies.Append(
                Constants.XAccessToken,
                tokenResponse.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
            return RedirectToAction("Index", "Room");
        }
    }
}
