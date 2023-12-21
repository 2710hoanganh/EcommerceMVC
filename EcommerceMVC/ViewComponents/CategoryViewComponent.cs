using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly Hshop2023Context _context;
        public CategoryViewComponent(Hshop2023Context context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var data = _context.Loais.Select(l => new CategoryViewModel
            {
                MaLoai = l.MaLoai ,
                TenLoai = l.TenLoai ,
                SoLuong = l.HangHoas.Count 
            });
            return View("CategoryViewMenu",data);
        }
    }
}
