using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class DisadvantagesController : Controller
    {
        [HttpGet("get")]
        [EnableCors("AllowSpecificOrigin")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindAll<Disadvantage>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindOne<Disadvantage>(id));
        }

        [HttpGet("insert")]
        public void Insert()
        {
            Disadvantage.InsertDisadvantages();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new DisadvantageDataAccess().DeleteAll<Disadvantage>();
        }
    }
}
