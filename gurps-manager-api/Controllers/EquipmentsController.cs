using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class EquipmentsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new EquipmentDataAccess().ReturnAllData<Equipment>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new EquipmentDataAccess().Find(id);
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
