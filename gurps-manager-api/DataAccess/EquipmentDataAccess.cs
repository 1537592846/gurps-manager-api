using gurps_manager_library.Models;
using System.Collections.Generic;
using System.Linq;

namespace gurps_manager_library.DataAccess
{
    public class EquipmentDataAccess : DataAccess
    {
        public EquipmentDataAccess() : base("Equipments")
        {
        }

        public List<Equipment> FindByType(string type)
        {
            return base.FindAll<Equipment>().Where(x => x.Type == type).ToList();
        }

        public Equipment Find(dynamic equipment)
        {
            int id = (int)equipment.id;
            return base.FindOne<Equipment>(id);
        }
    }
}