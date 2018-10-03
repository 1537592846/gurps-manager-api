using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new CharacterDataAccess().FindAll<Character>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new CharacterDataAccess().FindOne<Character>(id));
        }

        [HttpGet("next")]
        public string Next()
        {
            var characters = new CharacterDataAccess().FindAll<Character>();
            int id = 1;
            if (characters.Count != 0)
            {
                id = characters.OrderBy(x => x.Id).First().Id + 1;
            }
            return id.ToJson();
        }

        [HttpPost("save")]
        public bool Save(string content)
        {
            Character character = new Character();
            var data = JsonConvert.DeserializeObject<List<object>>(content);
            //TODO
            return true;
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new CharacterDataAccess().DeleteAll<Character>();
        }
    }
}
