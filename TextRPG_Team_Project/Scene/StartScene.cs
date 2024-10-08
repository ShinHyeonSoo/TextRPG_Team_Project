﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class StartScene : Scene
	{
		enum StartState
		{
			Start,
			SetCharacterName,
			SetCharacterJob,
		}
		public override void DisplayInitScene()
		{
			DisplayIntro();
			Console.WriteLine();
			Console.WriteLine("어서오세요!");
			Console.WriteLine("");
			DisplayOption(new List<string>() { "1. 새게임", "2. 불러오기" });
			Console.WriteLine();
			DisplayGetInputNumber();
		}
		public void DisplaySetCharacterName()
		{
			DisplayIntro("Text RPG"); // 게임 이름 뭐로할까용
			Console.WriteLine("캐릭터의 이름을 설정해주세요.");
			Console.WriteLine("");
			DisplayGetInputString("이름");
		}
		public void DisplaySetCharacterJob()
		{
			DisplayIntro("Text RPG"); // 게임 이름 뭐로할까용
			Console.WriteLine("캐릭터의 직업을 선택해주세요.");
			Console.WriteLine("");
			DisplayOption(new List<string>() { "1. 전사", "2. 마법사" });
			Console.WriteLine();
			DisplayGetInputNumber();
		}
		public override void PlayScene()
		{
			DisplayInitScene();
			if(Utils.GetNumberInput(1, 3) == 2)
			{
				GameManager.Instance.GoAnySScene(Defines.GameStatus.Load);
				return;
			}

			DisplaySetCharacterName();
			string characterName = Console.ReadLine();
			// 케릭터의 이름을 정하는  부분 추가 필요
			DisplaySetCharacterJob();
			int jobSelect = Utils.GetNumberInput(1, 3);
			// 케릭터의 직업을 정하는 부분 추가 필요
			GameManager.Instance.Data.CreatePlayer(characterName, jobSelect);		 //캐릭터 생성		
			GameManager.Instance.GoHomeScene();
		}
	}
}
