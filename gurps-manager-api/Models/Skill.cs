using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Skill
    {
        public ObjectId DBId;
        public enum SkillTypes { Easy, Moderate, Hard, VeryHard };

        public Skill()
        {
            this.Level = 0;
            this.Cost = 3;
        }

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Attribute")]
        public string Attribute;

        [BsonElement("Difficulty")]
        public string Difficulty;

        [BsonElement("Level")]
        public int Level;

        [BsonElement("Cost")]
        public int Cost;
    }
}
