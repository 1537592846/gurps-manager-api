using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gurps_manager_library.Models
{
    public class Equipment
    {
        public ObjectId DBId;

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Cost")]
        public int Cost;

        [BsonElement("Weight")]
        public double Weight;

        [BsonElement("Formula")]
        public string Formula;
    }
}
