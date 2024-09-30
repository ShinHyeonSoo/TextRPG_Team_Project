using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Item.Potions;

namespace TextRPG_Team_Project.Data
{
	public struct PotionDataBase
	{
		private Dictionary<string, Potion> potionDict;
		public Dictionary<string, Potion> PotionDict { get { return potionDict; } }
		public PotionDataBase()
		{
			potionDict = new Dictionary<string, Potion>();
			potionDict.Add("작은 회복 포션", new HealthPotion("작은 회복 포션", 100, 0, 30));
			potionDict.Add("중간 회복 포션", new HealthPotion("중간 회복 포션", 500, 0, 70));
			potionDict.Add("큰 회복 포션", new HealthPotion("큰 회복 포션", 1000, 0, 140));
		}
	}
}
