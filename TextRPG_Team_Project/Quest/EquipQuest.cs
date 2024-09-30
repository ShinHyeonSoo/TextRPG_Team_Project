using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
	public class EquipQuest : Quest
	{
		private string _equipmentItem;

		[JsonIgnore]
		public string ShortDescription { get { return $"{_equipmentItem}을(를) 착용하기."; } }

		#region [Conductor]
		public EquipQuest(string id, string name, string description, string equipment, Reward reward) : base(id, name, description, reward)
		{
			_equipmentItem = equipment;
		}

		public EquipQuest(string id, string name, string description, string equipment, Defines.QuestStatus status, Reward reward) : base(id, name, description, status, reward)
		{
			_equipmentItem = equipment;
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
		public override QuestSaveData Save()
		{
			QuestSaveData data = new QuestSaveData();
			data.ID = ID;
			data.QuestStatus = Status;
			data.ProgressCount = 0;
			return data;
		}

	}
}
