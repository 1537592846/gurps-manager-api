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

        public static void InsertEquipments()
        {
            var equipment = new Equipment();

            equipment = new Equipment()
            {
                Id = 1,
                Name="Shield of shielding",
                Cost=100,
                Weight=4,
                Description="A shield forged by a coward to protect for all attacks.",
                Formula= "{NT:2,type:\"shield\",defence_bonus:\"+3\",damage_resistance:9,life_points:75}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 2,
                Name = "Shield of berserker",
                Cost = 450,
                Weight=2,
                Description = "Attack is as good as defence, said the one that forged this shield.",
                Formula = "{NT:1,type:\"shield\",defence_bonus:\"+1\",cost:45,damage_resistance:1,life_points:80}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 3,
                Name = "Leather armor",
                Cost = 100,
                Weight=5,
                Description = "A simple leather overcoat that manages to stop shallow cuts and small blunt attacks.",
                Formula = "{NT:1,type:\"body_armor\",location:\"chest,crotch\",damage_resistance:2}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 4,
                Name = "Bronze Armlet",
                Cost = 180,
                Weight=4.5,
                Description = "Arm guard capable of defending from sharp sword attacks, if timed and aimed correctly.",
                Formula = "{NT:1,type:\"piece_armor\",location:\"arm\",damage_resistance:3}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 5,
                Name = "Bronze Greaves",
                Cost = 270,
                Weight = 8.5,
                Description = "Arm guard capable of defending from sharp sword attacks, if timed and aimed correctly.",
                Formula = "{NT:1,type:\"piece_armor\",location:\"legs\",damage_resistance:3}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 6,
                Name = "Bronze Elm",
                Cost = 160,
                Weight = 3.7,
                Description = "A hero must-have piece of armor, forged with bronze.",
                Formula = "{NT:1,type:\"piece_armor\",location:\"head,face\",damage_resistance:3}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 7,
                Name = "Reforced Gauntlet",
                Cost = 250,
                Weight = 1.2,
                Description = "A hero must-have piece of armor, forged with bronze.",
                Formula = "{NT:3,type:\"piece_armor\",location:\"hand\",damage_resistance:5}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 8,
                Name = "Boots",
                Cost = 80,
                Weight = 1.5,
                Description = "A hero must-have piece of armor, forged with bronze.",
                Formula = "{NT:2,type:\"piece_armor\",location:\"feet\",damage_resistance:2}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 9,
                Name = "Mace",
                Cost = 50,
                Weight = 2.5,
                Description = "A small and heavy one-handed ball of iron, made to destroy objects with a big swing.",
                Formula = "{NT:2,type:\"short_range_weapon\",balancing_attack:\"+3 blunt\", range:1,parry:\"0D\",strengh:12}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 10,
                Name = "Greatsword",
                Cost = 500,
                Weight = 1.5,
                Description = "A long sword, sometimes refered as one-and-half sword, made for a warrior.",
                Formula = "{NT:2,type:\"short_range_weapon\",balancing_attack:\"+1 cut\",piercing_attack:\"+1 blunt\", range:1,parry:\"0\",strengh:10}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 11,
                Name = "Long Bow",
                Cost = 200,
                Weight = 1.5,
                Description = "Long ranged weapon, simple yet effective to kill unsuspected enemies.",
                Formula = "{NT:0,type:\"long_range_weapon\",piercing_attack:\"+2 pierce\",precision:3,range_min:15,range_max:20,cadency:1,clip_size:\"1\",recharge_turn:2,strenght:11}"
            };
            new LanguageDataAccess().InsertOne(equipment);

            equipment = new Equipment()
            {
                Id = 12,
                Name = "Throw Axe",
                Cost = 60,
                Weight = 2,
                Description = "Small one-handed axes made for throwing.",
                Formula = "{NT:0,type:\"long_range_weapon\",balancing_attack:\"+2 cut\",precision:2,range_min:1,range_max:1.5,cadency:1,clip_size:\"A\",recharge_turn:1,strenght:11}"
            };
            new LanguageDataAccess().InsertOne(equipment);
        }
    }
}
