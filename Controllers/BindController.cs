using Microsoft.AspNetCore.Mvc;

namespace MVC_Web.Controllers
{
    public class BindController : Controller
    {
        public IActionResult Test(string name, int age,int id)
        {
            return Content("Hello");
        }
    }
}
