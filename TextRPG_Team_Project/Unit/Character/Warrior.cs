using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TextRPG_Team_Project
{
    public class Warrior : Character // 워리어 클래스
    {
        

        public Warrior(String _name, int _level, int _health, int _attack, int _defense , int _mp) : base(_name, _level, _health, _attack, _defense , _mp) // 전사 생성시 초기값 설정
        {
            Job = "전사";
            
            Skill = new List<Skill>
            {
                new Skill ("알파 스트라이크", 2, "공격력 * 2 로 하나의 적을 공격합니다.", 20 , 1),
                new Skill ("더블 스트라이크", 1.5f, "공격력 * 1.5 로 두명의 적을 공격합니다", 10 ,2)

            };


        }

  


    }
}
