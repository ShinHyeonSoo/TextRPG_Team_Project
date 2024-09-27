using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG_Team_Project.Quest;

namespace TextRPG_Team_Project.Scene
{
	public class GameManager
	{
		enum GameStatus
		{
			Start = -1,
			Home = 0,
			Status = 1,
			Battle,
			Inventory,
			Quest,
			Save,

		}
		private GameStatus _status = GameStatus.Start;

		private QuestManger _questManager;
		private DataManager _dataManager;

		private StartScene _startScene;
		private HomeScene _homeScene;
		private StatusScene _statusScene;
		private BattleScene _battleScene;
		private InventoryScene _inventoryScene;
		private QuestScene _questScene;

		public GameManager()
		{
			_questManager = new QuestManger();
			_dataManager = DataManager.Instance();

            _startScene = new StartScene();
			_homeScene = new HomeScene();
			_statusScene = new StatusScene();
			_battleScene = new BattleScene();
			_inventoryScene = new InventoryScene();
			_questScene = new QuestScene(_questManager);
		}

		public void GameMain()
			/*
			 디버깅을 위한 임시 게임메인
			 */
		{
			while (true)
			{
				switch (_status)
				{
					case GameStatus.Start:	 // -1 
						_status = (GameStatus)_startScene.PlayScene();
						break;
					case GameStatus.Home:	 // 0
						_status = (GameStatus)_homeScene.PlayScene();
						break;
					case GameStatus.Status:  // 1
						_status = (GameStatus)_statusScene.PlayScene();
						break;
					case GameStatus.Battle:  // 2
						_status = (GameStatus)_battleScene.PlayScene();
						break;
					case GameStatus.Inventory:  // 3
						_status = (GameStatus)_inventoryScene.PlayScene();
						break;
					case GameStatus.Quest:  // 4
						_status = (GameStatus)_questScene.PlayScene();
						break;
					case GameStatus.Save:  // 5
						break;
				}
			}
		}
		public static int GetNumberInput(int min, int max)
			/*사용자의 숫자입력을 받는 함수
			 min : 입력가능한 최소값 (포함)
			 max : 입력가능한 최대값 (미포함)
			*/
		{
			string? input = "";
			int inputNumber = 0;
			
			while (true)
			{
				input = Console.ReadLine();
				if (int.TryParse(input, out inputNumber)) 
				{
					if (min <= inputNumber && inputNumber < max) { return inputNumber; }
					else { input = ""; }
				}
				input = "";
				Scene.WrongInput();
			}
		}
	}
}
