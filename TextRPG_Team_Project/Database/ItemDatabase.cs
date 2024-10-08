﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;

namespace TextRPG_Team_Project.Database
{
    public class ItemDatabase
    {
        /*
        public Weapon[] weaponArr = {
            new Weapon("맨 주먹",  0, 1, true, 0),
            new Weapon("나무 검",  800, 0, false, 5),
            new Weapon("무쇠 검",  800, 0, false, 10),
            new Weapon("강철 검", 2200, 0, false, 15),
            new Weapon("미스릴 검",  6500, 0, false, 25),
            new Weapon("나무 지팡이",  800, 0, false, 5),
            new Weapon("전투 지팡이",  800, 0, false, 10),
            new Weapon("마법 지팡이", 2200, 0, false, 15),
            new Weapon("대마법 지팡이",  6500, 0, false, 25)
        };

        public Armor[] armorArr = {
            new Armor("일반 옷",  0, 1, true, 0),
            new Armor("가죽 갑옷", 500, 0, false, 5),
            new Armor("사슬 갑옷", 1200, 0, false, 10),
            new Armor("판금 갑옷",  2000, 0, false, 15),
            new Armor("용 비늘 갑옷",  5000, 0, false, 25),
            new Armor("천 로브",  500, 0, false, 5),
            new Armor("견습 로브", 1200, 0, false, 10),
            new Armor("숙련 로브",  2000, 0, false, 15),
            new Armor("대마법사 로브",  5000, 0, false, 25)
        };

        public Potion[] potionArr = {
            new Potion("빈 물약", 0, 0, 0),
            new HealthPotion("체력 포션", 50, 3, 30)
        };
        */
        public Dictionary<string , Weapon> WeaponDict = new Dictionary<string , Weapon>();
        public Dictionary<string , Armor> ArmorDict = new Dictionary<string , Armor>();
        public Dictionary<string , Potion> PotionDict = new Dictionary<string , Potion>();

        public ItemDatabase()
        {
            WeaponDict.Add("맨 주먹", new Weapon("맨 주먹", 0, 0, false, 0));
            WeaponDict.Add("나무 검", new Weapon("나무 검", 800, 0, false, 5));
            WeaponDict.Add("무쇠 검", new Weapon("무쇠 검", 1500, 0, false, 10));
            WeaponDict.Add("강철 검", new Weapon("강철 검", 2200, 0, false, 15));
            WeaponDict.Add("미스릴 검", new Weapon("미스릴 검", 6500, 0, false, 25));
            WeaponDict.Add("나무 지팡이", new Weapon("나무 지팡이", 800, 0, false, 5));
            WeaponDict.Add("전투 지팡이", new Weapon("전투 지팡이", 1500, 0, false, 10));
            WeaponDict.Add("마법 지팡이", new Weapon("마법 지팡이", 2200, 0, false, 15));
			WeaponDict.Add("대마법 지팡이", new Weapon("대마법 지팡이", 6500, 0, false, 25));

            ArmorDict.Add("일반 옷", new Armor("일반 옷", 0, 0, false, 0));
            ArmorDict.Add("가죽 갑옷", new Armor("가죽 갑옷", 500, 0, false, 5));
            ArmorDict.Add("사슬 갑옷", new Armor("사슬 갑옷", 1200, 0, false, 10));
            ArmorDict.Add("판금 갑옷", new Armor("판금 갑옷",  2000, 0, false, 15));
            ArmorDict.Add("용 비늘 갑옷", new Armor("용 비늘 갑옷",  5000, 0, false, 25));
            ArmorDict.Add("천 로브", new Armor("천 로브",  500, 0, false, 5));
            ArmorDict.Add("견습 로브", new Armor("견습 로브", 1200, 0, false, 10));
            ArmorDict.Add("숙련 로브", new Armor("숙련 로브",  2000, 0, false, 15));
			ArmorDict.Add("대마법사 로브", new Armor("대마법사 로브", 5000, 0, false, 25));

            PotionDict.Add("빈 물약", new Potion("빈 물약", 0, 0, 0));
            PotionDict.Add("작은 회복 포션", new HealthPotion("작은 회복 포션", 100, 0, 30));
            PotionDict.Add("중간 회복 포션", new HealthPotion("중간 회복 포션", 500, 0, 70));
			PotionDict.Add("큰 회복 포션", new HealthPotion("큰 회복 포션", 1000, 0, 140));
        }
    }
}
