using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG_Team_Project
{
	public class PlayerRecordManager
	{
		private int monsterKillCount;
		private int potionUseCount;

		public event Action<string> TrackMonsterKills = (string name)=> { };
		public event Action<string> TrackPotionUse = (string name) => { };
		public event Action<string> TrackEquip = (string name) => { };

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
		public void NotifyUserEuipment(string name)
		{
			TrackEquip.Invoke(name);
		}
	}
}
