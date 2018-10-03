using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet("insert")]
        public void Insert()
        {
            Language.InsertLanguages();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new LanguageDataAccess().DeleteAll<Language>();
        }
    }
}
