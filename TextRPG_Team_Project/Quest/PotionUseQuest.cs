using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Quest
{
	public class PotionUseQuest : Quest
	{
		private string _potionName;
		private int _useCount;

		public int GoalUseCount { get; init; }

		#region Constructor
		public PotionUseQuest(string name, string description, string shortDiscription, string potionName, int useCount, int goalUseCount, QuestStatus status, Reward reward) : base(name, description, status, reward)
		{
			_potionName = potionName;
			_useCount = useCount;
			GoalUseCount = goalUseCount;
		}
		public PotionUseQuest(string name, string description, string potionName, int goalUseCount, Reward reward) : base(name, description, reward)
		{
			_potionName = potionName;
			_useCount = 0;
			GoalUseCount = goalUseCount;
		}
		#endregion
		public override string Tostring()
		{
			string str = $"{base.Tostring()} | {_potionName}을 {GoalUseCount}회 사용";
			return str;
		}

		public override void AcceptQuest()
		{
			if (_status == QuestStatus.NotStarted)
			{
				_status = QuestStatus.InProgress;
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
	}
}
