using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace ConsumeWebAPI.Controllers
{
    public class BranchController : Controller
    {
        Uri BaseURL = new Uri("http://localhost:57163/api/");
        HttpClient client;
        public BranchController()
        {
            client = new HttpClient();
            client.BaseAddress = BaseURL;
        }
        public ActionResult Index()
        {
            List<BranchViewModel> branchList = new List<BranchViewModel>();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Branch/getAll").Result;
            if (response.IsSuccessStatusCode)
            {
                string data =  response.Content.ReadAsStringAsync().Result;
                branchList = JsonConvert.DeserializeObject<List<BranchViewModel>>(data);
            }
            return View(branchList);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BranchViewModel branch)
        {
            string data = JsonConvert.SerializeObject(branch);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync($"{client.BaseAddress}Branch/Add",content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            BranchViewModel branch = new BranchViewModel();
            HttpResponseMessage response = client.GetAsync($"{client.BaseAddress}Branch/getById/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                branch = JsonConvert.DeserializeObject<BranchViewModel>(data);
            }
            return View(branch);
        }

    }
}
