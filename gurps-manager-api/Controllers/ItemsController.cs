using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

        [HttpGet("getType/{type}")]
        public string Get(string type)
        {
            return JsonConvert.SerializeObject(new ItemDataAccess().FindByType(type));
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

        [Route("add")]
        public bool AddItem([FromBody]JObject content)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(content.ToString());
                if (data.type == "consumable" || data.type == "other")
                {
                    Item item = new Item()
                    {
                        Id = NextId(data.type.ToString()),
                        Cost = data.cost,
                        Description = data.description,
                        Formula = data.formula,
                        Name = data.name,
                        NT = data.nt,
                        Quantity = data.quantity,
                        Type = data.type,
                        Weight = data.weight
                    };
                    new ItemDataAccess().InsertOne(item);
                }
                else
                {
                    Equipment equipment = new Equipment()
                    {
                        Id = NextId(data.type.ToString()),
                        Cost = data.cost,
                        Description = data.description,
                        Formula = data.formula,
                        Name = data.name,
                        NT = data.nt,
                        Type = data.type,
                        Weight = data.weight
                    };
                    new EquipmentDataAccess().InsertOne(equipment);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public int NextId(string type)
        {
            int id = 1;
            if (type == "consumable" || type == "other")
            {
                var items = new ItemDataAccess().FindAll<Item>();
                if (items.Count != 0)
                {
                    id = items.OrderBy(x => x.Id).Last().Id + 1;
                }
            }
            else
            {
                var equipments = new EquipmentDataAccess().FindAll<Equipment>();
                if (equipments.Count != 0)
                {
                    id = equipments.OrderBy(x => x.Id).Last().Id + 1;
                }
            }
            return id;
        }
    }
}
