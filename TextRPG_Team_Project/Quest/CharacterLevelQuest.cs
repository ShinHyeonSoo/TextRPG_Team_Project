using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Quest
{
	public class CharacterLevelQuest : Quest
	{
		private int _targetLevel;

		[JsonIgnore]
		public string ShortDescription { get { return $"{_targetLevel} 달성 | {GameManager.Instance.Data.GetPlayer().Level}/{_targetLevel}"; } }

		public CharacterLevelQuest(string name, string description, int targetLevel, Reward reward) : base(name, description, reward)
		{
			_targetLevel = targetLevel;
		}

		public CharacterLevelQuest(string name, string description, int targetLevel, Defines.QuestStatus status, Reward reward) : base(name, description, status, reward)
		{
			_targetLevel = targetLevel;
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
			if(level == _targetLevel)
			{
				CompleteQuest();
			}
		}

	}
}
