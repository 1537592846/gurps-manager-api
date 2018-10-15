using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class LanguagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new LanguageDataAccess().FindAll<Language>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new LanguageDataAccess().FindOne<Language>(id));
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new LanguageDataAccess().DeleteAll<Language>();
        }

        [Route("AddLanguage")]
        public ActionResult AddLanguage()
        {
            return View();
        }

        [Route("AddLanguage")]
        [HttpPost]
        public ActionResult AddLanguage(Language language)
        {
            var list = new LanguageDataAccess().FindAll<Language>();
            language.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            language.Name = Request.Form["Name"];
            language.Description = Request.Form["Description"];
            new LanguageDataAccess().InsertOne(language);
            return RedirectToAction("Main", "Admin");
        }
    }
}
