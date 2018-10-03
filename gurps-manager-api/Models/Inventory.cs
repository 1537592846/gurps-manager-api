using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Inventory
    {
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