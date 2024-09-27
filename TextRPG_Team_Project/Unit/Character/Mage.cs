using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
    public class Mage : Character // 마법사 클래스
    {
        public Mage(String _name, int _level, int _health, int _attack, int _defense) : base(_name, _level, _health, _attack, _defense)
        {



        }

        public void Skill1(Monster _target)
        {
            float damage = Attack + 20;
            Console.WriteLine($"{Name}가 추가될 스킬을 사용하여 {_target.Name}에게 {damage}의 데미지를 주었습니다.");
            _target.TakeDamage(damage);

        }
        public void Skill2(Monster _target)
        {
            float damage = Attack + 20;
            Console.WriteLine($"{Name}가 추가될 스킬을 사용하여 {_target.Name}에게 {damage}의 데미지를 주었습니다.");
            _target.TakeDamage(damage);

        }



    }
}
