using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace gurps_manager_library.Models
{
    public class Disadvantage
    {
        public ObjectId DBId;
        enum DisadvantageTypes { Mental, Physical, Social, Exotic, Supernatural };

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

        public static void InsertDisadvantages()
        {
            var disadvantage = new Disadvantage();

            disadvantage = new Disadvantage()
            {
                Id = 1,
                Name = "Quarrelsome",
                Description = "The character likes to intimidate people whenever it is possible to do so with impunity. Depending on the personality and position he occupies, this may take the form of physical assaults, intellectual hostility or a social ''ice.'' He must do a self-control test to not perform a coarse bravado when he knows he should not - but to represent the character correctly, he should cause as many people as he can. Since no one likes a buck, his reaction tests suffer a -2 penalty.",
                Cost = 10,
                Level = 0,
                LevelCap = 1,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Mental)
                },
                Formula = "{self_control_test:\"fight\"}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);

            disadvantage = new Disadvantage()
            {
                Id = 2,
                Name = "Extra mouth",
                Description = "The character has more than one functional mouth, which can be anywhere on the body. All mouths are able to breathe, eat and talk. Additional Mouth allows the character to bite more than once if he has Additional Attacks (page 42). If you have Segmented Mind (p. 70), the character is able to hold several conversations at the same time or perform two spells that require him to recite words. Other added benefits include difficulty silencing or suffocating the character and the ability to sing in harmony with yourself!",
                Cost = 5,
                Level = 0,
                LevelCap = int.MaxValue,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Physical),
                    nameof(DisadvantageTypes.Exotic)
                },
                Formula = "{}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);

            disadvantage = new Disadvantage()
            {
                Id = 3,
                Name = "Good sense",
                Description = "Whenever the character starts to do something that the GM considers STUPID, he should take a test against the character's IQ. In the case of a success, he should warn the player ''Don't you think it would be better to think about it again?'' This DisEquipment allows an impulsive player to play a weighted character.",
                Cost = 10,
                Level = 0,
                LevelCap = 1,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Mental)
                },
                Formula = "{}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);

            disadvantage = new Disadvantage()
            {
                Id = 4,
                Name = "Good fit",
                Description = "The character has a healthier cardiovascular system than his HT value indicates. The character gets a +1 bonus on all HT tests (to maintain awareness, avoid death, resist diseases and poisons, etc.). This does not improve the value of HT or the skills based on it! It also recovers PF at twice the normal speed. This DisEquipment applies only to PF lost through exertion, heat, etc. It has no effect on the FP expenditures for doing magic or using psychic powers.",
                Cost = 5,
                Level = 0,
                LevelCap = 1,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Physical)
                },
                Formula = "{health_test:\"+1\",fatigue_recovery:\"*2\"}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);

            disadvantage = new Disadvantage()
            {
                Id = 5,
                Name = "Great fit",
                Description = "The character has a healthier cardiovascular system than his HT value indicates. The character gets a +2 bonus on all HT tests (to maintain awareness, avoid death, resist diseases and poisons, etc.). This does not improve the value of HT or the skills based on it! It also recovers PF at twice the normal speed. In addition, the character loses PF at half normal speed. This DisEquipment applies only to PF lost through exertion, heat, etc. It has no effect on the FP expenditures for doing magic or using psychic powers.",
                Cost = 5,
                Level = 0,
                LevelCap = 1,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Physical)
                },
                Formula = "{health_test:\"+1\",fatigue_recovery:\"*2\",fatigue_use:\"/2\"}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);

            disadvantage = new Disadvantage()
            {
                Id = 6,
                Name = "Fearless",
                Description = "It's not easy to scare or intimidate the character! Add the character's Fearless level to the Will attribute each time he or she performs a Panic Check or has to resist the Intimidation skill (p. 204) or a supernatural power that induces fear. The level of Fearless should also be subtracted from the Intimidation tests made against it.",
                Cost = 2,
                Level = 0,
                LevelCap = int.MaxValue,
                Types = new List<string>(){
                    nameof(DisadvantageTypes.Mental)
                },
                Formula = "{panic_test:\"+level\",intimidation_test:\"+level\",fear:\"+level\"}"
            };
            new DisadvantageDataAccess().InsertOne(disadvantage);
        }
    }
}
