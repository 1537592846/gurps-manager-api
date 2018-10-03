using gurps_manager_library.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace gurps_manager_library.Models
{
    public class Equipments
    {
        [BsonElement("LeftHand")]
        public Equipment LeftHand;

        [BsonElement("RightHand")]
        public Equipment RightHand;

        [BsonElement("BothHands")]
        public Equipment BothHands;

        [BsonElement("Shield")]
        public Equipment Shield;

        [BsonElement("Head")]
        public Equipment Head;

        [BsonElement("Torax")]
        public Equipment Torax;

        [BsonElement("Legs")]
        public Equipment Legs;

        [BsonElement("Feet")]
        public Equipment Feet;

        [BsonElement("Arms")]
        public Equipment Arms;

        [BsonElement("Hands")]
        public Equipment Hands;
    }
}