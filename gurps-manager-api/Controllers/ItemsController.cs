using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return new ItemDataAccess().ReturnAllData<Item>();
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return new ItemDataAccess().Find(id);
        }

        [HttpGet("insert")]
        public void Insert()
        {
            Item.InsertItems();
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new ItemDataAccess().DeleteAll<Item>();
        }
    }
}
