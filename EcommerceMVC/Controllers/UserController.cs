using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly Hshop2023Context _context;

        public UserController(Hshop2023Context context) => _context = context;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(RegisterViewModel register)
        {
            return View();
        }
    }
}
