using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new CharacterDataAccess().ReturnAllData<Character>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new CharacterDataAccess().Find(id);
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new CharacterDataAccess().DeleteAll<Character>();
        }
    }
}
