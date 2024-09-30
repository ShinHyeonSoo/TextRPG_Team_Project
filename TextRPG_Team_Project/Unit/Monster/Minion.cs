namespace TextRPG_Team_Project
{
    public class Minion : Monster
    {
        public Minion(string name, int level, int maxHealth, float attack, int defense, int gold) 
            : base(name, level, maxHealth, attack, defense, gold)
        {
            _type = MonsterType.MINION;
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
            _level = 2 + (level - 1);
            _maxHealth = 1 + (level - 1) * 10;
            _health = _maxHealth;
            _attack = 5 + (level - 1) * 1;
            _defense = 1 + (level - 1) * 1;
            _gold = 50 + (level - 1) * 10;
        }
    }
}
