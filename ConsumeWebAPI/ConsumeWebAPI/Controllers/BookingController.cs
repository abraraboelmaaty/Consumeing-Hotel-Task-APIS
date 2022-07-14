using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeWebAPI.Controllers
{
    public class BookingController : Controller
    {
        Uri BaseURL = new Uri("http://localhost:57163/api/");
        HttpClient client;
        public BookingController()
        {
            client = new HttpClient();
            client.BaseAddress = BaseURL;
        }
        public ActionResult Index()
        {
            List<BookingModelView> BookingList = new List<BookingModelView>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Booking").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                BookingList = JsonConvert.DeserializeObject<List<BookingModelView>>(data);
            }
            return View(BookingList);
        }
        public ActionResult create()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Account").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            ViewData["Users"] = userList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookingModelView booking)
        {

            string? routeData = (string)Url.ActionContext.RouteData.Values["id"];
            int id = int.Parse(routeData);


            string data = JsonConvert.SerializeObject(booking);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"{client.BaseAddress}Booking/{id}", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
