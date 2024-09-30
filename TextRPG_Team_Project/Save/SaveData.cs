using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;

namespace TextRPG_Team_Project
{
	public struct SaveData
	{
		public PlayerSaveData PlayerSaveData { get; set; }

		public List<QuestSaveData> QuestSaves { get; set; }
	}
	public struct PlayerSaveData
	{
		public string Job { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public int exp { get; set; }
		public int MaxHealth { get; set; }
		public int Health { get; set; }
		public float Attack { get; set; }
		public int Defense { get; set; }

		public int Gold { get; set; }
		public List<Weapon> Weapon { get; set; }
		public List<Armor> armor { get; set; }
		public List<PotionSaveData> PostionSaves { get; set; }

		public Weapon currentWeapon { get; set; }
		public Armor currentArmor { get; set; }
		public override string ToString()
		{
			string info = $"Job : {Job}, Name: {Name}, Gold : {Gold}";
			return info;
		}
	}
	public struct QuestSaveData
	{
		public string ID { get; set; }
		public int ProgressCount { get; set; }
		public Defines.QuestStatus QuestStatus { get; set; }
		public QuestSaveData(string id, int progress, Defines.QuestStatus questStatus) 
		{ 
			ID = id; 
			ProgressCount = progress;
			QuestStatus = questStatus; 
		}
	}
	public struct PotionSaveData
	{
		public string Name { get; set; }
		public int Count { get; set; }
		public PotionSaveData(string name, int count) { Name = name; Count = count; }
	}
}
