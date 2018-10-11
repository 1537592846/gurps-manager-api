using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gurps_manager_library.Models
{
    public class Language
    {
        public ObjectId DBId;
        enum LanguageLevels { None, Broken, Accented, Native };

        public Language()
        {
            this.Level = 0;
            this.LevelCap = 3;
        }

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Level")]
        public int Level;

        [BsonElement("LevelCap")]
        public int LevelCap;
    }
}
