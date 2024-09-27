using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Quest;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Quest
{
	public class EquipQuest : Quest
	{
		private string _equipmentItem;

		[JsonIgnore]
		public string ShortDescription { get { return $"{_equipmentItem}을 착용하기."; } }
		public EquipQuest(string name, string description, string equipment, Reward reward) : base(name, description, reward)
		{
			_equipmentItem = equipment;
		}

		public EquipQuest(string name, string description, string equipment, Defines.QuestStatus status, Reward reward) : base(name, description, status, reward)
		{
			_equipmentItem = equipment;
		}

		public override void AcceptQuest()
		{
			if (_status == Defines.QuestStatus.NotStarted)
			{
				_status = Defines.QuestStatus.InProgress;
				GameManager.Instance.PlayerRecored.TrackEquip += CheckUserEquipTargetItem;
			}
		}
		public void CheckUserEquipTargetItem(string equipment)
		{
			if (equipment == _equipmentItem) 
			{
				CompleteQuest();
			}
		}

	}
}
