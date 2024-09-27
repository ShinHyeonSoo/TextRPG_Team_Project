using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Quest
{
	public class QuestManger
	{
		[JsonInclude]
		public List<Quest> Quests { get; private set; } = new List<Quest>();

		public QuestManger() 
		{
			//Quests.Add(new Quest("첫번째 임무", "첫번째 설명", (Quest.QuestStatus)0, new Reward(1000)));
		}

		public string DisplayQuestList()
		{
			StringBuilder sb = new StringBuilder();
			for(int i = 0; i < Quests.Count; i++)
			{
				sb.AppendLine(Quests.ToString());
			}
			return sb.ToString();
		}
	}
}
