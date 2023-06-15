using AppData.Models;
using AppViews.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
namespace AppViews.Controllers
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


        public async Task<IActionResult> GetAll()
        {
            string apiUrl = "https://localhost:7011/api/SanPham";
            var httpClient = new HttpClient();
            var respone = await httpClient.GetAsync(apiUrl);
            var data = await respone.Content.ReadAsStringAsync();
            var sp = JsonConvert.DeserializeObject<List<SanPham>>(data);
            return View(sp);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(SanPham sp)
        {
            string apiUrl = $"https://localhost:7011/api/SanPham?maSp={sp.MaSp}&tenSp={sp.TenSp}&Gia={sp.Gia}&SlTon={sp.SlTon}&nhaSX={sp.NhaSx}&thuonHieu={sp.ThuongHieu}";
            var httpClient = new HttpClient();
            var respone = await httpClient.PostAsJsonAsync(apiUrl,sp);
            if (respone.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            string apiUrl = "https://localhost:7011/api/SanPham";
            var httpClient = new HttpClient();
            var respone = await httpClient.GetAsync(apiUrl);
            var data = await respone.Content.ReadAsStringAsync();
            var sp = JsonConvert.DeserializeObject<List<SanPham>>(data).FirstOrDefault(c=>c.Id==id);
            return View(sp);
        }
        
        public async Task<IActionResult> Update(SanPham sp)
        {
            string apiUrl = $"https://localhost:7011/api/SanPham/{sp.Id}?maSp={sp.MaSp}&tenSp={sp.TenSp}&Gia={sp.Gia}&SlTon={sp.SlTon}&nhaSX={sp.NhaSx}&thuonHieu={sp.ThuongHieu}";
            var httpClient = new HttpClient();
            var respone = await httpClient.PutAsJsonAsync(apiUrl,sp);
            if (respone.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }
        public async Task<IActionResult> Delete(Guid id)
        {

            string apiUrl = $"https://localhost:7011/api/SanPham/{id}";
            var httpClient = new HttpClient();
            var respone = await httpClient.DeleteAsync(apiUrl);
            if (respone.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAll");
            }
            return BadRequest();
        }
    }
}