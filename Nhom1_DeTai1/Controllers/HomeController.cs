using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nhom1_DeTai1.Data;
using Nhom1_DeTai1.Models;
using System.Diagnostics;
using System.Dynamic;

namespace Nhom1_DeTai1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Nhom1_DeTai1Context _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Nhom1_DeTai1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            dynamic HomePage = new ExpandoObject();
            HomePage.User = _context.User;
            HomePage.Category = _context.Category;
            return View(HomePage);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}