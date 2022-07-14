using ConsumeWebAPI.Data;
using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeWebAPI.Controllers
{
    public class RoomController : Controller
    {
        Uri BaseURL = new Uri("http://localhost:57163/api/");
        HttpClient client;
        public RoomController()
        {
            client = new HttpClient();
            client.BaseAddress = BaseURL;
        }
        public ActionResult Index()
        {
            List<RoomViewModel> roomList = new List<RoomViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Room/getAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                roomList = JsonConvert.DeserializeObject<List<RoomViewModel>>(data);
            }
            return View(roomList);
        }
        public ActionResult create()
        {
            List<BranchViewModel> branchList = new List<BranchViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Branch/getAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                branchList = JsonConvert.DeserializeObject<List<BranchViewModel>>(data);
            }
            ViewData["Branches"] = branchList;
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomViewModel room)
        {
            string data = JsonConvert.SerializeObject(room);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"{client.BaseAddress}Room/Add", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            RoomViewModel room = new RoomViewModel();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Room/getById/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                room = JsonConvert.DeserializeObject<RoomViewModel>(data);
            }
            return View(room);
        }
        public ActionResult AvilableRooms()
        {
            List<RoomViewModel> roomList = new List<RoomViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Room/getAllAvilableRooms").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                roomList = JsonConvert.DeserializeObject<List<RoomViewModel>>(data);
            }
            return View(roomList);
        }
        public ActionResult getRoomByType(RoomType id)
        {
            List<RoomViewModel> roomList = new List<RoomViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Room/getAllByType/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                roomList = JsonConvert.DeserializeObject<List<RoomViewModel>>(data);
            }
            return View(roomList);
        }
    }
}
