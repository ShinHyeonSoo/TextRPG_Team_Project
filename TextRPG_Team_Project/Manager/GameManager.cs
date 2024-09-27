using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG_Team_Project.Quest;

namespace TextRPG_Team_Project.Scene
{
	public class GameManager
	{



		private Defines.GameStatus _status = Defines.GameStatus.Start;

		#region Mangers
		private static GameManager _instance;

		private QuestManger _questManager = new QuestManger();
		private DataManager _dataManager = new DataManager();
		private PlayerRecordManager _playerRecordManager = new PlayerRecordManager();

		public static GameManager Instance { get { return _instance; } }

		
		public QuestManger Quest { get { return _questManager; } }
		public DataManager Data { get { return _dataManager; } }
		public PlayerRecordManager PlayerRecored {  get { return _playerRecordManager; } }
		#endregion

		#region Scenes
		private StartScene _startScene = new StartScene();
		private HomeScene _homeScene = new HomeScene();
		private StatusScene _statusScene = new StatusScene();
		private BattleScene _battleScene = new BattleScene();
		private InventoryScene _inventoryScene = new InventoryScene();
		private QuestScene _questScene = new QuestScene();
		#endregion

		public GameManager()
		{
			if (_instance == null)
			{
				_instance = this;

				_questScene.Init();
			}
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
					case Defines.GameStatus.Start:	 // -1 
						_status = (Defines.GameStatus)_startScene.PlayScene();
						break;
					case Defines.GameStatus.Home:	 // 0
						_status = (Defines.GameStatus)_homeScene.PlayScene();
						break;
					case Defines.GameStatus.Status:  // 1
						_status = (Defines.GameStatus)_statusScene.PlayScene();
						break;
					case Defines.GameStatus.Battle:  // 2
						_status = (Defines.GameStatus)_battleScene.PlayScene();
						break;
					case Defines.GameStatus.Inventory:  // 3
						_status = (Defines.GameStatus)_inventoryScene.PlayScene();
						break;
					case Defines.GameStatus.Quest:  // 4
						_status = (Defines.GameStatus)_questScene.PlayScene();
						break;
					case Defines.GameStatus.Save:  // 5
						break;
				}
			}
		}
		
	}
}
