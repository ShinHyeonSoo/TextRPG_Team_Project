using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
	public class MonsterKillQuest : Quest
	{
		private string _monsterName;
		private int _killCount;
		
		public string GetTargetMonsterName() {  return _monsterName; }
		public int GetNowKillCount() { return _killCount; }

		public int GoalKillCount { get; init; }
		[JsonIgnore]
		public string ShortDescription { get { return $"{_monsterName}을(를) {GoalKillCount} 마리 처치 | {_killCount} / {GoalKillCount}"; } }

		#region Constructor
		public MonsterKillQuest(string id, string name, string description, string monsterName, int killCount, int goalKillCount, Defines.QuestStatus status, Reward reward) : base(id, name, description, status, reward)
		{
			_monsterName = monsterName;
			_killCount = killCount;
			GoalKillCount = goalKillCount;
		}
		public MonsterKillQuest(string id, string name, string description, string monsterName, int goalKillCount, Reward reward) : base(id, name, description, reward)
		{
			_monsterName = monsterName;
			_killCount = 0;
			GoalKillCount = goalKillCount;
		}
		#endregion

		public override string Tostring()
		{
			string str = $"{base.Tostring()} | {ShortDescription}";
			return str ;
		}

		public override void AcceptQuest()
		{
			if (_status == Defines.QuestStatus.NotStarted)
			{
				_status = Defines.QuestStatus.InProgress;
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
					GameManager.Instance.PlayerRecored.TrackMonsterKills -= increaseKillCount;
				}
			}
		}

		public override QuestSaveData Save()
		{
			QuestSaveData data = base.Save();
			data.ProgressCount = _killCount;
			return data;
		}

		public override void Load(QuestSaveData data)
		{
			base.Load(data);
			_killCount = data.ProgressCount;
			if(_status == Defines.QuestStatus.InProgress)
			{
				GameManager.Instance.PlayerRecored.TrackMonsterKills += increaseKillCount;
			}
		}
	}
}
