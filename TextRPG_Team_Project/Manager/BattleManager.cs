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

        AttackHandler attackHandler;
        private const int _MAX = 4;

        public List<Monster> Monsters { get { return _monsters; } private set { _monsters = value; } }

        public BattleManager()
        {
            attackHandler = new AttackHandler();

            _monsters = new();
            _monsterDB = new();

            //_monsterDB.Add(new Minion("미니언", 2, 1, 5, 1, 50));
            //_monsterDB.Add(new CannonMinion("대포미니언", 5, 1, 5, 3, 100));
            //_monsterDB.Add(new Voidling("공허충", 3, 1, 7, 0, 75));
            //_monsterDB.Add(new Golem("골렘", 7, 1, 10, 5, 150));
            _monsterDB.Add(new Minion("미니언", 2, 20, 10, 3, 50));
            _monsterDB.Add(new CannonMinion("대포미니언", 5, 35, 15, 5, 100));
            _monsterDB.Add(new Voidling("공허충", 3, 15, 20, 0, 75));
            _monsterDB.Add(new Golem("골렘", 7, 45, 30, 10, 150));
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
            bool isCrit = player.IsCritical();
            if(player.CurrentSkill == -1)
                attackHandler.NormalAttack(player, targetNum, _monsters,isCrit);
            else
                attackHandler.SkillAttack(player, targetNum, _monsters,isCrit);

            player.ManaReduced();
            player.ResetCurrentSkill();
           
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

  
    }
}
