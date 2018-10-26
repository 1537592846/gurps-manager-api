using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Inventory
    {
        public Inventory()
        {
            OneHandWeapons = new List<Equipment>();
            TwoHandWeapons = new List<Equipment>();
            Shields = new List<Equipment>();
            Armors = new List<Equipment>();
            Consumables = new List<Item>();
            Others = new List<Item>();
        }

        [BsonElement("OneHandWeapons")]
        public List<Equipment> OneHandWeapons;

        [BsonElement("TwoHandWeapons")]
        public List<Equipment> TwoHandWeapons;

        [BsonElement("Shields")]
        public List<Equipment> Shields;

        [BsonElement("Armors")]
        public List<Equipment> Armors;

        [BsonElement("Consumables")]
        public List<Item> Consumables;

        [BsonElement("Others")]
        public List<Item> Others;
    }
}