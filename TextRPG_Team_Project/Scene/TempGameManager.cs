using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class TempGameManager
	{
		enum GameStatus
		{
			Start=0,
			Home,
			Status,

		}
		private GameStatus _status = GameStatus.Start;

		private Scene _startScene;
		private Scene _homeScene;
		private Scene _statusScene;

		public TempGameManager()
		{
			_startScene = new StartScene();
			_homeScene = new HomeScene();
			_statusScene = new StartScene();
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
					case GameStatus.Start:
						_status = (GameStatus)_startScene.PlayScene();
						break;
					case GameStatus.Home:
						_status = (GameStatus)_homeScene.PlayScene();
						break;
					case GameStatus.Status:
						_status = (GameStatus)_statusScene.PlayScene();
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
			
			while (input == null || input == "")
			{
				input = Console.ReadLine();
				if (int.TryParse(input, out inputNumber)) 
				{
					if (min <= inputNumber && inputNumber < max) { return inputNumber; }
				}
				else { input = ""; }
			}
			return -1;
		}
	}
}
