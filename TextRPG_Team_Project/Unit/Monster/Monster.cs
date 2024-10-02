using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
    public delegate void MonsterAttackHandler(float damage);

    public enum MonsterType
    {
        MINION,
        CANNON_MINION,
        VOILDING,
        GOLEM,
    }

    public class Monster : IUnit, ICloneable
    {
        public event MonsterAttackHandler? OnAttack;

        protected string? _name;
        protected int _level;
        protected int _health;
        protected int _maxHealth;
        protected float _attack;
        protected int _defense;
        protected int _gold;
        protected bool _isDead;

        protected MonsterType _type;

        public string Name { get { return _name ?? "Unknown"; } private set { _name = value; } }
        public int Level { get => _level; private set => _level = value; }
        public int Health { get => _health; private set => _health = value; }
        public int MaxHealth { get => _maxHealth; }
        public float Attack { get => _attack; private set => _attack = value; }
        public int Defense { get => _defense; private set => _defense = value; }
        public int Gold { get => _gold; private set => _gold = value; }
        public bool IsDead { get => _isDead; private set => _isDead = value; }
        public MonsterType Type { get => _type; }

        public Monster(string name = "", int level = 1, int maxHealth = 1, float attack = 1, int defense = 1, int gold = 1)
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

        public virtual string DeadInfo()
        {
            return "Unknown Dead";
        }

        public virtual void LevelUp(int level)
        {
            
        }

        public void TakeDamage(float damage)
        {
            int error = (int)Math.Ceiling(damage * 0.1f); // 소수 첫번째 자리 올림

            Random rand = DataManager.Instance().GetRandom();
            int minRange = (int)damage - error;
            int maxRange = (int)damage + error + 1;
            int totalDamage = rand.Next(minRange, maxRange);

            int dodge = rand.Next(0, 10);
            
            if(dodge > 1)
                _health -= totalDamage;

            if (_health < 1)
            {
                _health = 0;
                GameManager.Instance.PlayerRecored.IncreseMonsterKillCount(_name);
                _isDead = true;
            }
        }

        public void BasicAttack(float damage)
        {
            OnAttack?.Invoke(damage);
        }

        public Monster Clone()
        {
            Monster newMonster = null;

            switch (this.Type)
            {
                case MonsterType.MINION:
                    newMonster = new Minion();
                    break;
                case MonsterType.CANNON_MINION:
                    newMonster = new CannonMinion();
                    break;
                case MonsterType.VOILDING:
                    newMonster = new Voidling();
                    break;
                case MonsterType.GOLEM:
                    newMonster = new Golem();
                    break;
            }
            
            newMonster._name = this.Name;
            newMonster._level = this.Level;
            newMonster._health = this._maxHealth;
            newMonster._maxHealth = this._maxHealth;
            newMonster._attack = this.Attack;
            newMonster._defense = this._defense;
            newMonster._gold = this.Gold;
            newMonster._type = this.Type;

            return newMonster;
        }
    }
}
