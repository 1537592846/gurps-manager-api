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
            OneHandWeapons = new List<Item>();
            TwoHandWeapons = new List<Item>();
            Shields = new List<Item>();
            Armors = new List<Item>();
            Consumables = new List<Item>();
            Others = new List<Item>();
        }

        [BsonElement("OneHandWeapons")]
        public List<Item> OneHandWeapons;

        [BsonElement("TwoHandWeapons")]
        public List<Item> TwoHandWeapons;

        [BsonElement("Shields")]
        public List<Item> Shields;

        [BsonElement("Armors")]
        public List<Item> Armors;

        [BsonElement("Consumables")]
        public List<Item> Consumables;

        [BsonElement("Others")]
        public List<Item> Others;
    }
}