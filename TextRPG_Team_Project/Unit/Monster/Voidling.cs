namespace TextRPG_Team_Project
{
    public class Voidling : Monster
    {
        public Voidling(string name, int level, int maxHealth, float attack, int defense, int gold)
            : base(name, level, maxHealth, attack, defense, gold)
        {
            _type = MonsterType.VOILDING;
        }

        public override string MonsterInfo()
        {
            string info = $"Lv.{Level} {Name}       HP {Health}";

            return info;
        }

        public override string DeadInfo()
        {
            string info = $"Lv.{Level} {Name}       Dead";

            return info;
        }

        public override void LevelUp(int level)
        {
            _level = 3 + (level - 1);
            _maxHealth = 1 + (level - 1) * 5;
            _health = _maxHealth;
            _attack = 7 + (level - 1) * 3;
            _defense = 0 + (level - 1) * 1;
            _gold = 75 + (level - 1) * 15;
        }
    }
}
