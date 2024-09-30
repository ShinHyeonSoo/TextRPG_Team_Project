using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
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
		protected Defines.QuestStatus _status;
		private string _id;
		public string ID { get {  return _id; } }
		public string Name { get; init; }
		public string Description { get; init; }
		public string ShortDescriptoin { get { return ""; } }
		public Reward Reward {  get; init; }
		public Defines.QuestStatus Status { get { return _status; } }

		#region Constructor
		public Quest(string id,string name, string description, Defines.QuestStatus status, Reward reward)
		{
			_id = id;
			Name = name;
			Description = description;
			_status = status;
			Reward = reward;
		}

		public Quest(string id, string name, string description, Reward reward)
		{
			_id = id;
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

		public Reward GiveReward() 
		{
			if(_status == Defines.QuestStatus.Completed)
			{
				_status = Defines.QuestStatus.RewardClaimed;
				return Reward;
			}
			else { return new Reward(0); }
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
		public virtual QuestSaveData Save()
		{
			QuestSaveData data = new QuestSaveData();
			data.ID = ID;
			data.QuestStatus = Status;
			return data;
		}
		public virtual void Load(QuestSaveData data)
		{
			if (_id == data.ID) {
				_status = data.QuestStatus;
			}
		}
	}
}
