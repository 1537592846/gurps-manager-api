using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

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

        [HttpGet("delete")]
        public void Delete()
        {
            new SkillDataAccess().DeleteAll<Skill>();
        }

        [Route("AddSkill")]
        public ActionResult AddSkill()
        {
            return View();
        }

        [Route("AddSkill")]
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            var list = new SkillDataAccess().FindAll<Skill>();
            skill.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            skill.Name = Request.Form["Name"];
            skill.Description = Request.Form["Description"];
            skill.Attribute = Request.Form.Where(x => x.Value.Contains("true")).First().Key;
            skill.Difficulty = Request.Form.Where(x => x.Value.Contains("true")).Last().Key;
            new SkillDataAccess().InsertOne(skill);
            return RedirectToAction("Main", "Admin");
        }
    }
}