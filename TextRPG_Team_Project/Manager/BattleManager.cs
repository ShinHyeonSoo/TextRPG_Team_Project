using System;
using System.Security.Cryptography;
using System.Threading;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
    public class BattleManager
    {
        private List<Monster> _monsters;

        private Queue<Monster> _minions;
        private Queue<Monster> _cannonMinions;
        private Queue<Monster> _voidlings;
        private Queue<Monster> _golems;

        private const int _MAX = 4;
        private const int _MONSTERS = 10;

        public List<Monster> Monsters { get { return _monsters; } private set { _monsters = value; } }

        public BattleManager()
        {
            _monsters = new();
            _minions = new();
            _cannonMinions = new();
            _voidlings = new();
            _golems = new();

            for (int i = 0; i < _MONSTERS; ++i)
            {
                //_minions.Enqueue(new Minion("미니언", 2, 15, 3, 1, 100));
                //_cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 25, 2, 3, 100));
                //_voidlings.Enqueue(new Voidling("공허충", 3, 10, 5, 0, 100));
                //_golems.Enqueue(new Golem("골렘", 5, 30, 5, 5, 100));
                _minions.Enqueue(new Minion("미니언", 2, 1, 5, 1, 50));
                _cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 1, 5, 3, 100));
                _voidlings.Enqueue(new Voidling("공허충", 3, 1, 7, 0, 75));
                _golems.Enqueue(new Golem("골렘", 7, 1, 10, 5, 150));
            }
        }

        public void ShuffleMonster()
        {
            Random rand = DataManager.Instance().GetRandom();
            int stageIdx = GameManager.Instance.Data.StageIndex;

            int randValue = rand.Next(stageIdx, _MAX + stageIdx);

            for(int i = 0; i < randValue; ++i)
            {
                int randType = 0;

                if (stageIdx < 3)
                    randType = rand.Next(0, (int)MonsterType.VOILDING + 1);
                else
                    randType = rand.Next(0, (int)MonsterType.GOLEM + 1);
                
                switch ((MonsterType)randType)
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
                    case MonsterType.GOLEM:
                        _monsters.Add(_golems.Dequeue());
                        break;
                }
            }

            MonsterLevelManagement();
        }

        public void MonsterLevelManagement()
        {
            foreach (var monster in _monsters)
            {
                monster.LevelUp(GameManager.Instance.Data.StageIndex);
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
                    case MonsterType.GOLEM:
                        _golems.Enqueue(monster);
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

        public void AttacktoMonster(int targetNum)
        {
            Character player = GameManager.Instance.Data.GetPlayer();
            Monster monster = _monsters[targetNum - 1];
            int prevHp = monster.Health;
            player.AttackEnemy(monster);

            Console.WriteLine($"{player.Name} 의 공격!");
            Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player.CurrentAttack}]");

            Console.WriteLine($"\nLv.{monster.Level} {monster.Name}");
            if (monster.IsDead)
                Console.WriteLine($"HP {prevHp} -> Dead");
            else
                Console.WriteLine($"HP {prevHp} -> {monster.Health}");

            Console.WriteLine("\n0. 다음");
            Utils.GetNumberInput(0, 1);
        }

        public void AttacktoPlayer(int targetNum)
        {
            Character player = GameManager.Instance.Data.GetPlayer();

            foreach (var monster in _monsters)
            {
                if (monster.IsDead)
                    continue;

                if (player.IsDead)
                    break;

                Console.Clear();
                Console.WriteLine("[name]\n");

                int prevHp = player.Health;

                monster.OnAttack += player.TakeDamage;

                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
                //Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monster.Attack}]");

                monster.BasicAttack(monster.Attack);
                monster.OnAttack -= player.TakeDamage;

                Console.WriteLine($"\nLv.{player.Level} {player.Name}");
                if (player.IsDead)
                    Console.WriteLine($"HP {prevHp} -> Dead");
                else
                    Console.WriteLine($"HP {prevHp} -> {player.Health}");

                Console.WriteLine("\n0. 다음");
                Utils.GetNumberInput(0, 1);
            }
        }

        public bool CheckAliveMonsters()
        {
            int count = 0;

            foreach (var monster in _monsters)
            {
                if (!monster.IsDead)
                    count++;
            }

            if (count != 0)
                return true;
            else
                return false;
        }

        public void GetReward()
        {
            int gold = 0;

            foreach (var monster in _monsters)
            {
                gold += monster.Gold;
            }

            Character player = GameManager.Instance.Data.GetPlayer();
            player.Gold += gold;

            Console.WriteLine("\n[획득 아이템]");
            Console.WriteLine($"{gold} Gold");
            //Console.WriteLine();   // 장비 or 포션 아이템 습득 추가
            //Console.WriteLine();   // 장비 or 포션 아이템 습득 추가
        }
    }
}
