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
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindAll<Disadvantage>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new DisadvantageDataAccess().FindOne<Disadvantage>(id));
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
            disadvantage.Formula = Request.Form["Formula"];
            if (Request.Form["Mental"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Mental));
            if (Request.Form["Physical"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Physical));
            if (Request.Form["Social"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Social));
            if (Request.Form["Exotic"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Exotic));
            if (Request.Form["Supernatural"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Supernatural));
            if (Request.Form["Mundane"].Contains("true")) disadvantage.Types.Add(nameof(Disadvantage.DisadvantageTypes.Mundane));
            new DisadvantageDataAccess().InsertOne(disadvantage);
            return RedirectToAction("Main", "Admin");
        }
    }
}
