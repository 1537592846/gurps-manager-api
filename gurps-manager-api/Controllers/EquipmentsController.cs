using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class EquipmentsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            try { 
            return JsonConvert.SerializeObject(new EquipmentDataAccess().FindAll<Equipment>());
            }
            catch
            {
                return "{}";
            }
        }

        [HttpGet("getType/{type}")]
        public string Get(string type)
        {
            try { 
            return JsonConvert.SerializeObject(new EquipmentDataAccess().FindByType(type));
            }
            catch
            {
                return "{}";
            }
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new EquipmentDataAccess().FindOne<Equipment>(id)) ;
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new EquipmentDataAccess().DeleteAll<Equipment>();
        }

        [Route("AddEquipment")]
        public ActionResult AddEquipment()
        {
            return View();
        }

        [Route("AddEquipment")]
        [HttpPost]
        public ActionResult AddEquipment(Equipment equipment)
        {
            var list = new EquipmentDataAccess().FindAll<Equipment>();
            equipment.Id = list.Count == 0 ? 1 : list.Last().Id + 1;
            equipment.Name = Request.Form["Name"];
            equipment.Description = Request.Form["Description"];
            equipment.Cost = int.Parse(Request.Form["Cost"]);
            equipment.Weight = double.Parse(Request.Form["Weight"]);
            equipment.Formula = Request.Form["Formula"];
            equipment.NT = int.Parse(Request.Form["NT"]);
            new EquipmentDataAccess().InsertOne(equipment);
            return RedirectToAction("Main", "Admin");
        }
    }
}
