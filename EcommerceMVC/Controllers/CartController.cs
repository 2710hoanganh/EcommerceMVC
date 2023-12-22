using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helper;
using Microsoft.EntityFrameworkCore;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {

        private readonly Hshop2023Context _context;
        public CartController(Hshop2023Context context) => _context = context;

        const string CART_SESSION_KEY = "SESSION_KEY";
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_SESSION_KEY) ?? new List<CartItem>();

        public IActionResult Index()
        {
            return View(Cart);
        }
        public IActionResult AddToCart(int id , int quantity = 1)
        {
            var cart = Cart;
            var item  = cart.SingleOrDefault(x => x.Id == id); 
            if(item is null)
            {
                var product = _context.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (product is null)
                {
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    Id = product.MaHh,
                    Quantity = quantity,
                    Name = product.TenHh,
                    Image = product.Hinh,
                    Price = product.DonGia
                };
                cart.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            HttpContext.Session.Set(CART_SESSION_KEY, cart);

            return RedirectToAction("Index");
        }
    }
}
