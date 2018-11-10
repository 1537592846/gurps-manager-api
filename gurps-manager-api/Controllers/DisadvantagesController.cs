using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class DisadvantagesController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            try { 
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindAll<Disadvantage>());
            }
            catch
            {
                return "{}";
            }
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            try { 
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindOne<Disadvantage>(id));
            }
            catch
            {
                return "{}";
            }
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new DisadvantageDataAccess().DeleteAll<Disadvantage>();
        }

        [Route("AddDisadvantage")]
        public ActionResult AddDisadvantage()
        {
            return View();
        }

        [Route("AddDisadvantage")]
        [HttpPost]
        public ActionResult AddDisadvantage(Disadvantage disadvantage)
        {
            var list = new DisadvantageDataAccess().FindAll<Disadvantage>();
            disadvantage.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            disadvantage.Name = Request.Form["Name"];
            disadvantage.Description = Request.Form["Description"];
            disadvantage.Cost = int.Parse(Request.Form["Cost"]);
            disadvantage.Level = 0;
            disadvantage.LevelCap = int.Parse(Request.Form["LevelCap"]);
            if (disadvantage.LevelCap == 0) disadvantage.LevelCap = int.MaxValue;
            disadvantage.Formula = Request.Form["Formula"];
            disadvantage.Types.AddRange(Request.Form.Where(x => x.Value.Contains("true")).Select(x => x.Key));
            new DisadvantageDataAccess().InsertOne(disadvantage);
            return RedirectToAction("Main", "Admin");
        }
    }
}
