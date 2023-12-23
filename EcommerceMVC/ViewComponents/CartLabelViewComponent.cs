using EcommerceMVC.ViewModels;
using EcommerceMVC.Helper;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.ViewComponents
{
    public class CartLabelViewComponent : ViewComponent
    {
        const string CART_SESSION_KEY = "SESSION_KEY";
        public List<CartItemViewModel> Cart => HttpContext.Session.Get<List<CartItemViewModel>>(CART_SESSION_KEY);
        public IViewComponentResult Invoke(int shippingCost)
        {
            var cart = Cart;
            int quantity = 0;
            if (cart is not null)
            {
                foreach (var item in cart)
                {
                    quantity += item.Quantity;
                }
            }
            var data = new CartLabelQuantityViewModel
            {
                Quantity = quantity
            };
            return View("Quantity", data);
        }
    }
}
