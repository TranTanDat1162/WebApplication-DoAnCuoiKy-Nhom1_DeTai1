using Microsoft.AspNetCore.Mvc;
using Nhom1_DeTai1.Data;

namespace Nhom1_DeTai1.Models
{
    public class Search : ViewComponent
    {
        private readonly Nhom1_DeTai1Context _context;
        public Search(Nhom1_DeTai1Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Category.ToList());
        }
    }
}
