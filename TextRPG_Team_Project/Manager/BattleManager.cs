using System.Security.Cryptography;
using System.Threading;

namespace TextRPG_Team_Project
{
    public class BattleManager
    {
        private List<Monster> _monsters;

        private Queue<Monster> _minions;
        private Queue<Monster> _cannonMinions;
        private Queue<Monster> _voidlings;

        private const int _MAX = 4;

        public List<Monster> Monsters { get { return _monsters; } private set { _monsters = value; } }

        public BattleManager()
        {
            _monsters = new();
            _minions = new();
            _cannonMinions = new();
            _voidlings = new();

            for (int i = 0; i < _MAX; ++i)
            {
                _minions.Enqueue(new Minion("미니언", 2, 15, 3, 1, 100));
                _cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 25, 2, 3, 100));
                _voidlings.Enqueue(new Voidling("공허충", 3, 10, 5, 0, 100));
            }
        }

        public void ShuffleMonster()
        {
            Random rand = DataManager.Instance().GetRandom();

            int randValue = rand.Next(1, _MAX + 1);

            for(int i = 0; i < randValue; ++i)
            {
                int randType = rand.Next(0, _MAX - 1);

                switch((MonsterType)randType)
                {
                    case MonsterType.MINION:
                        _monsters.Add(_minions.Dequeue());
                        break;
                    case MonsterType.CANNON_MINION:
                        _monsters.Add(_cannonMinions.Dequeue());
                        break;
                    case MonsterType.VOILDING:
                        _monsters.Add(_voidlings.Dequeue());
                        break;
                }
            }
        }

        public void CollectMonster()
        {
            foreach(var monster in _monsters)
            {
                monster.Recovery();

                switch (monster.Type)
                {  
                    case MonsterType.MINION:
                        _minions.Enqueue(monster);
                        break;
                    case MonsterType.CANNON_MINION:
                        _cannonMinions.Enqueue(monster);
                        break;
                    case MonsterType.VOILDING:
                        _voidlings.Enqueue(monster);
                        break;
                }
            }
            _monsters.Clear();
        }

        public void MonsterInfo(Func<string> callback)
        {
            if(_monsters.Count == 0)
                ShuffleMonster();

            int count = 0;
            foreach (var monster in _monsters)
            {
                ++count;

                if (!monster.IsDead)
                {
                    callback = monster.MonsterInfo;
                }
                else
                {
                    callback = monster.DeadInfo;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine("{0}  " + callback(), count);
                Console.ResetColor();
            }
        }

        public Monster TargetInfo(int num)
        {
            if (!_monsters[num - 1].IsDead)
            {
                return _monsters[num - 1];
            }
            else
            {
                throw new Exception("error");
            }
        }
    }
}
