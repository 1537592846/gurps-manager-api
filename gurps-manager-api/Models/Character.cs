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

        [BsonElement("Resources")]
        public int Resources;

        [BsonElement("Status")]
        public Dictionary<string, int> Status;

        [BsonElement("Languages")]
        public List<Language> Languages;

        [BsonElement("Skills")]
        public List<Skill> Skills;

        [BsonElement("Disadvantages")]
        public List<Disadvantage> Disadvantages;

        [BsonElement("Advantages")]
        public List<Advantage> Advantages;

        [BsonElement("Inventory")]
        public Inventory Inventory;

        [BsonElement("Equipments")]
        public Equipments Equipments;

        public Character()
        {
            Status = new Dictionary<string, int>();
            Languages = new List<Language>();
            Skills = new List<Skill>();
            Advantages = new List<Advantage>();
            Disadvantages = new List<Disadvantage>();
            Inventory = new Inventory();
            Equipments = new Equipments();
        }
    }
}
