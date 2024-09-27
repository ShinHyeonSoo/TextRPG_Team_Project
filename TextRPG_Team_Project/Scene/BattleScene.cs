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
			Start=0,
			PlayerTurn,
			SkillSelect,
			TargetSelect,
			EnermyTurn,

		}
		private BattleStatus _status;

		// 플레이어 할당받을 변수 필요
		// 던전등 배틀을 관리하는 매니저 필요

		event Func<string> StageEnemyInfo; // 해당 전투의 적들의 정보를 보여주는 함수를 할당해주세요 (매개변수 없음, 반환형 string)
		event Func<string> UserInfo;  // 유저의 정보를 간략하게 보여주는 함수를 할당해주세요 (매개변수 없음, 반환형 string)
		public BattleScene()
		{
            _battleManager = new();

            _status = BattleStatus.Start;
        }

		public override void DisplayInitScene()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("적들의 정보 출력\n");
            _battleManager.MonsterInfo(StageEnemyInfo);
            Console.WriteLine();
            Console.WriteLine("캐릭터의 간단한 정보 출력");

			DisplayOption(new List<string>() { "1. 공격", "2. 스킬" });
			DisplayGetInputNumber();
		}

		public void DisplayPlayerSkillSelect()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("적들의 정보 출력");
			Console.WriteLine();
			Console.WriteLine("캐릭터의 간단한 정보 출력");

			Console.WriteLine("캐릭터의 스킬 출력");
			Console.WriteLine("0. 취소");
			DisplayGetInputNumber();
		}
		public void DisplayPlayerTargetSelect()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("적들의 정보 출력");
			Console.WriteLine();
			Console.WriteLine("캐릭터의 간단한 정보 출력");
			Console.WriteLine("캐릭터의 선택된 행동에 대한 설명 출력");
			Console.WriteLine("0. 취소");
		}
		public void DisplayPlayerAttackLog()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("공격로그");
		}
		public void DisplayEnemyAttackLog()
		{
			DisplayIntro("Battle");
			Console.WriteLine();
			Console.WriteLine("공격로그");
		}

		public override void PlayScene()
		{
			switch (_status)
			{
				case BattleStatus.Start:
					DisplayInitScene();
					break;
				case BattleStatus.PlayerTurn:
					DisplayInitScene();
					break;
				case BattleStatus.SkillSelect:
					DisplayPlayerSkillSelect();
					break;
				case BattleStatus.TargetSelect:
					DisplayPlayerTargetSelect();
					break;
				case BattleStatus.EnermyTurn:
					DisplayEnemyAttackLog();
					break;
			}
		}
	}
}
