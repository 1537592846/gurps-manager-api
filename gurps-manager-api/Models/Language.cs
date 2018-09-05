using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gurps_manager_library.Models
{
    public class Language
    {
        public ObjectId DBId;
        enum LanguageLevels { None, Broken, Accented, Native };

        [BsonElement("Id")]
        public int Id;

        [BsonElement("Name")]
        public string Name;

        [BsonElement("Description")]
        public string Description;

        [BsonElement("Cost")]
        public int Cost;

        [BsonElement("Level")]
        public int Level;

        [BsonElement("LevelCap")]
        public int LevelCap;

        public Language()
        {
            this.Cost = 2;
            this.Level = 0;
            this.LevelCap = 3;
        }

        public static void InsertLanguages()
        {
            var language = new Language();

            language = new Language()
            {
                Id = 1,
                Name = "Latin",
                Description = "Latin is a classical language belonging to the Italic branch of the Indo-European languages."
            };
            new LanguageDataAccess().InsertOne(language);

            language = new Language()
            {
                Id = 2,
                Name = "Anglo-Saxon",
                Description = "Anglo-Saxon is the earliest historical form of the English language, spoken in England and southern and eastern Scotland in the early Middle Ages."
            };
            new LanguageDataAccess().InsertOne(language);

            language = new Language()
            {
                Id = 3,
                Name = "Germanic",
                Description = "The Germanic languages are a branch of the Indo-European language family spoken natively by a population of about 515 million people mainly in Europe, North America, Oceania, and Southern Africa."
            };
            new LanguageDataAccess().InsertOne(language);

            language = new Language()
            {
                Id = 4,
                Name = "Merchant",
                Description = "Merchant language is a pseudo-language created by merchant nomads to comunicate with multiple villages that could not understand their native language."
            };
            new LanguageDataAccess().InsertOne(language);

            language = new Language()
            {
                Id = 4,
                Name = "Universal",
                Description = "The Universal language was established during the first and second space explorations, allowing to different planets to communicate."
            };
            new LanguageDataAccess().InsertOne(language);
        }
    }
}
