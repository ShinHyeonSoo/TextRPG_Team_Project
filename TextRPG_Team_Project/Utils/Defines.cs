﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
	public class Defines
	{
		public const string SAVE_FOLDER = "save";
		public enum GameStatus
		{
			Start = -1,
			Home = 0,
			Status = 1,
			Battle,
			Inventory,
			Quest,
			Save,
			Load,
		}
		public enum QuestSceneState
		{
			QuestList = 0,
			Quest = 1,
			QuestComplete = 2,
			QuestReward,
		}
		public enum InventoryState
		{
			Start = 0,
			ManagingEuipment = 1,
			UseItem = 2,
		}
		public enum QuestStatus
		{
			NotStarted = 0,
			InProgress,
			Completed,
			RewardClaimed
		}


	}
}
