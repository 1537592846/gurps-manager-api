using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Skill
    {
        public ObjectId DBId;
        enum SkillTypes { Easy,Moderate,Hard,VeryHard };

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

        public Skill()
        {
            this.Cost = 0;
            this.Level = 0;
        }

        public static void InsertSkills()
        {
            var skill = new Skill();

            skill = new Skill()
            {
                Id = 1,
                Name = "Alchemy",
                Description = "This is the study of magical transmutations. In a magical setting, an alchemist is able to identify mixtures with magical effects (''elixirs'') such as love potions and healing ointments and prepare them if they have the right ingredients. This is a mechanical process and uses the mana that is in certain elements and therefore, characters without Magic Aptitude are able to learn and use Alchemy and the Magic Aptitude does not confer any benefit.",
                Attribute = "IQ",
                Difficulty = nameof(SkillTypes.VeryHard)
            };
            new SkillDataAccess().InsertOne(skill);

            skill = new Skill()
            {
                Id = 2,
                Name = "Throwing",
                Description = "This is the ability to throw any small and relatively flat object that fits in the palm. Examples include baseballs, hand grenades, and stones (boomerangs, darts, knives, etc., require special skill, see Throwing Weapon, page 176). Take a skill check to reach the target. Also, if the character's NH in this skill is equal to DX + 1, add a bonus of 1 to ST when calculating throwing distance (but not damage). Add +2 to ST if the NH in Throw is greater than or equal to DX + 2. If the character does not have this skill, play against the default value when attempting to hit a specific target or against full DX to attempt to reach an area with a volley.",
                Attribute = "DX",
                Difficulty = nameof(SkillTypes.Moderate)
            };
            new SkillDataAccess().InsertOne(skill);
        }
    }
}
