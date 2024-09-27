using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using TextRPG_Team_Project;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;
namespace TextRPG_Team_Project
{

    public class Character : IUnit
    {


        public string Name { get; private set; }
        public int Gold { get; }
        public int Level { get; private set; }
        public int MaxHealth { get; }
        public int Health { get; private set; }      
        public float Attack { get; private set; }
        public int Defense { get; private set; }     
        public bool IsDead { get; private set; }

        private int exp = 0;

        public List<Weapon> Weapon;
        public List<Armor> armor;
        public List<Potion> potion;

        public Weapon currentWeapon;
        public Armor currentArmor;

        public Character(String _name , int _level, int _health , int _attack , int _defense) // 캐릭터 생성시 초기값 설정
        {

            Name = _name;
            Level = _level;
            Health = _health;
            Attack = _attack;
            Defense = _defense;
            IsDead = false;
            
            
        }

        public void TakeDamage(float damage) // 피격받았을시 공격자의 공격력 - 자신의 방어력 만큼 피해를 입음 , 정수면 그대로계산 , 소수면 올림후 계산
        {
            Random random = new Random();
            int intDamage;

            if(damage % 1 == 0)
            {
                intDamage = (int)damage;
            }

            else
            {
                intDamage = (int)damage + 1;
            }

            intDamage = random.Next((int)(intDamage * 0.9), intDamage + 1);

            int reducedDamage = intDamage - Defense;

            if (reducedDamage < 0) reducedDamage = 0;

            Health -= reducedDamage;

            if (Health <= 0) // 사망판정
            {
                IsDead = true;

                Console.WriteLine($"{Name} 이(가) 사망하였습니다.");
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
            Health += 10;
            Attack += 10;
            Level += 1;

            
        }

        public string GetStatus()
        {

            return $"이름: {Name}, 레벨: {Level}, 체력: {Health}, 공격력: {Attack}, 방어력: {Defense}, 무기{currentWeapon.Name}, 방어구{currentArmor.Name}";

        }

     
        public void EquipWeapon(Weapon _weapon)
        {

            currentWeapon = _weapon;
            Attack += _weapon.WeaponAttack;

        }
    
        public void EquipArmor(Armor _armor)
        {
            currentArmor = _armor;
            Defense += _armor.ArmorDefence;
        }

        public void AttackEnemy(Monster _target)
        {
            float damage = Attack;

            _target.TakeDamage(damage);

        }

    }

   
  

   
    



}