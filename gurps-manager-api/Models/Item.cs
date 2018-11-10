using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Item
    {
        public ObjectId DBId;

        public Item()
        {
            Quantity = 0;
        }

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

        [BsonElement("Type")]
        public string Type;

        [BsonElement("Bought")]
        public bool Bought;
    }
}
