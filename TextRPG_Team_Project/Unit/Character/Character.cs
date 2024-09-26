using System;
using System.Net.Security;
using TextRPG_Team_Project;
namespace TextRPG_Team_Project
{

    public class Character : IUnit
    {

        public string Name { get; }

       
        public int Level { get; private set; }

       
        public int Health { get; private set; }

       
        public int Attack { get; private set; }
        public int Defense { get; }

       
        public bool IsDead { get; private set; }

        private int exp = 0;      



        public Character(String _name , int _level, int _health , int _attack , int _defense) // 캐릭터 생성시 초기값 설정
        {

            Name = _name;
            Level = _level;
            Health = _health;
            Attack = _attack;
            Defense = _defense;
            IsDead = false;




        }
        public void TakeDamage(int damage) // 피격받았을시 공격자의 공격력 - 자신의 방어력 만큼 피해를 입음
        {
            int reducedDamage = damage - Defense;
            Health -= reducedDamage;
            if ( Health <= 0)
            {
                IsDead = true;

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

        

    



    }

   
  

   
    



}