using Microsoft.AspNetCore.Mvc;
using System;
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
                 .Where(t => t.Namespace == "gurps_manager_api.Controllers")
                 .ToList();
            var list = new List<string>();
            foreach (var className in classList.Where(x => !x.Name.Contains( "AdminController")))
            {
                list.Add(className.Name.Replace("Controller", ""));
            }
            list.RemoveAt(list.Count-1);

            return View(list);
        }
    }
}