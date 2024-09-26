namespace TextRPG_Team_Project
{
    public class Monster : IUnit
    {
        private string? _name;
        private int _level;
        private int _health;
        private int _attack;
        private int _defense;
        private bool _isDead;

        public string Name { get { return _name ?? "Unknown"; } private set { _name = value; } }
        public int Level { get => _level; private set => _level = value; }
        public int Health { get => _health; private set => _health = value; }
        public int Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public bool IsDead { get => _isDead; private set => _isDead = value; }

        public void TakeDamage(int damage)
        {

        }
    }
}
