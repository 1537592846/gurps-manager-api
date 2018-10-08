namespace gurps_manager_library.Models
{
    public class CharacterApi
    {
        public object dataProvider { get; set; }
        public object id { get; set; }
        public object name { get; set; }
        public object age { get; set; }
        public object height { get; set; }
        public object weight { get; set; }
        public object min_status { get; set; }
        public object max_points { get; set; }
        public object current_points { get; set; }
        public object resource { get; set; }
        public object description { get; set; }
        public object strenght { get; set; }
        public object dexterity { get; set; }
        public object intelligence { get; set; }
        public object health { get; set; }
        public object max_life_points { get; set; }
        public object current_life_points { get; set; }
        public object will { get; set; }
        public object perception { get; set; }
        public object max_fatigue_points { get; set; }
        public object current_fatigue_points { get; set; }
        public object speed { get; set; }
        public object basic_movement { get; set; }
        public object max_carry_weight { get; set; }
        public object current_carry_weight { get; set; }
        public object languages { get; set; }
        public object skills { get; set; }
        public object Disadvantages { get; set; }
        public object disDisadvantages { get; set; }
        public object inventory { get; set; }
        public object equipments { get; set; }
    }

    public class CharacterJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}