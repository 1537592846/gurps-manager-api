using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        [HttpGet]
        public ViewResult ListClearFunctions()
        {
            var classList = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.Namespace == "gurps_manager_library.DataAccess")
                 .ToList();
            var list = new List<string>();
            foreach (var className in classList.Where(x=>x.Name!="DataAccess"))
            {
                list.Add(className.Name.Replace("DataAccess", "")+"s");
            }

            return View(list);
        }
    }
}