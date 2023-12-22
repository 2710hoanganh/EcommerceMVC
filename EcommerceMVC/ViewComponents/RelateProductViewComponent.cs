using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace EcommerceMVC.ViewComponents
{
    public class RelateProductViewComponent : ViewComponent
    {
        private readonly Hshop2023Context _context;
        public RelateProductViewComponent(Hshop2023Context context) => _context = context;

        public IViewComponentResult Invoke(int productId)
        {
            var product = _context.HangHoas.SingleOrDefault(p => p.MaHh == productId);
            var relateProduct = _context.HangHoas.Where(p => p.MaLoai == product.MaLoai && p.MaHh != productId);
            var relate = relateProduct.Select(r => new RelateProductViewModel
            {
                Id = r.MaHh,
                Name = r.TenHh,
                Picture = r.Hinh,
                Price = r.DonGia,
                Description = r.MoTa,
            });
            return View("RelateProduct", relate);
        }
    }
}
