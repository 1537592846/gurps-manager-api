using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ViewResult Main()
        {
            return View();
        }
    }
}