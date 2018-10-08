using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Advantage
    {
        public ObjectId DBId;
        public enum AdvantageTypes { Mental,Physical,Social,Exotic,Supernatural,Mundane };

        public Advantage()
        {
            Types = new List<string>();
            Level = 0;
        }

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Types")]
        public List<string> Types;

        [BsonElement("Cost")]
        public int Cost;

        [BsonElement("Level")]
        public int Level;

        [BsonElement("LevelCap")]
        public int LevelCap;

        [BsonElement("Formula")]
        public string Formula;
    }
}
