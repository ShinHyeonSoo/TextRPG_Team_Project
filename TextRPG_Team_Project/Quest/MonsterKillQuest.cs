using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Quest
{
	public class MonsterKillQuest : Quest
	{
		private string _monsterName;
		private int _killCount;

		public int GoalKillCount { get; init; }
		public MonsterKillQuest(string name, string description, string shortDiscription, string monsterName, int killCount, int goalKillCount, QuestStatus status, Reward reward) : base(name, description, shortDiscription, status, reward)
		{
			_monsterName = monsterName;
			_killCount = killCount;
			GoalKillCount = goalKillCount;
		}
		public void increaseKillCount(string name)
		{
			if (name == _monsterName)
			{
				_killCount++;
				if(_killCount == GoalKillCount)
				{
					CompleteQuest();
				}
			}
		}
	}
}
