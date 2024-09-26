namespace TextRPG_Team_Project
{
    public delegate void MonsterAttackHandler(float damage);

    public class Monster : IUnit
    {
        public event MonsterAttackHandler? OnAttack;

        private string? _name;
        private int _level;
        private int _health;
        private int _maxHealth;
        private float _attack;
        private int _defense;
        private int _gold;
        private bool _isDead;

        public string Name { get { return _name ?? "Unknown"; } private set { _name = value; } }
        public int Level { get => _level; private set => _level = value; }
        public int Health { get => _health; private set => _health = value; }
        public int MaxHealth { get => _maxHealth; }
        public float Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public int Gold { get => _gold; private set => _gold = value; }
        public bool IsDead { get => _isDead; private set => _isDead = value; }

        public Monster(string name, int level, int maxHealth, float attack, int defense, int gold)
        {
            Name = name;
            Level = level;
            Health = maxHealth;
            _maxHealth = maxHealth;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            _isDead = false;
        }

        public virtual string MonsterInfo()
        {
            return "Unknown";
        }

        public void TakeDamage(float damage)
        {
            int error = (int)Math.Ceiling(damage * 0.1f); // 소수 첫번째 자리 올림

            Random random = new Random();
            int minRange = (int)damage - error;
            int maxRange = (int)damage + error + 1;
            int totalDamage = random.Next(minRange, maxRange);

            _health -= totalDamage;

            if (_health < 0)
            {
                _health = 0;
                _isDead = true;
            }
        }

        public void MonsterAttack(float damage)
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
