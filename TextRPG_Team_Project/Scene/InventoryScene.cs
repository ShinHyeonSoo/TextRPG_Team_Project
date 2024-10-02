using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Item;

namespace TextRPG_Team_Project.Scene
{
	public class InventoryScene : Scene
	{
		Shop shop;
		// 인벤토리를 받거나
		// 인벤토리의 함수들을 받기

		private Defines.InventoryState _state;

		public InventoryScene() { }

		public override void DisplayInitScene()
		{
			DisplayIntro("인벤토리");
			Console.WriteLine();
            Console.WriteLine("보유한 아이템을 확인하거나 상점에서 구매할 수 있습니다.");
            DisplayOption(new List<string>() { "1. 인벤토리", "2. 상점" });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
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

		public override void PlayScene()
		{

			int userInput = 0;
			switch (_state)
			{
				case Defines.InventoryState.Start:
                    if (shop == null)
                    {
                        shop = new Shop();
                    }
					shop.MainInventoryScene();
					userInput = 0;
					if(userInput == 0) { GameManager.Instance.GoHomeScene(); }

					break;
				case Defines.InventoryState.ManagingEuipment:
					DisplayManagingEuipment();
					break;
				case Defines.InventoryState.UseItem:
					DisplayUsetItem();
					break;
			}
		}
	}
}
