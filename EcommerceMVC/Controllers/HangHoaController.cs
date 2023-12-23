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
        public IActionResult Search(string? key) 
        {
            var product = _context.HangHoas.AsQueryable();
            if (key is not null)
            {
                product = product.Where(p => p.TenHh.Contains(key));
            }
            var data = product.Select(h => new ProductViewModel
            {
                Id = h.MaHh,
                Name = h.TenHh,
                Picture = h.Hinh,
                Price = h.DonGia,
                Description = h.MoTa,
            });
            return View(data);
        }

        public IActionResult Detail(int productID)
        {
            var product = _context.HangHoas.SingleOrDefault(p => p.MaHh == productID);
            if (product == null)
            {
                return Redirect("/404");
            }
            var relateProduct = _context.HangHoas.Where(p => p.MaLoai == product.MaLoai);
            var data = new ProductViewModel
            {
                Id = product.MaHh,
                Name = product.TenHh,
                Picture = product.Hinh,
                Price = product.DonGia,
                Description = product.MoTa,
            };
            var relate = relateProduct.Select( r =>  new RelateProductViewModel
            {
                Id = r.MaHh,
                Name = r.TenHh,
                Picture = r.Hinh,
                Price = r.DonGia,
                Description = r.MoTa,
            });
            return View(data);
        }
    }
}
