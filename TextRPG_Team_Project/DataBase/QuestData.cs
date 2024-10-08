﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
	public struct QuestDataBase
	{
		private Dictionary<string, Quest> questDict;
		public Dictionary<string, Quest> QuestDict { get { return questDict; } }
		public QuestDataBase() {
			questDict = new Dictionary<string, Quest>();
			questDict.Add("1001",new MonsterKillQuest("1001",
				"미니언 처치",
				"요즘 미니언이 공격성을 띄는 것 같아.\n 아무래도 본때를 보여줘서 인간의 무서움을 일깨워줘야하지 않을까?",
				"미니언",
				1,
				new Reward(100)));
			questDict.Add("1002", new MonsterKillQuest("1002",
				"대포 미니언 처치",
				"큰일났습니다. 미니언중에 대포를 들고 다니는 놈이 발견되었습니다. \n 이대로 두면 큰 피해를 입힐 것이 분명합니다. \n 이 새로운 대포 미니언을 처치해주시는 분께 사례를 해드리겠습니다.",
				"대포미니언",
				1,
				new Reward(1000)));
			questDict.Add("1003", new MonsterKillQuest("1003",
				"공허충 처치",
				"꺄악 이상한 까만 벌레를 봤어.\n 아무나 저 벌레를 잡아주는 사람에게 사례를 할께!",
				"공허충",
				1,
				new Reward(700)));
			questDict.Add("2001", new PotionUseQuest("2001",
				"회복 포션 사용",
				"모험가라면 회복 포션도 사용할 줄 알아야하는 법.\n 회복포션을 사용해보고오면 보상을 줄께",
				"회복포션",
				1,
				new Reward(700)));
			questDict.Add("3001", new EquipQuest("3001",
				"나무칼 착용",
				"모험하러 가는데 그 꼴로 갈거야? \n나무칼이라도 챙기지 그래?",
				"나무 칼",
				new Reward(700)));

			questDict.Add("4001", new LevelQuest("4001",
				"2레벨 달성",
				"레벨 2레벨을 달성해오라구~",
				2,
				new Reward(700)));
		}
	}
}
