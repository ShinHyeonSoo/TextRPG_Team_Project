namespace TextRPG_Team_Project
{
    public delegate void MonsterAttackHandler(int damage);

    public class Monster : IUnit
    {
        public event MonsterAttackHandler? OnAttack;

        private string? _name;
        private int _level;
        private int _health;
        private int _maxHealth;
        private int _attack;
        private int _defense;
        private bool _isDead;

        public string Name { get { return _name ?? "Unknown"; } private set { _name = value; } }
        public int Level { get => _level; private set => _level = value; }
        public int Health { get => _health; private set => _health = value; }
        public int MaxHealth { get => _maxHealth; }
        public int Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public bool IsDead { get => _isDead; private set => _isDead = value; }

        public void TakeDamage(int damage)
        {
            int error = (int)Math.Ceiling(damage * 0.1f); // 소수 첫번째 자리 올림

            Random random = new Random();
            int totalDamage = random.Next(damage - error, damage + error + 1);

            _health -= totalDamage;

            if (_health < 0)
            {
                _health = 0;
                _isDead = true;
            }
        }

        public void MonsterAttack(int damage)
        {
            OnAttack?.Invoke(damage);
        }

        public void Recovery()
        {
            if(_isDead)
            {
                _health = _maxHealth;
                _isDead = false;
            }
        }
    }
}
