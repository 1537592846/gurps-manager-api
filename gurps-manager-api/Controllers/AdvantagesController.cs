using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class AdvantagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new AdvantageDataAccess().FindAll<Advantage>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new AdvantageDataAccess().FindOne<Advantage>(id));
        }

        [HttpGet("insert")]
        public void Insert()
        {
            Advantage.InsertAdvantages();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new AdvantageDataAccess().DeleteAll<Advantage>();
        }
    }
}
