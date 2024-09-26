using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Quest;

namespace TextRPG_Team_Project.Scene
{
	public class QuestScene : Scene
	{
		private QuestManger _questManager;
		enum QuestSceneState
		{
			QuestList = 0,
			Quest = 1,
			QuestComplete = 2,
		}
		private QuestSceneState _state;

		public QuestScene(QuestManger questManager)
		{
			_questManager = questManager;
		}

		public override void DisplayInitScene()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			for (int i = 0; i < _questManager.Quests.Count; i++) 
			{
				Console.WriteLine(_questManager.Quests[i].Tostring());
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
		}
		public void DisplayQuest()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine("퀘스트 정보");
			Console.WriteLine();
			DisplayOption(new List<string>() { "1. 수락하기", "2. 거절하기" });
		}
		public void DisplayQuestCompletion()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine("퀘스트 완료 정보");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
		}

		public override int PlayScene()
		{
			int userInput = 0;
			switch (_state)
			{
				case QuestSceneState.QuestList:
					DisplayInitScene();
					userInput = GameManager.GetNumberInput(0, 1);
					if(userInput == 0) { return  0; }
					break;
				case QuestSceneState.Quest:
					DisplayQuest();
					return 0;
				case QuestSceneState.QuestComplete:
					DisplayQuestCompletion();
					return 0;
			}
			return 0;
		}
	}
}
