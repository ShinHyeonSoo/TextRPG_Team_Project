using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class BattleScene : Scene
	{
		// 논의 필요 
		private BattleManager _battleManager;

		enum BattleStatus
		{
			Start,
			TargetSelect,
			SkillSelect,
			PlayerTurn,
			EnermyTurn,
		}
		private BattleStatus _status;
		private int _depth;
		private int _targetNum;

		// 플레이어 할당받을 변수 필요
		// 던전등 배틀을 관리하는 매니저 필요

		event Func<string> StageEnemyInfo; // 해당 전투의 적들의 정보를 보여주는 함수를 할당해주세요 (매개변수 없음, 반환형 string)
		event Func<string> UserInfo;  // 유저의 정보를 간략하게 보여주는 함수를 할당해주세요 (매개변수 없음, 반환형 string)
		public BattleScene()
		{
            _battleManager = new();

            _status = BattleStatus.Start;
			_depth = 0;
			_targetNum = 0;
        }

		public override void DisplayInitScene()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
            _battleManager.MonsterInfo(StageEnemyInfo);
            Console.WriteLine();
            Console.WriteLine("[내 정보]");

            #region 플레이어 정보 임시
            Character temp = DataManager.Instance().GetPlayer();
            Console.WriteLine($"Lv.{temp.Level} {temp.Name} ({temp.Job})\nHP {temp.Health} / {temp.MaxHealth}");
            #endregion

            DisplayOption(new List<string>() { "1. 공격", "2. 스킬\n" });
			DisplayGetInputNumber();
		}

        public void DisplayPlayerSkillSelect()
		{
            ++_depth;

            DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("적들의 정보 출력");
			Console.WriteLine();
            Console.WriteLine("[내 정보]");

            #region 플레이어 정보 임시
            Character temp = DataManager.Instance().GetPlayer();
            Console.WriteLine($"Lv.{temp.Level} {temp.Name} ({temp.Job})\nHP {temp.Health} / {temp.MaxHealth}");
            #endregion

            Console.WriteLine("캐릭터의 스킬 출력");
			Console.WriteLine("0. 취소\n");
			DisplayGetInputNumber();
		}
		public int DisplayPlayerTargetSelect()
		{
			++_depth;

            DisplayIntro("Battle");
			Console.WriteLine(); 
			_battleManager.MonsterInfo(StageEnemyInfo);
            Console.WriteLine();
            Console.WriteLine("[내 정보]");

            #region 플레이어 정보 임시
            Character temp = DataManager.Instance().GetPlayer();
            Console.WriteLine($"Lv.{temp.Level} {temp.Name} ({temp.Job})\nHP {temp.Health} / {temp.MaxHealth}");
            #endregion

            Console.WriteLine("\n기본 공격!\n");
			DisplayGetInputString("대상");

			int maxValue = _battleManager.Monsters.Count + 1;
			int input = Utils.GetNumberInput(0, maxValue);
			_targetNum = input;

			if (input == 0)
				_status = (BattleStatus)input;
			else
				_status = BattleStatus.PlayerTurn;

            return input;
        }
		public void DisplayPlayerAttackLog()
		{
            ++_depth;

            DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("[플레이어 공격로그]\n");
			
			Character player = DataManager.Instance().GetPlayer();
			Monster monster = _battleManager.TargetInfo(_targetNum);
            player.AttackEnemy(monster);

            Console.WriteLine($"{player.Name} 가 {monster.Name} 에게 일반 공격!");

			// TODO : 사망처리

            _status = BattleStatus.EnermyTurn;
            Thread.Sleep(1500);
		}
		public void DisplayEnemyAttackLog()
		{
            ++_depth;

            DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("[몬스터 공격로그]\n");

            Character player = DataManager.Instance().GetPlayer();
            Monster monster = _battleManager.TargetInfo(_targetNum);
			monster.OnAttack += player.TakeDamage;

            Console.WriteLine($"\n{monster.Name} 가 {player.Name} 에게 공격!");

            monster.BasicAttack(monster.Attack);
            monster.OnAttack -= player.TakeDamage;

            // TODO : 사망처리

            _status = BattleStatus.Start;
            Thread.Sleep(1500);

			--_depth;
        }

		public override void PlayScene()
		{
			int input = -1;

            switch (_status)
			{
                case BattleStatus.Start:
					DisplayInitScene();
                    input = Utils.GetNumberInput(0, 2);
                    break;
				case BattleStatus.TargetSelect:
                    input = DisplayPlayerTargetSelect();
                    break;
				case BattleStatus.SkillSelect:
					DisplayPlayerSkillSelect();
					break;
				case BattleStatus.PlayerTurn:
                    DisplayPlayerAttackLog();
                    break;
				case BattleStatus.EnermyTurn:
					DisplayEnemyAttackLog();
					break;
			}

			if(_depth == 0)
			{
				switch(input)
				{
					case 0:
                        _battleManager.CollectMonster();
                        GameManager.Instance.GoHomeScene();
                        break;
                    case 1:
						_status = BattleStatus.TargetSelect;
                        break;
                    case 2:
						_status = BattleStatus.SkillSelect;
                        break;
                }
				return;
            }

			--_depth;
        }
	}
}
