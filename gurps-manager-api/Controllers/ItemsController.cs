using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new ItemDataAccess().FindAll<Item>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new ItemDataAccess().FindOne<Item>(id));
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new ItemDataAccess().DeleteAll<Item>();
        }

        [Route("AddItem")]
        public ActionResult AddItem()
        {
            return View();
        }

        [Route("AddItem")]
        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            var list = new ItemDataAccess().FindAll<Item>();
            item.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            item.Name = Request.Form["Name"];
            item.Description = Request.Form["Description"];
            item.Cost = int.Parse(Request.Form["Cost"]);
            item.NT = int.Parse(Request.Form["NT"]);
            item.Weight = double.Parse(Request.Form["Weight"]);
            item.Formula = Request.Form["Formula"];
            new ItemDataAccess().InsertOne(item);
            return RedirectToAction("Main", "Admin");
        }
    }
}
