using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gurps_manager_library.Models
{
    public class Equipment
    {
        public Equipment()
        {
            Bought = false;
            Equipped = "";
        }

        public ObjectId DBId;

        [BsonElement("Id")]
        public int Id;

        [BsonElement("NT")]
        public int NT;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Cost")]
        public double Cost;

        [BsonElement("Weight")]
        public double Weight;

        [BsonElement("Formula")]
        public string Formula;

        [BsonElement("SkillUsed")]
        public string SkillUsed;

        [BsonElement("Type")]
        public string Type;

        [BsonElement("Bought")]
        public bool Bought;

        [BsonElement("Equipped")]
        public string Equipped;
    }
}
