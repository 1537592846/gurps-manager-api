﻿using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

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

        [HttpGet("delete")]
        public void Delete()
        {
            new AdvantageDataAccess().DeleteAll<Advantage>();
        }

        [Route("AddAdvantage")]
        public ActionResult AddAdvantage()
        {
            return View();
        }

        [Route("AddAdvantage")]
        [HttpPost]
        public ActionResult AddAdvantage(Advantage advantage)
        { var list = new AdvantageDataAccess().FindAll<Advantage>();
            advantage.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            advantage.Name = Request.Form["Name"];
            advantage.Description = Request.Form["Description"];
            advantage.Cost = int.Parse(Request.Form["Cost"]);
            advantage.Level = 0;
            advantage.LevelCap = int.Parse(Request.Form["LevelCap"]);
            advantage.Formula = Request.Form["Formula"];
            if (Request.Form["Mental"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Mental));
            if (Request.Form["Physical"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Physical));
            if (Request.Form["Social"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Social));
            if (Request.Form["Exotic"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Exotic));
            if (Request.Form["Supernatural"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Supernatural));
            if (Request.Form["Mundane"].Contains("true")) advantage.Types.Add(nameof(Advantage.AdvantageTypes.Mundane));
            new AdvantageDataAccess().InsertOne(advantage);
            return RedirectToAction("Main", "Admin");
        }
    }
}
