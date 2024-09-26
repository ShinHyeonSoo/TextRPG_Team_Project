﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class InventoryScene : Scene
	{
		// 인벤토리를 받거나
		// 인벤토리의 함수들을 받기
		enum InventoryState
		{
			Start = 0,
			ManagingEuipment = 1,
			UseItem =2,
		}
		private InventoryState _state;

		public InventoryScene() { }

		public override void DisplayInitScene()
		{
			DisplayIntro("인벤토리");
			Console.WriteLine();
			Console.WriteLine("인벤토리 목록 출력");
			DisplayOption(new List<string>() { "장착 관리", "아이템 사용" });
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}
		public void DisplayManagingEuipment()
		{
			DisplayIntro("인벤토리");
			Console.WriteLine();
			Console.WriteLine("인벤토리 장비 목록 출력");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();

		}
		public void DisplayUsetItem()
		{
			DisplayIntro("인벤토리");
			Console.WriteLine();
			Console.WriteLine("인벤토리 사용아이템 목록 출력");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public override int PlayScene()
		{
			switch (_state)
			{
				case InventoryState.Start:
					DisplayInitScene();
					_state = (InventoryState)GameManager.GetNumberInput(0, 2);
					if(_state == InventoryState.Start) { return 0; }
					break;
				case InventoryState.ManagingEuipment:
					DisplayManagingEuipment();
					break;
				case InventoryState.UseItem:
					DisplayUsetItem();
					break;
			}
			return 0;
		}
	}
}
