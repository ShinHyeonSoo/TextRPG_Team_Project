﻿namespace TextRPG_Team_Project
{
    public class CannonMinion : Monster
    {
        public CannonMinion(string name = "", int level = 1, int maxHealth = 1, float attack = 1, int defense = 1, int gold = 1) 
            : base(name, level, maxHealth, attack, defense, gold)
        {
            _type = MonsterType.CANNON_MINION;
        }

        public override string MonsterInfo()
        {
            string info = $"Lv.{Level} {Name}   HP {Health}";

            return info;
        }

        public override string DeadInfo()
        {
            string info = $"Lv.{Level} {Name}   Dead";

            return info;
        }

        public override void LevelUp(int level)
        {
            _level = 5 + (level - 1);
            _maxHealth = 1 + (level - 1) * 15;
            _health = _maxHealth;
            _attack = 5 + (level - 1) * 2;
            _defense = 3 + (level - 1) * 2;
            _gold = 100 + (level - 1) * 20;
        }
    }
}
