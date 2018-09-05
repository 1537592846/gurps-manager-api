using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class AdvantagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new AdvantageDataAccess().ReturnAllData<Advantage>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new AdvantageDataAccess().Find(id);
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
