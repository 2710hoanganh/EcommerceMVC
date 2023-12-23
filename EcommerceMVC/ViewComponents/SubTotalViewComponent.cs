using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EcommerceMVC.Helper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceMVC.ViewComponents
{
    public class SubTotalViewComponent : ViewComponent
    {
        const string CART_SESSION_KEY = "SESSION_KEY";
        public List<CartItemViewModel> Cart => HttpContext.Session.Get<List<CartItemViewModel>>(CART_SESSION_KEY);

        public IViewComponentResult Invoke(int shippingCost)
        {
            var cart = Cart;
            double? total =  0;
            double? totalCost = 0;
            if(cart is not null)
            {
                foreach(var item in cart)
                {
                    total += item.Total ;
                }
                totalCost = total + shippingCost;
            }
            var data = new SubTotalViewModel
            {
                Total = total,
                TotalCost = totalCost,
            };
            return View("SubTotal", data);
        }
    }
}
