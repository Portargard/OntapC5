using AppData;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetAll()
        {
            string apiUrl = "https://localhost:7091/api/SanPham";
            var httpClient = new HttpClient();
            var respon = httpClient.GetAsync(apiUrl).Result;
            string data = respon.Content.ReadAsStringAsync().Result;
            var sp = JsonConvert.DeserializeObject<List<SanPham>>(data);
            return View(sp);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SanPham sp)
        {
            string apiUrl = "https://localhost:7091/api/SanPham/Post";
            var httpClient = new HttpClient();
            var respon = httpClient.PostAsJsonAsync(apiUrl,sp).Result;
            if (respon.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Update(string masp)
        {
            string apiUrl = "https://localhost:7091/api/SanPham";
            var httpClient = new HttpClient();
            var respon = httpClient.GetAsync(apiUrl).Result;
            string data = respon.Content.ReadAsStringAsync().Result;
            var sp = JsonConvert.DeserializeObject<List<SanPham>>(data);
            var sp1 = sp.FirstOrDefault(c => c.MaSP == masp);
            return View(sp1);
        }

        public IActionResult Update(SanPham sp)
        {
            string apiUrl = "https://localhost:7091/api/SanPham/Put";
            var httpClient = new HttpClient();
            var respon = httpClient.PutAsJsonAsync(apiUrl,sp).Result;
            if (respon.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }

        public IActionResult Delete(string masp)
        {
            string apiUrl = $"https://localhost:7091/api/SanPham/{masp}";
            var httpClient = new HttpClient();
            var respon = httpClient.DeleteAsync(apiUrl).Result;
            if (respon.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }
    }
}