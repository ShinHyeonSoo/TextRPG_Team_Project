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
                //_minions.Enqueue(new Minion("미니언", 2, 15, 3, 1, 100));
                //_cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 25, 2, 3, 100));
                //_voidlings.Enqueue(new Voidling("공허충", 3, 10, 5, 0, 100));
                _minions.Enqueue(new Minion("미니언", 2, 30, 1, 1, 100));
                _cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 30, 1, 3, 100));
                _voidlings.Enqueue(new Voidling("공허충", 3, 30, 5, 0, 100));
            }
        }

        public void ShuffleMonster()
        {
            Random rand = DataManager.Instance().GetRandom();

            int randValue = rand.Next(1, _MAX + 1);

            for (int i = 0; i < randValue; ++i)
            {
                int randType = rand.Next(0, _MAX - 1);

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
                }
            }
        }

        public void CollectMonster()
        {
            foreach (var monster in _monsters)
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
            if (_monsters.Count == 0)
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
            Random random = GameManager.Instance.Data.GetRandom();
            HashSet<int> attackedTargets = new HashSet<int>(); // 이미 공격한 몬스터를 저장

            if (player.CurrentSkill == -1) // 기본 공격 처리
            {
                Monster monster = _monsters[targetNum - 1];
                int prevHp = monster.Health; // 이전 HP 기록
                player.AttackEnemy(monster);
                Console.WriteLine($"{player.Name} 의 기본 공격!");
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player.CurrentAttack}]");
                Console.WriteLine($"\nLv.{monster.Level} {monster.Name}")
                    ;
                if (monster.IsDead)
                    Console.WriteLine($"HP {prevHp} -> Dead");
                else
                    Console.WriteLine($"HP {prevHp} -> {monster.Health}");
            }
            else // 스킬 공격 처리
            {
                int targetCount = player.Skill[player.CurrentSkill].GetSkillType() == 1 ? 1 : 2;

                for (int i = 0; i < targetCount; i++)
                {

                    if (IsAlliveCount(_monsters) <= 1 && i == 1) // 배열을 순회하며 살아남은 몬스터의 수를 받아옴 (무한루프 방지)
                    {
                        break;
                    }

                    Monster monster = null;
                    int randomTarget = -1;

                    // 유효한 타겟을 찾을 때까지 반복              
                        while (monster == null || attackedTargets.Contains(randomTarget) || monster.IsDead)
                        {
                            randomTarget = random.Next(0, _monsters.Count);
                            monster = _monsters[randomTarget];
                        }
                   

                    attackedTargets.Add(randomTarget); // 타겟 중복 방지
                    int prevHp = monster.Health; // 각 몬스터에 대한 이전 HP 기록
                    player.AttackEnemy(monster);
                    Console.WriteLine($"{player.Name} 의 스킬 공격!");
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player.CurrentAttack}]");
                    Console.WriteLine($"\nLv.{monster.Level} {monster.Name}");

                    if (monster.IsDead)
                        Console.WriteLine($"HP {prevHp} -> Dead");
                    else
                        Console.WriteLine($"HP {prevHp} -> {monster.Health}");


                 
                    Thread.Sleep(1000);
                }
                player.ManaReduced();
                player.ResetCurrentSkill();
            }




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

        public int IsAlliveCount(List<Monster> monsters)
        {
            int isAlliveCount = 0;
            foreach (var i in monsters)
            {
                if (!i.IsDead)
                {
                    isAlliveCount += 1;
                }


            }
            return isAlliveCount;
        }
    }
}
