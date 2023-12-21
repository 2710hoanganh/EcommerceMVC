using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly Hshop2023Context _context;

        public HangHoaController (Hshop2023Context context) => _context = context;

        public IActionResult Index(int? category)
        {
            var product = _context.HangHoas.AsQueryable();
            if(category.HasValue)
            {
                product = product.Where(p => p.MaLoai == category.Value);
            } 
            var data = product.Select(h => new ProductViewModel
            {
                Id = h.MaHh ,
                Name = h.TenHh ,
                Picture = h.Hinh ,
                Price = h.DonGia,
                Description = h.MoTa,
            });

            return View(data);
        }
    }
}
