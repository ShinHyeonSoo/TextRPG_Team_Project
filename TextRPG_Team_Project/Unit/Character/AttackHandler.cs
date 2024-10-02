using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
    class AttackHandler
    {

        public void NormalAttack(Character player, int targetNum, List<Monster> monsters, bool isCrit)
        {
            Monster monster = monsters[targetNum - 1];
            int prevHp = monster.Health;
            player.AttackEnemy(monster,isCrit);


            StyleConsole.WriteLine($"{player.Name} 의 기본 공격!",ConsoleColor.Cyan);
            DisplayAttack(player, prevHp, monster, isCrit);

        }

        public void SkillAttack(Character player, int targetNum, List<Monster> monsters, bool isCrit)
        {
            int targetCount = player.Skill[player.CurrentSkill].GetSkillType() == 1 ? 1 : 2;
            Monster monster = monsters[targetNum - 1];
            Random random = GameManager.Instance.Data.GetRandom();
            HashSet<int> attackedTargets = new HashSet<int>();

            for (int i = 0; i < targetCount; i++)
            {

                if ((IsAlliveCount(monsters) <= 0))
                    break;


                if (targetCount > 1 && IsAlliveCount(monsters) > 1)
                    monster = null;

                int randomTarget = -1;

                // 유효한 타겟을 찾을 때까지 반복
                if (targetCount > 1)
                {
                    while (monster == null || attackedTargets.Contains(randomTarget) || monster.IsDead)
                    {

                        randomTarget = random.Next(0, monsters.Count);
                        monster = monsters[randomTarget];
                    }
                }

                attackedTargets.Add(randomTarget); // 타겟 중복 방지
                int prevHp = monster.Health; // 각 몬스터에 대한 이전 HP 기록
                player.AttackEnemy(monster,isCrit);
                StyleConsole.WriteLine($"\n{player.Name} 의 스킬 공격!" ,ConsoleColor.Cyan);
                DisplayAttack(player, prevHp, monster, isCrit);
            }
        }

        public void DisplayAttack(Character player, int prevHp, Monster monster, bool isCrit) // 로그처리
        {
            if (monster.Health != prevHp)
            {
                if (isCrit) 
                {
                    Console.WriteLine("Critical !!"); 
                }                   
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다. [데미지 : {player.CurrentAttack}]");

                if (monster.IsDead)
                { 
                    Console.WriteLine($"HP {prevHp} -> Dead"); 
                }

                else
                {
                    Console.WriteLine($"HP {prevHp} -> {monster.Health}");
                    
                }            
            }
            else
            {
                Console.WriteLine("몬스터가 열씸히 피했습니다");

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
