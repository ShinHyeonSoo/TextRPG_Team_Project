﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

		public static GameManager Instance {
			get
			{
				if (_instance == null)
				{
					_instance = new GameManager();
				}
				return _instance;
			}
		}

		
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
		private SaveScene _saveScene = new SaveScene();
		private LoadScene _loadScene = new LoadScene();
		#endregion

		private GameManager() {
		}
		public void GoHomeScene()
		{
			_status = Defines.GameStatus.Home;
		}
		public void GoAnySScene(Defines.GameStatus status)
		{
			_status = status;
		}
		public void GameMain()
		{
			while (true)
			{
				switch (_status)
				{
					case Defines.GameStatus.Start:	 // -1 
						_startScene.PlayScene();
						break;
					case Defines.GameStatus.Home:	 // 0
						_homeScene.PlayScene();
						break;
					case Defines.GameStatus.Status:  // 1
						_statusScene.PlayScene();
						break;
					case Defines.GameStatus.Battle:  // 2
						_battleScene.PlayScene();
						break;
					case Defines.GameStatus.Inventory:  // 3
						_inventoryScene.PlayScene();
						break;
					case Defines.GameStatus.Quest:      // 4
						_questScene.PlayScene();
						break;
					case Defines.GameStatus.Save:     // 5
						_saveScene.PlayScene();
						break;
					case Defines.GameStatus.Load:
						_loadScene.PlayScene();
						break;	
				}
			}
		}
		
	}
}
