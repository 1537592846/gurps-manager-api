using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Character
    {
        public ObjectId DBId;

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Age")]
        public int Age;

        [BsonElement("Height")]
        public double Height;

        [BsonElement("Weight")]
        public double Weight;

        [BsonElement("MinimunStatusPoints")]
        public int MinimunStatusPoints;

        [BsonElement("MaxPoints")]
        public int MaxPoints;

        [BsonElement("CurrentPoints")]
        public int CurrentPoints;

        [BsonElement("Resouces")]
        public List<Resource> Resouces;

        [BsonElement("Status")]
        public Dictionary<string, int> Status;
    }
}
