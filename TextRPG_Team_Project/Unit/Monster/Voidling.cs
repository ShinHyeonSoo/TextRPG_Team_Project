﻿namespace TextRPG_Team_Project
{
    public class Voidling : Monster
    {
        public Voidling(string name = "", int level = 1, int maxHealth = 1, float attack = 1, int defense = 1, int gold = 1)
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
            _level += (level - 1);
            _maxHealth += (level - 1) * 5;
            _health = _maxHealth;
            _attack += (level - 1) * 3;
            _defense += (level - 1) * 1;
            _gold += (level - 1) * 15;
        }
    }
}
