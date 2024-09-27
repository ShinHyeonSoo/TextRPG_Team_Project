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
		private int _selectedQuest;

		private Defines.QuestSceneState _state;

		public void Init()
		{
			_selectedQuest = 0;
			_questManager = GameManager.Instance.Quest;
		}

		public override void DisplayInitScene()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			for (int i = 0; i < _questManager.Quests.Count; i++) 
			{
				Console.WriteLine($" - {i+1} {_questManager.Quests[i].StateInfo()} {_questManager.Quests[i].Tostring()}");
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public void DisplayQuest()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Name);
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Description);
			Console.WriteLine();
			if (_questManager.IsAcceptedQuest(_selectedQuest))
			{
				Console.WriteLine("이미 수락한 퀘스트 입니다.");
				Console.WriteLine("2. 나가기");
			}
			else { DisplayOption(new List<string>() { "1. 수락하기", "2. 거절하기" }); }
			DisplayGetInputNumber();

		}

		public void DisplayQuestCompletion()
		{
			DisplayIntro("Quest");
			Console.WriteLine();
			Console.WriteLine($"{_questManager.Quests[_selectedQuest].Name} 완료!");
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Description);
			Console.WriteLine() ;
			Console.WriteLine(_questManager.Quests[_selectedQuest].ShortDescriptoin);
			Console.WriteLine();
			Console.WriteLine($"보상");
			Console.WriteLine($"{_questManager.Quests[_selectedQuest].Reward.ToString()}");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public void DisplayRewardClaimedQuest()
		{
			(int left, int top) = Console.GetCursorPosition();
			Console.SetCursorPosition(left, top-2);
			Console.WriteLine("이미 완료된 퀘스트 입니다. 다른 퀘스트를 선택하세요");
			Console.Write(">>>   ");
		}

		public override void PlayScene()
		{
			switch (_state)
			{
				case Defines.QuestSceneState.QuestList:
					DisplayInitScene();
					ProcessQuestSelect();
					break;

				case Defines.QuestSceneState.Quest:
					DisplayQuest();
					ProcessQuestAcceptDecision();
					break;

				case Defines.QuestSceneState.QuestComplete:
					DisplayQuestCompletion();
					ProcessQuestCompletion();
					break;
			}
		}

		public void ProcessQuestSelect()
		{
			int userInput = 0;
			userInput = Utils.GetNumberInput(0, _questManager.Quests.Count + 1);
			if (userInput == 0) { GameManager.Instance.GoHomeScene(); }
			else
			{
				_selectedQuest = userInput - 1;
				Defines.QuestStatus selectQuestState = _questManager.GetQuestStatus( _selectedQuest );
				switch (selectQuestState)
				{
					case Defines.QuestStatus.NotStarted:
					case Defines.QuestStatus.InProgress:
						_state = _state = Defines.QuestSceneState.Quest;
						break;
					case Defines.QuestStatus.Completed:
						_state = Defines.QuestSceneState.QuestComplete;
						break;
					case Defines.QuestStatus.RewardClaimed:
						
						break;
				}
			}
		}

		public void ProcessQuestAcceptDecision()
		{
			int userInput = 0;
			if (_questManager.IsAcceptedQuest(_selectedQuest))
			{
				userInput = Utils.GetNumberInput(2,3);
			}
			else
			{
				userInput = Utils.GetNumberInput(1, 3);
				if (userInput == 1) _questManager.AcceptQuest(_selectedQuest);
			}
			_state = Defines.QuestSceneState.QuestList;
		}

		public void ProcessQuestCompletion()
		{
			_questManager.GiveQuestReward(_selectedQuest);
			int userInput = 0;
			userInput = Utils.GetNumberInput(0,1);
			_state = Defines.QuestSceneState.QuestList;
		}

	}
}
