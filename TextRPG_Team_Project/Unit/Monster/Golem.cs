namespace TextRPG_Team_Project
{
    public class Golem : Monster
    {
        public Golem(string name, int level, int maxHealth, float attack, int defense, int gold)
            : base(name, level, maxHealth, attack, defense, gold)
        {
            _type = MonsterType.GOLEM;
        }

        public override string MonsterInfo()
        {
            string info = $"Lv.{Level} {Name}         HP {Health}";

            return info;
        }

        public override string DeadInfo()
        {
            string info = $"Lv.{Level} {Name}   Dead";

            return info;
        }

        public override void LevelUp(int level)
        {
            _level = 7 + (level - 1);
            _maxHealth = 1 + (level - 1) * 20;
            _health = _maxHealth;
            _attack = 10 + (level - 1) * 5;
            _defense = 5 + (level - 1) * 5;
            _gold = 150 + (level - 1) * 30;
        }
    }
}
