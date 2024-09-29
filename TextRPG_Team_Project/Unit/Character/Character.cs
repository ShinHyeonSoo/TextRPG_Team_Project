using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TextRPG_Team_Project;
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

        public int CurrentSkill { get; private set; } = 0;

        public int Mp { get; private set;}
        public int MaxMp { get; private set; }

        public int CurrentAttack { get; private set; }
        
        public string Job { get; protected set; }

        private int exp = 0;

        public List<Weapon> Weapon;
        public List<Armor> armor;
        public List<Potion> potion;
        public List<Skill> Skill;

        public Weapon currentWeapon;
        public Armor currentArmor;

        public Character(String _name , int _level, int _maxHealth , int _attack , int _defense , int _mp) // 캐릭터 생성시 초기값 설정
        {
            MaxMp = _mp;
            Mp = MaxMp;
            Name = _name;
            Level = _level;
            MaxHealth = _maxHealth;
            Health = MaxHealth;
            Attack = _attack;
            Defense = _defense;
            IsDead = false;

            Weapon = new List<Weapon>();
            armor = new List<Armor>();  
            potion = new List<Potion>();    
           
            
        }

        public void TakeDamage(float damage) // 피격받았을시 공격자의 공격력 - 자신의 방어력 만큼 피해를 입음
        {
            Random random = GameManager.Instance.Data.GetRandom();

            
            float errorMargin = (float)Math.Ceiling(damage * 0.1f);


            int intDamage = random.Next((int)(damage - errorMargin), (int)(damage + errorMargin+1));

            
            int reducedDamage = Math.Max(0, intDamage - Defense);
            Health -= reducedDamage;

            if (Health <= 0) 
            {
                Health = 0;
                IsDead = true;
                Console.WriteLine($"{Name} 이(가) 사망하였습니다.");
            }
            else
            {
                Console.WriteLine($"{reducedDamage} 의 피해를 입었습니다! {Name}의 남은 체력: {Health}");
            }
        }


        public void AddExp(int _exp) // 경험치 추가 매서드
        {
            exp += _exp;

            if(exp > 100) // 경험치가 100초과시 레벨업 매서드 호출
            {
                LevelUp();
                exp -= 100; // 100의 경험치 제거

            }
            

        }


        public void LevelUp() // 경험치 100초과시 레벨업 
        {
            MaxHealth += 10;
            Attack += 10;
            Level += 1;
            GameManager.Instance.PlayerRecored.NotifyUserLevelUp();
            Console.WriteLine($"Level Up !! / 최대 체력 : +10 증가하여 {MaxHealth} , 공격력 : + 10 증가하여 {Attack} , 레벨 : +1 증가하여 {Level}");
            
        }

        public string GetStatus() // 유저의 status의 정보를 알려주는 함수
        {
            string weaponName = currentWeapon != null ? currentWeapon.Name : "장착되지 않음";
            string armorName = currentArmor != null ? currentArmor.Name : "장착되지 않음";

            return $"LV.{Level}\n{Name}  ({Job})\n공격력: {Attack}\n방어력: {Defense}\n체 력 : {Health}/{MaxHealth}\nGold : {Gold} G\n무기{weaponName}\n방어구{armorName}";

        }
        // Lv. 01      


        public string GetUserInfoShort()
        {
            return $"LV.{Level} {Name}  ({Job})\nHP {MaxHealth}/{Health}\nMP {MaxMp}/{Mp}";

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
    
        public void EquipArmor(Armor _armor)
        {
            if(currentArmor != null)
            {
                Attack -= currentArmor.ArmorDefence;
            }
			GameManager.Instance.PlayerRecored.NotifyUserEuipment(_armor.Name);
			currentArmor = _armor;
            Defense += _armor.ArmorDefence;
        }

        public virtual void AttackEnemy(Monster _target)
        {

            float damage;

            if (CurrentSkill < 0)
            {
                damage = Attack;
                CurrentAttack = (int)Math.Ceiling(damage);
            }

            else
            {
                damage = Attack * Skill[CurrentSkill].DamageMulti;
                CurrentAttack = (int)Math.Ceiling(damage);
                Mp -= Skill[CurrentSkill].ManaCost;
                CurrentSkill = 0;
            }

            _target.TakeDamage(damage);
            

        }
        
        public string GetSkillInfo()
        {
            StringBuilder skillList = new StringBuilder(); 

            int index = 1; // 스킬 번호 초기화
            foreach (var skill in Skill)
            {
                skillList.AppendLine($"{index}. {skill.Name} - MP {skill.ManaCost}"); 
                skillList.AppendLine($"   {skill.Description}"); 
                index++; 
            }

            return skillList.ToString();

        }

        public int ManaChecker(int select)
        {
            if (Mp >= Skill[select-1].ManaCost)
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
            CurrentSkill = input-1;
            
            return CurrentSkill;
            

        }

        public string GetCurrentSkillInfo()
        {

            return $"{Skill[CurrentSkill].Name}";

        }

        




    }


   
  

   
    



}