using Microsoft.AspNetCore.Mvc;
using SuperStore2.DOI;

namespace Super_Store2.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup() { return View(); }
        [HttpPost]
        public IActionResult Signup(Signup signup)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(controllerName: "Login", actionName: "Login");
            }
            return View();
        }
    }
}
