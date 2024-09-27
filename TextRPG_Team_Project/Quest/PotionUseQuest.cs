using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Quest
{
	public class PotionUseQuest : Quest
	{
		private string _potionName;
		private int _useCount;

		public int GoalUseCount { get; init; }
		public PotionUseQuest(string name, string description, string shortDiscription, string monsterName, int killCount, int goalKillCount, QuestStatus status, Reward reward) : base(name, description, shortDiscription, status, reward)
		{
			_potionName = monsterName;
			_useCount = killCount;
			GoalUseCount = goalKillCount;
		}
		public void increaseKillCount(string name)
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
