using System;
using System.Security.Cryptography;
using System.Threading;
using TextRPG_Team_Project.Scene;
using TextRPG_Team_Project.Item;
using System.ComponentModel.Design;

namespace TextRPG_Team_Project
{
    public enum RewardType
    {
        WEAPON,
        ARMOR,
        POTION,
        NONE
    }
    public class BattleManager
    {
        private List<Monster> _monsters;
        private List<Monster> _monsterDB;

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
            _monsterDB = new();
            _minions = new();
            _cannonMinions = new();
            _voidlings = new();
            _golems = new();

            //for (int i = 0; i < _MONSTERS; ++i)
            //{
            //    //_minions.Enqueue(new Minion("미니언", 2, 15, 3, 1, 100));
            //    //_cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 25, 2, 3, 100));
            //    //_voidlings.Enqueue(new Voidling("공허충", 3, 10, 5, 0, 100));
            //    //_golems.Enqueue(new Golem("골렘", 5, 30, 5, 5, 100));
            //    _minions.Enqueue(new Minion("미니언", 2, 1, 5, 1, 50));
            //    _cannonMinions.Enqueue(new CannonMinion("대포미니언", 5, 1, 5, 3, 100));
            //    _voidlings.Enqueue(new Voidling("공허충", 3, 1, 7, 0, 75));
            //    _golems.Enqueue(new Golem("골렘", 7, 1, 10, 5, 150));
            //}

            _monsterDB.Add(new Minion("미니언", 2, 1, 5, 1, 50));
            _monsterDB.Add(new CannonMinion("대포미니언", 5, 1, 5, 3, 100));
            _monsterDB.Add(new Voidling("공허충", 3, 1, 7, 0, 75));
            _monsterDB.Add(new Golem("골렘", 7, 1, 10, 5, 150));
        }

        public void ShuffleMonster()
        {
            Random rand = DataManager.Instance().GetRandom();

            int stageIdx = GameManager.Instance.Data.StageIndex;

            int randValue = rand.Next(stageIdx, _MAX + stageIdx);

            for (int i = 0; i < randValue; ++i)
            {
                int randType = 0;

                if (stageIdx < 3)
                    randType = rand.Next(0, (int)MonsterType.VOILDING + 1);
                else
                    randType = rand.Next(0, (int)MonsterType.GOLEM + 1);

                _monsters.Add(_monsterDB[randType].Clone());

                //switch ((MonsterType)randType)
                //{
                //    case MonsterType.MINION:
                //        _monsters.Add(_minions.Dequeue());
                //        break;
                //    case MonsterType.CANNON_MINION:
                //        _monsters.Add(_cannonMinions.Dequeue());
                //        break;
                //    case MonsterType.VOILDING:
                //        _monsters.Add(_voidlings.Dequeue());
                //        break;
                //    case MonsterType.GOLEM:
                //        _monsters.Add(_golems.Dequeue());
                //        break;
                //}

                MonsterLevelManagement();
            }
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
            //foreach (var monster in _monsters)
            //{
            //    monster.Recovery();

            //    switch (monster.Type)
            //    {
            //        case MonsterType.MINION:
            //            _minions.Enqueue(monster);
            //            break;
            //        case MonsterType.CANNON_MINION:
            //            _cannonMinions.Enqueue(monster);
            //            break;
            //        case MonsterType.VOILDING:
            //            _voidlings.Enqueue(monster);
            //            break;
            //        case MonsterType.GOLEM:
            //            _golems.Enqueue(monster);
            //            break;
            //    }
            //}
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
                bool isCrit = player.AttackEnemy(monster);
                Console.WriteLine($"{player.Name} 의 기본 공격!");

                if (prevHp != monster.Health)
                {
                    if (isCrit) { Console.WriteLine("크리티컬 발생! 2배의 추가피해가 들어갑니다\n"); }

                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player.CurrentAttack}]");
                    Console.WriteLine($"\nLv.{monster.Level} {monster.Name}");

                    if (monster.IsDead)
                        Console.WriteLine($"HP {prevHp} -> Dead");
                    else
                        Console.WriteLine($"HP {prevHp} -> {monster.Health}");
                }
                else
                {
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다...");
                }
            }
            else // 스킬 공격 처리
            {
                int targetCount = player.Skill[player.CurrentSkill].GetSkillType() == 1 ? 1 : 2;
                Monster monster = _monsters[targetNum - 1];
                for (int i = 0; i < targetCount; i++)
                {

                    if ((IsAlliveCount(_monsters) <= 0))
                        break;

                    if (targetCount > 1 && IsAlliveCount(_monsters) > 1)
                        monster = null;

                    int randomTarget = -1;

                    // 유효한 타겟을 찾을 때까지 반복
                    if (targetCount > 1)
                    {
                        while (monster == null || attackedTargets.Contains(randomTarget) || monster.IsDead)
                        {

                            randomTarget = random.Next(0, _monsters.Count);
                            monster = _monsters[randomTarget];
                        }
                    }

                    attackedTargets.Add(randomTarget); // 타겟 중복 방지
                    int prevHp = monster.Health; // 각 몬스터에 대한 이전 HP 기록
                    bool isCrit = player.AttackEnemy(monster);
                    Console.WriteLine($"{player.Name} 의 스킬 공격!");
                    if (isCrit) { Console.WriteLine("크리티컬 발생! 2배의 추가피해가 들어갑니다\n"); }
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
                if (prevHp != player.Health)
                {
                    Console.WriteLine($"\nLv.{player.Level} {player.Name}");
                    if (player.IsDead)
                        Console.WriteLine($"HP {prevHp} -> Dead");
                    else
                        Console.WriteLine($"HP {prevHp} -> {player.Health}");
                }
                else
                {
                    Console.WriteLine("플레이어의 회피 성공!");
                }
                monster.OnAttack -= player.TakeDamage;



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
            IItem rewardWeapon = null, rewardArmor = null, rewardPotion = null;

            int rand = GameManager.Instance.Data.GetRandom().Next(0, 3);
            string[] rewardStr = new string[(int)RewardType.NONE];

            RandomEquipReward(rewardStr);

            if (rand == 0)
            {
                rewardWeapon = GameManager.Instance.Data.ItemDatabase.WeaponDict[(rewardStr[(int)RewardType.WEAPON])];
            }
            else if (rand == 1)
            {
                rewardArmor = GameManager.Instance.Data.ItemDatabase.ArmorDict[(rewardStr[(int)RewardType.ARMOR])];
            }
            else
            {
                rewardWeapon = GameManager.Instance.Data.ItemDatabase.WeaponDict[(rewardStr[(int)RewardType.WEAPON])];
                rewardArmor = GameManager.Instance.Data.ItemDatabase.ArmorDict[(rewardStr[(int)RewardType.ARMOR])];
            }

            rewardPotion = GameManager.Instance.Data.ItemDatabase.PotionDict[(rewardStr[(int)RewardType.POTION])];

            rewardWeapon?.GetItem(player, rewardStr[(int)RewardType.WEAPON], 1);
            rewardArmor?.GetItem(player, rewardStr[(int)RewardType.ARMOR], 1);
            rewardPotion?.GetItem(player, rewardStr[(int)RewardType.POTION], GameManager.Instance.Data.StageIndex++);
        }

        public void RandomEquipReward(string[] itemName)
        {
            string job = GameManager.Instance.Data.GetPlayer().Job;
            int stageIdx = GameManager.Instance.Data.StageIndex;

            if (job == "전사")
            {
                if (1 <= stageIdx && stageIdx < 3)
                {
                    itemName[(int)RewardType.WEAPON] = "나무 검";
                    itemName[(int)RewardType.ARMOR] = "가죽 갑옷";
                    itemName[(int)RewardType.POTION] = "작은 회복 포션";
                }
                else if (3 <= stageIdx && stageIdx < 5)
                {
                    itemName[(int)RewardType.WEAPON] = "무쇠 검";
                    itemName[(int)RewardType.ARMOR] = "사슬 갑옷";
                    itemName[(int)RewardType.POTION] = "중간 회복 포션";
                }
                else
                {
                    itemName[(int)RewardType.WEAPON] = "강철 검";
                    itemName[(int)RewardType.ARMOR] = "판금 갑옷";
                    itemName[(int)RewardType.POTION] = "큰 회복 포션";
                }
            }
            else if (job == "마법사")
            {
                if (1 <= stageIdx && stageIdx < 3)
                {
                    itemName[(int)RewardType.WEAPON] = "나무 지팡이";
                    itemName[(int)RewardType.ARMOR] = "천 로브";
                    itemName[(int)RewardType.POTION] = "작은 회복 포션";
                }
                else if (3 <= stageIdx && stageIdx < 5)
                {
                    itemName[(int)RewardType.WEAPON] = "전투 지팡이";
                    itemName[(int)RewardType.ARMOR] = "견습 로브";
                    itemName[(int)RewardType.POTION] = "중간 회복 포션";
                }
                else
                {
                    itemName[(int)RewardType.WEAPON] = "마법 지팡이";
                    itemName[(int)RewardType.ARMOR] = "숙련 로브";
                    itemName[(int)RewardType.POTION] = "큰 회복 포션";
                }
            }
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
