using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
	public class LevelQuest : Quest
	{
		private int _targetLevel;

		[JsonIgnore]
		public string ShortDescription { get { return $"{_targetLevel} 달성 | {GameManager.Instance.Data.GetPlayer().Level}/{_targetLevel}"; } }

		#region [Conductor]
		public LevelQuest(string id,string name, string description, int targetLevel, Reward reward) : base(id, name, description, reward)
		{
			_targetLevel = targetLevel;
		}

		public LevelQuest(string id, string name, string description, int targetLevel, Defines.QuestStatus status, Reward reward) : base(id, name, description, status, reward)
		{
			_targetLevel = targetLevel;
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
				GameManager.Instance.PlayerRecored.TrackLevel += CheckUserLevel;
			}
		}

		public void CheckUserLevel()
		{
			if(GameManager.Instance.Data.GetPlayer().Level == _targetLevel)
			{
				CompleteQuest();
				GameManager.Instance.PlayerRecored.TrackLevel -= CheckUserLevel;
			}
		}
		public override QuestSaveData Save()
		{
			QuestSaveData data = new QuestSaveData();
			data.ID = ID;
			data.QuestStatus = Status;
			data.ProgressCount = 0;
			return data;
		}
		public override void Load(QuestSaveData data)
		{
			base.Load(data);
			if (_status == Defines.QuestStatus.InProgress)
			{
				GameManager.Instance.PlayerRecored.TrackLevel += CheckUserLevel;
			}
		}
	}
}
