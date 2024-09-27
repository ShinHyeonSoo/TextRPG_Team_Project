﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Quest
{
	public class MonsterKillQuest : Quest
	{
		private string _monsterName;
		private int _killCount;

		public int GoalKillCount { get; init; }
		#region Constructor
		public MonsterKillQuest(string name, string description, string monsterName, int killCount, int goalKillCount, QuestStatus status, Reward reward) : base(name, description, status, reward)
		{
			_monsterName = monsterName;
			_killCount = killCount;
			GoalKillCount = goalKillCount;
		}
		public MonsterKillQuest(string name, string description, string monsterName, int goalKillCount, Reward reward) : base(name, description, reward)
		{
			_monsterName = monsterName;
			_killCount = 0;
			GoalKillCount = goalKillCount;
		}
		#endregion

		public override string Tostring()
		{
			string str = $"{base.Tostring()} | {_monsterName}을 {GoalKillCount} 마리 처치";
			return str ;
		}
		public override void AcceptQuest()
		{
			if (_status == QuestStatus.NotStarted)
			{
				_status = QuestStatus.InProgress;
				GameManager.Instance.PlayerRecored.TrackMonsterKills += increaseKillCount;
			}
		}

		public void increaseKillCount(string name)
			/*
			 * PlayerRecordManager의 TrackkillCount에 할당합니다
			 */
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
