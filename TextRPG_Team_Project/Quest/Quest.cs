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
		[JsonInclude]
		protected Defines.QuestStatus _status;

		public string Name { get; init; }
		public string Description { get; init; }
		[JsonIgnore]
		public string ShortDescriptoin { get { return ""; } }
		public Reward? Reward {  get; init; }
		public Defines.QuestStatus Status { get { return _status; } }

		#region Constructor
		[JsonConstructor]
		public Quest(string name, string description, Defines.QuestStatus status, Reward reward)
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
			_status = Defines.QuestStatus.NotStarted;
			Reward = reward;
		}
		#endregion


		public virtual void AcceptQuest()
		{
			if (_status == Defines.QuestStatus.NotStarted)
			{
				_status = Defines.QuestStatus.InProgress;
			}
		}

		public void CompleteQuest()
		{
			if (_status == Defines.QuestStatus.InProgress)
				_status = Defines.QuestStatus.Completed;
		}

		public Reward? GiveReward() 
		{
			if(_status == Defines.QuestStatus.Completed)
			{
				_status = Defines.QuestStatus.RewardClaimed;
				return Reward;
			}
			else { return null; }
		}

		public virtual string Tostring()
		{
			string thisString = $"{Name}";
			return thisString;
		}
		public virtual string StateInfo()
		{
			string thisString ="";
			switch (_status)
			{
				case Defines.QuestStatus.NotStarted:
					break;
				case Defines.QuestStatus.InProgress:
					thisString = $"[진행중]";
					break;
				case Defines.QuestStatus.Completed:
					thisString = $"[완료가능]";
					break;
				case Defines.QuestStatus.RewardClaimed:
					thisString = $"[완료]";
					break;
			}
			return thisString;
		}
	}
}
