using Microsoft.AspNetCore.Mvc;

namespace sistemaAcad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(){
            return View();
        }
    }
}