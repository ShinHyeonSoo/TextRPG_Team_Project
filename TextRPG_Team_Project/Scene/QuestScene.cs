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
		private int _selectedQuest = 0;

		private Defines.QuestSceneState _state;

		public void Init()
		{
			_questManager = GameManager.Instance.Quest;
		}

		public override void DisplayInitScene()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			for (int i = 0; i < _questManager.Quests.Count; i++) 
			{
				Console.WriteLine($" - {i+1} {_questManager.Quests[i].Tostring()}");
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
		}
		public void DisplayQuest()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Name);
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Description);
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
				case Defines.QuestSceneState.QuestList:
					DisplayInitScene();
					userInput = Utils.GetNumberInput(0, _questManager.Quests.Count+1);
					if(userInput == 0) { return  0; }
					else
					{
						_state = Defines.QuestSceneState.Quest;
						_selectedQuest = userInput;
					}
					break;
				case Defines.QuestSceneState.Quest:
					DisplayQuest();
					userInput = Utils.GetNumberInput(0, _questManager.Quests.Count+1);
					if(userInput == 0) { return 0; }
					else
					{
						_state = Defines.QuestSceneState.Quest;
					}
					break;
				case Defines.QuestSceneState.QuestComplete:
					DisplayQuestCompletion();
					return 0;
			}
			return (int)Defines.GameStatus.Quest;
		}
	}
}
