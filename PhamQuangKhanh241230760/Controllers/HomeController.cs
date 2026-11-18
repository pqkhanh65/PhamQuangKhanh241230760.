using Microsoft.AspNetCore.Mvc;
using PhamQuangKhanh241230760_.Models;
using System.Diagnostics;

namespace PhamQuangKhanh241230760_.Controllers
{
    public class HomeController : Controller
    {
        private readonly
            QLNhaSachContext db;
        public 
            HomeController (QLNhaSachContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            ViewBag.TheLoais = db.TheLoais.ToList();
            ViewBag.TieuDe = "Pham Quang Khanh";
            var sach = db.Sachs.Where(sach => sach.Gia != null && sach.Gia >= 100)
                .ToList();
            return View(sach);
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
    }
}
