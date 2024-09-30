using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
			Victory,
		}
		private BattleStatus _status;
		private int _depth;
		private int _targetNum;
        private int _prevPlayerHealth;
        private int _monstersCount;

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
            Character player = GameManager.Instance.Data.GetPlayer();
            UserInfo += player.GetUserInfoShort;
            DisplayIntro("Battle");
			Console.WriteLine();
            _battleManager.MonsterInfo(StageEnemyInfo);
            Console.WriteLine();
            Console.WriteLine(UserInfo?.Invoke());// 캐릭터의 간단한 정보 출력

            _prevPlayerHealth = player.Health;
            _monstersCount = _battleManager.Monsters.Count;

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
			Console.WriteLine(UserInfo?.Invoke());// 캐릭터의 간단한 정보 출력

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
            Console.WriteLine(UserInfo?.Invoke()); // 캐릭터의 간단한 정보 출력

            Console.WriteLine("\n기본 공격!\n");
			DisplayGetInputString("대상");

			int maxValue = _battleManager.Monsters.Count + 1;
			int input = Utils.GetNumberInput(0, maxValue);
			_targetNum = input;

			if (input == 0)
			{
				_status = (BattleStatus)input;
			}
			else
			{
                if (_battleManager.Monsters[_targetNum - 1].IsDead)
                {
                    _status = BattleStatus.TargetSelect;
                    Console.WriteLine("\n사망한 몬스터는 선택할 수 없습니다...");
                    Thread.Sleep(1000);
                    return input;
                }
                _status = BattleStatus.PlayerTurn;
			}

            return input;
        }

		public void DisplayPlayerAttackLog()
		{
            ++_depth;

            DisplayIntro("Battle");
			Console.WriteLine();

            _battleManager.AttacktoMonster(_targetNum);
			
            if(!_battleManager.CheckAliveMonsters())
            {
                _status = BattleStatus.Victory;
                return;
            }

            _status = BattleStatus.EnermyTurn;
        }
		public void DisplayEnemyAttackLog()
		{
            ++_depth;

            DisplayIntro("Battle");
			Console.WriteLine();

            _battleManager.AttacktoPlayer(_targetNum);

            // TODO : 플레이어 사망처리
            

            _status = BattleStatus.Start;

			--_depth;
        }

        public void DisplayVictoryLog()
        {
            ++_depth;

            DisplayIntro("Battle");

            Console.WriteLine("[Result]\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Victory\n");
            Console.ResetColor();

            Console.WriteLine($"던전에서 몬스터 {_monstersCount} 마리를 잡았습니다.");

            Character player = GameManager.Instance.Data.GetPlayer();
            Console.WriteLine($"\nLv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {_prevPlayerHealth} -> {player.Health}");

            _battleManager.GetReward();

            Console.WriteLine("\n0. 다음");

            Utils.GetNumberInput(0, 1);

            _battleManager.CollectMonster();
            GameManager.Instance.GoHomeScene();
            _status = BattleStatus.Start;

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
                case BattleStatus.Victory:
                    DisplayVictoryLog();
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
