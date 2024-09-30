using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
				StyleConsole.Write($" {i + 1} ", ConsoleColor.Cyan);
				switch(_questManager.Quests[i].Status)
				{
					case Defines.QuestStatus.InProgress:
						StyleConsole.Write($" {_questManager.Quests[i].StateInfo()} ", ConsoleColor.Blue);
						Console.WriteLine($" {_questManager.Quests[i].Tostring()}");
						break;
					case Defines.QuestStatus.Completed:
						StyleConsole.Write($" {_questManager.Quests[i].StateInfo()} ", ConsoleColor.Magenta);
						Console.WriteLine($" {_questManager.Quests[i].Tostring()}");
						break;
					case Defines.QuestStatus.RewardClaimed:
						StyleConsole.WriteLine($"{_questManager.Quests[i].StateInfo()} {_questManager.Quests[i].Tostring()}", ConsoleColor.DarkGray);
						break;
					default:
						Console.WriteLine($"{_questManager.Quests[i].StateInfo()} {_questManager.Quests[i].Tostring()}");
						break;
				}
			}
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public void DisplayQuest()
		{
			DisplayIntro("Quest");
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
			Console.WriteLine($"{_questManager.Quests[_selectedQuest].Name} 완료!");
			Console.WriteLine();
			Console.WriteLine(_questManager.Quests[_selectedQuest].Description);
			Console.WriteLine() ;
			Console.WriteLine(_questManager.Quests[_selectedQuest].ShortDescriptoin);
			Console.WriteLine();
			Console.WriteLine($"보상");
			Console.WriteLine($"{_questManager.Quests[_selectedQuest].Reward.ToString()}");
			Console.WriteLine();
			Console.WriteLine("1. 보상받기");
			Console.WriteLine("2. 돌아가기");
			DisplayGetInputNumber();
		}

		public void DisplayGetQuestReward()
		{
			DisplayIntro("Quest");
			Console.WriteLine($"{_questManager.Quests[_selectedQuest].Name} 완료!");
			Console.WriteLine();
			Console.WriteLine($"보상");
			StyleConsole.WriteLine($"{_questManager.Quests[_selectedQuest].Reward.ToString()}",ConsoleColor.DarkGreen);
			Console.WriteLine("획득 완료");
			_questManager.GiveQuestReward(_selectedQuest);
			Console.WriteLine();
			Console.WriteLine("2.돌아가기");
			Console.WriteLine();
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
				case Defines.QuestSceneState.QuestReward:
					DisplayGetQuestReward();
					ProcessQuestReward();
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
			int userInput = 0;
			userInput = Utils.GetNumberInput(1,3);
			if (userInput == 1) { _state = Defines.QuestSceneState.QuestReward; }
			else { _state = Defines.QuestSceneState.QuestList; }
		}
		public void ProcessQuestReward()
		{
			_questManager.GiveQuestReward(_selectedQuest);
			if (Utils.GetNumberInput(2, 3) == 2) { _state = Defines.QuestSceneState.QuestList; }
		}

	}
}
