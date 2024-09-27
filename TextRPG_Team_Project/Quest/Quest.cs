using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Quest
{
	public struct Reward
	{
		public int Gold { get; set; }
		// 아이템 리스트 
		public Reward(int gold) { Gold = gold; }
		public override string ToString()
		{
			return $"Gold : {Gold}";
		}
	}
	public abstract class Quest
	{
		public enum QuestStatus
		{
			NotStarted = 0,
			InProgress,
			Completed,
			RewardClaimed
		}

		[JsonInclude]
		protected QuestStatus _status;

		public string Name { get; init; }
		public string Description { get; init; }
		public string ShortDiscription {  get; init; }
		public Reward? Reward {  get; init; }
		[JsonConstructor]
		public Quest(string name, string description, string shortDiscription, QuestStatus status, Reward reward)
		{
			Name = name;
			Description = description;
			ShortDiscription = shortDiscription;
			_status = status;
			Reward = reward;
		}
		public void AcceptQuest()
		{
			if (_status == QuestStatus.NotStarted)
			{
				_status = QuestStatus.InProgress;
			}
		}
		public void CompleteQuest()
		{
			if (_status == QuestStatus.InProgress)
				_status = QuestStatus.Completed;
		}
		public Reward? GiveReward() 
		{
			if(_status == QuestStatus.Completed)
			{
				_status = QuestStatus.RewardClaimed;
				return Reward;
			}
			else { return null; }
		}
		public string Tostring()
		{
			string thisString = $"{Name} | {ShortDiscription}";
			switch (_status)
			{
				case QuestStatus.NotStarted:
					break;
				case QuestStatus.InProgress:
					thisString = $"[진행중] {thisString}";
					break;
				case QuestStatus.Completed:
					thisString = $"[완료가능] {thisString}";
					break;
				case QuestStatus.RewardClaimed:
					thisString = $"[완료] {thisString}";
					break;
			}

			return thisString;
		}

	}
}
