using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helper;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {

        private readonly Hshop2023Context _context;
        public CartController(Hshop2023Context context) => _context = context;

        const string CART_SESSION_KEY = "SESSION_KEY";
        public List<CartItemViewModel> Cart => HttpContext.Session.Get<List<CartItemViewModel>>(CART_SESSION_KEY) ?? new List<CartItemViewModel>();

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
                item = new CartItemViewModel
                {
                    Id = product.MaHh,
                    Quantity = quantity,
                    Name = product.TenHh,
                    Image = product.Hinh,
                    Price = product.DonGia,
                    Total = product.DonGia * quantity,
                };
                cart.Add(item);
            }
            else
            {
                item.Quantity += quantity;
                item.Total = item.Quantity * item.Price;
            }
            HttpContext.Session.Set(CART_SESSION_KEY, cart);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(x => x.Id == id);
            if(item is not null)
            {
                cart.Remove(item);
            }
            HttpContext.Session.Set(CART_SESSION_KEY, cart);
            return RedirectToAction("Index");
        }
    }
}
