using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
	public class PotionUseQuest : Quest
	{
		private string _potionName;
		private int _useCount;

		public int GoalUseCount { get; init; }

		[JsonIgnore]
		public string ShortDescription { get { return $"{_potionName}을(를) {_useCount}개 사용 | {_potionName}/{_useCount}"; } }

		#region Constructor
		public PotionUseQuest(string id, string name, string description, string shortDiscription, string potionName, int useCount, int goalUseCount, Defines.QuestStatus status, Reward reward) : base(id, name, description, status, reward)
		{
			_potionName = potionName;
			_useCount = useCount;
			GoalUseCount = goalUseCount;
		}
		public PotionUseQuest(string id, string name, string description, string potionName, int goalUseCount, Reward reward) : base(id, name, description, reward)
		{
			_potionName = potionName;
			_useCount = 0;
			GoalUseCount = goalUseCount;
		}
		#endregion
		public override string Tostring()
		{
			string str = $"{base.Tostring()} | {ShortDescription}";
			return str;
		}

		public override void AcceptQuest()
		{
			if (_status == Defines.QuestStatus.NotStarted)
			{
				_status = Defines.QuestStatus.InProgress;
				GameManager.Instance.PlayerRecored.TrackPotionUse += increaseUseCount;
			}
		}

		public void increaseUseCount(string name)
		/*
		 * PlayerRecordManager의 TrackUseCount에 할당합니다
		 */
		{
			if (name == _potionName)
			{
				_useCount++;
				if(_useCount == GoalUseCount)
				{
					CompleteQuest();
				}
			}
		}
		public override QuestSaveData Save()
		{
			QuestSaveData data = new QuestSaveData();
			data.ID = ID;
			data.QuestStatus = Status;
			data.ProgressCount = _useCount;
			return data;
		}
		public override void Load(QuestSaveData data)
		{
			base.Load(data);
			_useCount = data.ProgressCount;
			if (_status == Defines.QuestStatus.InProgress)
			{
				GameManager.Instance.PlayerRecored.TrackPotionUse += increaseUseCount;
			}
		}
	}
}
