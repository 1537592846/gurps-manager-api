using gurps_manager_library.DataAccess;
using gurps_manager_library.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gurps_manager_api.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        [HttpGet("get")]
        public string Get()
        {
            return JsonConvert.SerializeObject(new CharacterDataAccess().FindAll<Character>());
        }

        [HttpGet("get/{id}")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(new CharacterDataAccess().FindOne<Character>(id));
        }

        [HttpGet("list")]
        public string List()
        {
            var charactersJson = new List<CharacterJson>();
            foreach (var character in new CharacterDataAccess().FindAll<Character>())
            {
                charactersJson.Add(new CharacterJson()
                {
                    Id = character.Id,
                    Name = character.Name,
                    Description = character.Description
                });
            }
            return JsonConvert.SerializeObject(charactersJson);
        }

        [HttpGet("next")]
        public string Next()
        {
            var characters = new CharacterDataAccess().FindAll<Character>();
            int id = 1;
            if (characters.Count != 0)
            {
                id = characters.OrderBy(x => x.Id).First().Id + 1;
            }
            return id.ToJson();
        }

        [HttpPost("save")]
        public bool Save([FromBody]JObject content)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(content.ToString());
                Character character = new Character();
                try
                {
                    character = new CharacterDataAccess().FindOne(data.id);
                }
                catch { }
                character.Id = data.id;
                character.Name = data.name;
                character.Age = data.age == "" ? 0 : data.age;
                character.Height = data.height == "" ? 0 : data.height;
                character.Weight = data.weight == "" ? 0 : data.weight;
                character.MinimunStatusPoints = data.min_status;
                character.MaxPoints = data.max_points;
                character.CurrentPoints = data.current_points;
                character.Resources = data.resources;
                character.Description = data.description == "" ? "" : data.description;
                character.Status.Add("Strenght", (int)data.strenght);
                character.Status.Add("Dexterity", (int)data.dexterity);
                character.Status.Add("Intelligence", (int)data.intelligence);
                character.Status.Add("Health", (int)data.health);
                character.Status.Add("MaxLifePoints", (int)data.max_life_points);
                character.Status.Add("CurrentLifePoints", (int)data.current_life_points);
                character.Status.Add("Will", (int)data.will);
                character.Status.Add("Perception", (int)data.perception);
                character.Status.Add("MaxFatiguePoints", (int)data.max_fatigue_points);
                character.Status.Add("CurrentFatiguePoints", (int)data.current_fatigue_points);
                character.Status.Add("Speed", (int)data.speed);
                character.Status.Add("BasicMovement", (int)data.basic_movement);
                character.Status.Add("MaxCarryWeight", (int)data.max_carry_weight);
                character.Status.Add("CurrentCarryWeight", (int)data.current_carry_weight);
                try
                {
                    var left_hand = JsonConvert.DeserializeObject(data.equipments.left_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.LeftHand = new EquipmentDataAccess().FindByName(left_hand.name);
                }
                catch
                {
                    character.Equipments.LeftHand = new Equipment();
                }
                try
                {
                    var right_hand = JsonConvert.DeserializeObject(data.equipments.right_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.RightHand = new EquipmentDataAccess().FindByName(right_hand.name);
                }
                catch
                {
                    character.Equipments.RightHand = new Equipment();
                }
                try
                {
                    var both_hand = JsonConvert.DeserializeObject(data.equipments.both_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.BothHands = new EquipmentDataAccess().FindByName(both_hand.name);
                }
                catch
                {
                    character.Equipments.BothHands = new Equipment();
                }
                try
                {
                    var shield = JsonConvert.DeserializeObject(data.equipments.shield.ToString().Replace("\r\n", ""));
                    character.Equipments.Shield = new EquipmentDataAccess().FindByName(shield.name);
                }
                catch
                {
                    character.Equipments.Shield = new Equipment();
                }
                try
                {
                    var hands = JsonConvert.DeserializeObject(data.equipments.hands.ToString().Replace("\r\n", ""));
                    character.Equipments.Hands = new EquipmentDataAccess().FindByName(hands.name);
                }
                catch
                {
                    character.Equipments.Hands = new Equipment();
                }
                try
                {
                    var torax = JsonConvert.DeserializeObject(data.equipments.torax.ToString().Replace("\r\n", ""));
                    character.Equipments.Torax = new EquipmentDataAccess().FindByName(torax.name);
                }
                catch
                {
                    character.Equipments.Torax = new Equipment();
                }
                try
                {
                    var legs = JsonConvert.DeserializeObject(data.equipments.legs.ToString().Replace("\r\n", ""));
                    character.Equipments.Legs = new EquipmentDataAccess().FindByName(legs.name);
                }
                catch
                {
                    character.Equipments.Legs = new Equipment();
                }
                try
                {
                    var feet = JsonConvert.DeserializeObject(data.equipments.feet.ToString().Replace("\r\n", ""));
                    character.Equipments.Feet = new EquipmentDataAccess().FindByName(feet.name);
                }
                catch
                {
                    character.Equipments.Feet = new Equipment();
                }
                try
                {
                    var arms = JsonConvert.DeserializeObject(data.equipments.arms.ToString().Replace("\r\n", ""));
                    character.Equipments.Arms = new EquipmentDataAccess().FindByName(arms.name);
                }
                catch
                {
                    character.Equipments.Arms = new Equipment();
                }
                try
                {
                    var hands = JsonConvert.DeserializeObject(data.equipments.hands.ToString().Replace("\r\n", ""));
                    character.Equipments.Hands = new EquipmentDataAccess().FindByName(hands.name);
                }
                catch
                {
                    character.Equipments.Hands = new Equipment();
                }
                foreach (var language in data.languages)
                {
                    Language languageDatabase = new LanguageDataAccess().FindOne<Language>((int)language.id);
                    languageDatabase.Level = language.level;
                    character.Languages.Add(languageDatabase);
                }
                foreach (var skill in data.skills)
                {
                    Skill skillDatabase = new SkillDataAccess().FindOne<Skill>((int)skill.id);
                    skillDatabase.Level = skill.level;
                    character.Skills.Add(skillDatabase);
                }
                foreach (var advantage in data.advantages)
                {
                    Advantage advantageDatabase = new AdvantageDataAccess().FindOne<Advantage>((int)advantage.id);
                    advantageDatabase.Level = advantage.level;
                    character.Advantages.Add(advantageDatabase);
                }
                foreach (var disadvantage in data.disadvantages)
                {
                    Disadvantage disadvantageDatabase = new DisadvantageDataAccess().FindOne<Disadvantage>((int)disadvantage.id);
                    disadvantageDatabase.Level = disadvantage.level;
                    character.Disadvantages.Add(disadvantageDatabase);
                }
                foreach (var equipment in data.inventory.one_hand_weapons)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.OneHandWeapons.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.two_hand_weapons)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.OneHandWeapons.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.shields)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.OneHandWeapons.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.armors)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.OneHandWeapons.Add(equipmentDatabase);
                }
                foreach (var item in data.inventory.consumables)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Consumables.Add(itemDatabase);
                }
                foreach (var item in data.inventory.others)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Others.Add(itemDatabase);
                }
                new CharacterDataAccess().InsertOne<Character>(character);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [HttpPost("update")]
        public bool Update([FromBody]JObject content)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(content.ToString());
                int id = (int)data.id;
                var character = new CharacterDataAccess().FindOne<Character>(id);
                character.Resources = data.resources;
                character.Status["MaxLifePoints"] = (int)data.max_life_points;
                character.Status["CurrentLifePoints"] = (int)data.current_life_points;
                character.Status["MaxFatiguePoints"] = (int)data.max_fatigue_points;
                character.Status["CurrentFatiguePoints"] = (int)data.current_fatigue_points;
                character.Status["MaxCarryWeight"] = (int)data.max_carry_weight;
                character.Status["CurrentCarryWeight"] = (int)data.current_carry_weight;
                try
                {
                    var left_hand = JsonConvert.DeserializeObject(data.equipments.left_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.LeftHand = new EquipmentDataAccess().FindByName(left_hand.name);
                }
                catch
                {
                    character.Equipments.LeftHand = new Equipment();
                }
                try
                {
                    var right_hand = JsonConvert.DeserializeObject(data.equipments.right_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.RightHand = new EquipmentDataAccess().FindByName(right_hand.name);
                }
                catch
                {
                    character.Equipments.RightHand = new Equipment();
                }
                try
                {
                    var both_hand = JsonConvert.DeserializeObject(data.equipments.both_hand.ToString().Replace("\r\n", ""));
                    character.Equipments.BothHands = new EquipmentDataAccess().FindByName(both_hand.name);
                }
                catch
                {
                    character.Equipments.BothHands = new Equipment();
                }
                try
                {
                    var shield = JsonConvert.DeserializeObject(data.equipments.shield.ToString().Replace("\r\n", ""));
                    character.Equipments.Shield = new EquipmentDataAccess().FindByName(shield.name);
                }
                catch
                {
                    character.Equipments.Shield = new Equipment();
                }
                try
                {
                    var hands = JsonConvert.DeserializeObject(data.equipments.hands.ToString().Replace("\r\n", ""));
                    character.Equipments.Hands = new EquipmentDataAccess().FindByName(hands.name);
                }
                catch
                {
                    character.Equipments.Hands = new Equipment();
                }
                try
                {
                    var torax = JsonConvert.DeserializeObject(data.equipments.torax.ToString().Replace("\r\n", ""));
                    character.Equipments.Torax = new EquipmentDataAccess().FindByName(torax.name);
                }
                catch
                {
                    character.Equipments.Torax = new Equipment();
                }
                try
                {
                    var legs = JsonConvert.DeserializeObject(data.equipments.legs.ToString().Replace("\r\n", ""));
                    character.Equipments.Legs = new EquipmentDataAccess().FindByName(legs.name);
                }
                catch
                {
                    character.Equipments.Legs = new Equipment();
                }
                try
                {
                    var feet = JsonConvert.DeserializeObject(data.equipments.feet.ToString().Replace("\r\n", ""));
                    character.Equipments.Feet = new EquipmentDataAccess().FindByName(feet.name);
                }
                catch
                {
                    character.Equipments.Feet = new Equipment();
                }
                try
                {
                    var arms = JsonConvert.DeserializeObject(data.equipments.arms.ToString().Replace("\r\n", ""));
                    character.Equipments.Arms = new EquipmentDataAccess().FindByName(arms.name);
                }
                catch
                {
                    character.Equipments.Arms = new Equipment();
                }
                try
                {
                    var hands = JsonConvert.DeserializeObject(data.equipments.hands.ToString().Replace("\r\n", ""));
                    character.Equipments.Hands = new EquipmentDataAccess().FindByName(hands.name);
                }
                catch
                {
                    character.Equipments.Hands = new Equipment();
                }
                character.Inventory = new Inventory();
                foreach (var equipment in data.inventory.one_hand_weapons)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.OneHandWeapons.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.two_hand_weapons)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.TwoHandWeapons.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.shields)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.Shields.Add(equipmentDatabase);
                }
                foreach (var equipment in data.inventory.armors)
                {
                    Equipment equipmentDatabase = new EquipmentDataAccess().FindOne<Equipment>((int)equipment.id);
                    character.Inventory.Armors.Add(equipmentDatabase);
                }
                foreach (var item in data.inventory.consumables)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Consumables.Add(itemDatabase);
                }
                foreach (var item in data.inventory.others)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Others.Add(itemDatabase);
                }
                new CharacterDataAccess().Update<Character>(character.Id, character);
            }
            catch
            {
                return false;
            }
            return true;
        }

        [HttpGet("delete")]
        public void Delete()
        {
            new CharacterDataAccess().DeleteAll<Character>();
        }
    }
}
