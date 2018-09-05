using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class LanguagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new LanguageDataAccess().ReturnAllData<Language>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new LanguageDataAccess().Find(id);
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
