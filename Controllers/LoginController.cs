using Microsoft.AspNetCore.Mvc;
using SuperStore2.DOI;

namespace Super_Store2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() { return View(); }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                 return RedirectToAction(controllerName: "Home", actionName: "Index");
                
            }
            return View();
        }
    }
}
