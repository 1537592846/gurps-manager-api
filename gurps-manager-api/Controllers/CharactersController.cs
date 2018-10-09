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
                character.Age = data.age == null ? 0 : data.age;
                character.Height = data.height == null ? 0 : data.height;
                character.Weight = data.weight == null ? 0 : data.weight;
                character.MinimunStatusPoints = data.min_status;
                character.MaxPoints = data.max_points;
                character.CurrentPoints = data.current_points;
                character.Resources = data.resource == null ? 0 : data.resource;
                character.Description = data.description == null ? "" : data.description;
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
                character.Equipments.LeftHand = data.equipments.left_hand.ToString() == "{}" ? null : data.equipments.left_hand;
                character.Equipments.RightHand = data.equipments.right_hand.ToString() == "{}" ? null : data.equipments.right_hand;
                character.Equipments.BothHands = data.equipments.both_hands.ToString() == "{}" ? null : data.equipments.both_hands;
                character.Equipments.Shield = data.equipments.shield.ToString() == "{}" ? null : data.equipments.shield;
                character.Equipments.Hands = data.equipments.head.ToString() == "{}" ? null : data.equipments.head;
                character.Equipments.Torax = data.equipments.torax.ToString() == "{}" ? null : data.equipments.torax;
                character.Equipments.Legs = data.equipments.legs.ToString() == "{}" ? null : data.equipments.legs;
                character.Equipments.Feet = data.equipments.feet.ToString() == "{}" ? null : data.equipments.feet;
                character.Equipments.Arms = data.equipments.arms.ToString() == "{}" ? null : data.equipments.arms;
                character.Equipments.Hands = data.equipments.hands.ToString() == "{}" ? null : data.equipments.hands;
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
                foreach (var disadvantage in data.disadvantage)
                {
                    Disadvantage disadvantageDatabase = new DisadvantageDataAccess().FindOne<Disadvantage>((int)disadvantage.id);
                    disadvantageDatabase.Level = disadvantage.level;
                    character.Disadvantages.Add(disadvantageDatabase);
                }
                foreach (var item in data.inventory.one_hand_weapons)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.OneHandWeapons.Add(itemDatabase);
                }
                foreach (var item in data.inventory.two_hand_weapons)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.TwoHandWeapons.Add(itemDatabase);
                }
                foreach (var item in data.inventory.shields)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Shields.Add(itemDatabase);
                }
                foreach (var item in data.inventory.armors)
                {
                    Item itemDatabase = new ItemDataAccess().FindOne<Item>((int)item.id);
                    itemDatabase.Quantity = item.quantity;
                    character.Inventory.Armors.Add(itemDatabase);
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
            catch (Exception e)
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
