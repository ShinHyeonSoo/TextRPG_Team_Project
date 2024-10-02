using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using TextRPG_Team_Project;
using TextRPG_Team_Project.Database;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;
using TextRPG_Team_Project.Scene;
using static System.Net.Mime.MediaTypeNames;
namespace TextRPG_Team_Project
{

    public class Character : IUnit
    {


        public string Name { get; private set; }
        public int Gold { get; set; }
        public int Level { get; private set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public float Attack { get; private set; }
        public int Defense { get; private set; }
        public bool IsDead { get; private set; }
        public int CurrentSkill { get; private set; } = -1;
        public int Mp { get; private set; }
        public int MaxMp { get; private set; }
        public int CurrentAttack { get; private set; }
        public string Job { get; protected set; }

        ItemDatabase itemDB = GameManager.Instance.Data.ItemDatabase;

        private int exp = 0;

        private int[] expTable = { 3, 35, 65, 100 };

        public List<Weapon> Weapons;
        public List<Armor> Armors;
        public List<Potion> Potions;
        public List<Skill> Skill;
        

        public Weapon currentWeapon;
        public Armor currentArmor;

        public Character(String _name, int _level, int _maxHealth, int _attack, int _defense, int _mp) // 캐릭터 생성시 초기값 설정
        {

            KeyValuePair<string, Weapon> defaultWeapon = itemDB.WeaponDict.ElementAt(0);
            KeyValuePair<string, Armor> defaultArmor = itemDB.ArmorDict.ElementAt(0);

            MaxMp = _mp;
            Mp = MaxMp;
            Name = _name;
            Level = _level;
            MaxHealth = _maxHealth;
            Health = MaxHealth;
            Attack = _attack;
            Defense = _defense;
            IsDead = false;

            Weapons = new List<Weapon>();
            Armors = new List<Armor>();
            Potions = new List<Potion>();
            currentWeapon = defaultWeapon.Value;
            currentArmor = defaultArmor.Value;

            Weapons.Add(defaultWeapon.Value);
            Armors.Add(defaultArmor.Value);

        }

        public void TakeDamage(float damage) // 피격받았을시 공격자의 공격력 - 자신의 방어력 만큼 피해를 입음
        {
            Random random = GameManager.Instance.Data.GetRandom();


            float errorMargin = (float)Math.Ceiling(damage * 0.1f);


            int intDamage = random.Next((int)(damage - errorMargin), (int)(damage + errorMargin + 1));


            int reducedDamage = Math.Max(0, intDamage - Defense);
            
            int dodge = random.Next(0, 10);
            if(dodge < 9)
            {
                Health -= reducedDamage;
            }
                
            if (Health <= 0)
            {
                Health = 0;
                IsDead = true;
                Console.WriteLine($"{Name} 이(가) 사망하였습니다.");
            }
         
        }

        public int GetRequireExp(int level)
        {

            if (level < expTable[level - 1])
            {

                return expTable[level - 1];

            }
            else
            {
                return expTable[expTable.Length - 1] + (level - expTable.Length) * 100;
            }
        }

        public string AddExp(int _exp) // 경험치 추가 매서드
        {
            int prevExp = exp;
            exp += _exp;
            int _prevLevel = Level;
            int requireExp = GetRequireExp(Level);
            int _prevRequireExp = requireExp;

            while (exp >= requireExp)
            {
                LevelUp();
                exp -= requireExp;
                requireExp = GetRequireExp(Level);

                return $"LV.{_prevLevel} {Name} -> LV.{Level} {Name}\n필요 경험치량 : {_prevRequireExp} -> {requireExp}";
            }


            return $"Exp.{prevExp} -> {exp}";
        }

        public string ManaRegen(int value)
        {
            int prevMana = Mp;
            Mp += value;
            if (Mp > MaxMp)
                Mp = MaxMp;
            return $"Mp {prevMana} -> {Mp}";
        }


        public void LevelUp() // 경험치 100초과시 레벨업 
        {
            Defense += 1;
            Attack += 1;
            Level += 1;
            GameManager.Instance.PlayerRecored.NotifyUserLevelUp();


        }

        public string GetStatus() // 유저의 status의 정보를 알려주는 함수
        {
            string weaponName = currentWeapon != null ? currentWeapon.Name : "장착되지 않음";
            string armorName = currentArmor != null ? currentArmor.Name : "장착되지 않음";

            return $"LV.{Level}\n{Name}  ({Job})\n공격력: {Attack}\n방어력: {Defense}\n체 력 : {Health}/{MaxHealth}\nGold : {Gold} G\n무기 : {weaponName}\n방어구 : {armorName}";

        }
        // Lv. 01      


        public string GetUserInfoShort()
        {
            return $"LV.{Level} {Name}  ({Job})\nHP {Health} / {MaxHealth}\nMP {Mp} / {MaxMp}\n";

        }


        public void EquipWeapon(Weapon _weapon)
        {
            if (currentWeapon != null)
            {
                Attack -= currentWeapon.WeaponAttack;
            }
            GameManager.Instance.PlayerRecored.NotifyUserEuipment(_weapon.Name);
            currentWeapon = _weapon;
            Attack += _weapon.WeaponAttack;
        }

        public void UnEquipWeapon()
        {
            Attack -= currentWeapon.WeaponAttack;
            currentWeapon = itemDB.WeaponDict["맨 주먹"];

        }

        public void EquipArmor(Armor _armor)
        {
            if (currentArmor != null)
            {
                Attack -= currentArmor.ArmorDefence;
            }

            GameManager.Instance.PlayerRecored.NotifyUserEuipment(_armor.Name);
            currentArmor = _armor;
            Defense += _armor.ArmorDefence;
        }

        public void UnEquipArmor()
        {

            Defense -= currentArmor.ArmorDefence;
            currentArmor = itemDB.ArmorDict["일반 옷"];



        }
       
        public bool IsCritical()
        {
            Random random = GameManager.Instance.Data.GetRandom();
            bool isCrit = false;
            int critChance = random.Next(0, 10);

            if(critChance > 5)
            {
                isCrit = true;
            }
            return isCrit;
        }

        public void AttackEnemy(Monster _target, bool isCrit)
        {
            Random random = GameManager.Instance.Data.GetRandom();
            
            

            int critMulti = 1;
            if(isCrit)
            {
                
                critMulti = 2;
            }

            float damage;

            if (CurrentSkill < 0)
            {
                damage = Attack * critMulti;
                CurrentAttack = (int)Math.Ceiling(damage);
            }

            else
            {
                damage = (Attack * Skill[CurrentSkill].DamageMulti) * critMulti;
                CurrentAttack = (int)Math.Ceiling(damage);
                           
            }
                   
               

            _target.TakeDamage(damage);
            

        }

        public void ManaReduced()
        {
            if(CurrentSkill >=0)
            {
                Mp -= Skill[CurrentSkill].ManaCost;
            }
        }

        public List<string> GetSkillInfo()
        {
            StringBuilder skillList = new StringBuilder();
            List<string> stringList = new List<string>();

            int index = 1; // 스킬 번호 초기화
            foreach (var skill in Skill)
            {
                skillList.Clear();
                skillList.AppendLine($"{index}. {skill.Name} - MP {skill.ManaCost}");
                skillList.AppendLine($"   {skill.Description}");

                stringList.Add(skillList.ToString());
                index++;
            }

            return stringList;

        }

        public int ManaChecker(int select)
        {
            if (Mp >= Skill[select - 1].ManaCost)
            {
                return select;

            }

            else
            {

                return 0;
            }


        }

        public int SetCurrentSkill(int input)
        {
            CurrentSkill = input - 1;

            return CurrentSkill;


        }

        public string GetCurrentSkillInfo()
        {

            return $"{Skill[CurrentSkill].Name}";

        }


        public void GetReward(Reward? reward)
        {
            if (reward != null)
                Gold += reward.Value.Gold;
            else { }

        }

        public void HealthRegen(int value)
        {
            if (IsDead)
            {
                Health += value;

                if(Health > MaxHealth)
                {
                    Health = MaxHealth;

                }

                if(Health > 0)
                {

                    IsDead = false;

                }
            }           


        }

        public void ResetCurrentSkill()
        {
            CurrentSkill = -1;

        }

      
        public PlayerSaveData Save()
        {
            PlayerSaveData save = new PlayerSaveData();
            save.Job = Job;
            save.Name = Name;   
            save.Level = Level;
            save.EXP = exp;
            save.MaxHealth=MaxHealth;
            save.Health=Health;
            save.Attack = Attack;
            save.Defense = Defense;
            save.Gold = Gold;
            save.WeaponSaves = Weapons;
            save.ArmorSaves = Armors;
            save.PostionSaves = SavePotions();
            save.currentWeapon = currentWeapon;
            save.currentArmor = currentArmor;
            Console.WriteLine(save.ToString());
            return save;
        }
        public List<PotionSaveData> SavePotions()
        {
            List<PotionSaveData> save = new List<PotionSaveData>();
            for (int i = 0; i < Potions.Count; i++) 
            {
                save.Add(new PotionSaveData(Potions[i].Name, Potions[i].ItemCount));
            }
            return save;
        }

		public void Load(PlayerSaveData data)
        {
            Job= data.Job;
            Name = data.Name;
            Level = data.Level;
            exp = data.EXP;
            MaxHealth = data.MaxHealth;
            Health = data.Health;
            Attack = data.Attack;
            Defense = data.Defense;
            Gold = data.Gold;
            Weapons = data.WeaponSaves;
			Armors = data.ArmorSaves;
            LoadPotions(data.PostionSaves);
            currentArmor = data.currentArmor;
            currentWeapon = data.currentWeapon;
        }
        public void LoadPotions(List<PotionSaveData> data)
        {
            Potions = new List<Potion>();
            ItemDatabase potionDB = GameManager.Instance.Data.ItemDatabase;
            for(int i = 0;i< data.Count; i++)
            {
                if (data[i].Name.Split(" ")[1] == "회복")
                {
                    HealthPotion hpPotion = new HealthPotion(
                        data[i].Name,
                        potionDB.PotionDict[data[i].Name].ItemPrice,
                        data[i].Count,
                        potionDB.PotionDict[data[i].Name].PotionEffect);
					Potions.Add(hpPotion);
                }
            }
		}

	}










}