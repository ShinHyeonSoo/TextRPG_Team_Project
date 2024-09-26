namespace TextRPG_Team_Project
{
    public class CannonMinion : Monster
    {
        public CannonMinion(string name, int level, int maxHealth, float attack, int defense, int gold) 
            : base(name, level, maxHealth, attack, defense, gold)
        {

        }

        public override string MonsterInfo()
        {
            string info = $"Lv.{Level} {Name}   HP {Health}\n";

            return info;
        }
    }
}
