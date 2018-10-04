using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Item
    {
        public ObjectId DBId;

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("NT")]
        public int NT;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Cost")]
        public int Cost;

        [BsonElement("Weight")]
        public double Weight;

        [BsonElement("Quantity")]
        public int Quantity;

        [BsonElement("Formula")]
        public string Formula;

        public Item()
        {
            Cost = 0;
        }

        public static void InsertItems()
        {
            var item = new Item();

            item = new Item()
            {
                Id = 1,
                Name = "Line and Hook",
                NT = 0,
                Description = "Basic equipment for the Fishing skill. Requires a fishing rod.",
                Cost = 50,
                Weight = 0,
                Formula = ""
            };
            new ItemDataAccess().InsertOne(item);

            item = new Item()
            {
                Id = 2,
                Name = "Isqueiro",
                NT = 6,
                Description = "Starts a fire",
                Cost = 10,
                Weight = 0,
                Formula = ""
            };
            new ItemDataAccess().InsertOne(item);

            item = new Item()
            {
                Id = 3,
                Name = "Laser dot",
                NT = 8,
                Description = "Laser aim for guns.",
                Cost = 15,
                Weight = 0,
                Formula = "shooting_skill:+1"
            };

            item = new Item()
            {
                Id = 4,
                Name = "2m Rod",
                NT = 0,
                Description = "To fixate tents, to use as a fishing rod or as a piercing tool.",
                Cost = 5,
                Weight = 1.5,
                Formula = ""
            };
            new ItemDataAccess().InsertOne(item);
        }
    }
}
