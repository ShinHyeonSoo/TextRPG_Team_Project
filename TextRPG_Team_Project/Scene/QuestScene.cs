using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class QuestScene : Scene
	{
		enum QuestState
		{
			QuestList = 0,
			Quest = 1,
			QuestComplete = 2,
		}
		private QuestState _state;
		public override void DisplayInitScene()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine("퀘스트 목록 ");
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
				case QuestState.QuestList:
					DisplayInitScene();
					userInput = GameManager.GetNumberInput(0, 1);
					if(userInput == 0) { return  0; }
					break;
				case QuestState.Quest:
					DisplayQuest();
					return 0;
				case QuestState.QuestComplete:
					DisplayQuestCompletion();
					return 0;
			}
			return 0;
		}
	}
}
