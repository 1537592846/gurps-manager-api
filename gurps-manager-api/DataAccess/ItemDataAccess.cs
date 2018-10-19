using gurps_manager_library.Models;
using System.Collections.Generic;
using System.Linq;

namespace gurps_manager_library.DataAccess
{
    public class ItemDataAccess : DataAccess
    {
        public ItemDataAccess() : base("Items")
        {
        }

        public List<Item> FindByType(string type)
        {
            return base.FindAll<Item>().Where(x => x.Type == type).ToList();
        }
    }
}