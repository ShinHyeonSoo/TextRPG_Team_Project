using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG_Team_Project.Quest
{
	internal class PlayerRecordManager
	{
		private int monsterKillCount;
		private int potionUseCount;

		event Action<string> TrackMonsterKills = (string name)=> { };
		event Action<string> TrackPotionUse = (string name) => { };

		public void increseMonsterKillCount(string name)
		{
			monsterKillCount += 1;
			TrackMonsterKills.Invoke(name);
		}

		public void incresePotionUseCount(string name)
		{
			potionUseCount += 1;
			TrackPotionUse.Invoke(name);
		}
	}
}
