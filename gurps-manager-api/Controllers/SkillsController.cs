using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new SkillDataAccess().FindAll<Skill>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new SkillDataAccess().FindOne<Skill>(id));
        }

        [HttpGet("insert")]
        public void Insert()
        {
            Skill.InsertSkills();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new SkillDataAccess().DeleteAll<Skill>();
        }
    }
}
