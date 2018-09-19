using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class DisadvantagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new DisadvantageDataAccess().ReturnAllData<Disadvantage>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new DisadvantageDataAccess().Find(id);
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
