using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class EquipmentsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new EquipmentDataAccess().FindAll<Equipment>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new EquipmentDataAccess().FindOne<Equipment>(id)) ;
        }

        [HttpGet("insert")]
        public void Insert()
        {
            Equipment.InsertEquipments();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new EquipmentDataAccess().DeleteAll<Equipment>();
        }
    }
}
