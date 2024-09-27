using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

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
		public Reward? Reward {  get; init; }

		#region Constructor
		[JsonConstructor]
		public Quest(string name, string description, QuestStatus status, Reward reward)
		{
			Name = name;
			Description = description;
			_status = status;
			Reward = reward;
		}
		public Quest(string name, string description, Reward reward)
		{
			Name = name;
			Description = description;
			_status = QuestStatus.NotStarted;
			Reward = reward;
		}
		#endregion


		public virtual void AcceptQuest()
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
		public virtual string Tostring()
		{
			string thisString = $"{Name}";
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
