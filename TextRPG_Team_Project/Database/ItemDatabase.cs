using System;
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
        public Dictionary<string , Weapon> weaponDict = new Dictionary<string , Weapon>();
        public Dictionary<string , Armor> armorDict = new Dictionary<string , Armor>();
        public Dictionary<string , Potion> potionDict = new Dictionary<string , Potion>();

        public ItemDatabase()
        {
            weaponDict.Add("맨 주먹", new Weapon("맨 주먹", 0, 1, true, 0));
            weaponDict.Add("나무 검", new Weapon("나무 검", 800, 0, false, 5));
            weaponDict.Add("무쇠 검", new Weapon("무쇠 검", 800, 0, false, 10));
            weaponDict.Add("강철 검", new Weapon("강철 검", 2200, 0, false, 15));
            weaponDict.Add("미스릴 검", new Weapon("미스릴 검", 6500, 0, false, 25));
            weaponDict.Add("나무 지팡이", new Weapon("나무 지팡이", 800, 0, false, 5));
            weaponDict.Add("전투 지팡이", new Weapon("전투 지팡이", 800, 0, false, 10));
            weaponDict.Add("마법 지팡이", new Weapon("마법 지팡이", 2200, 0, false, 15));
            weaponDict.Add("대마법 지팡이", new Weapon("대마법 지팡이", 6500, 0, false, 25));

            armorDict.Add("일반 옷", new Armor("일반 옷", 0, 1, true, 0));
            armorDict.Add("가죽 갑옷", new Armor("가죽 갑옷", 500, 0, false, 5));
            armorDict.Add("사슬 갑옷", new Armor("사슬 갑옷", 1200, 0, false, 10));
            armorDict.Add("판금 갑옷", new Armor("판금 갑옷",  2000, 0, false, 15));
            armorDict.Add("용 비늘 갑옷", new Armor("용 비늘 갑옷",  5000, 0, false, 25));
            armorDict.Add("천 로브", new Armor("천 로브",  500, 0, false, 5));
            armorDict.Add("견습 로브", new Armor("견습 로브", 1200, 0, false, 10));
            armorDict.Add("숙련 로브", new Armor("숙련 로브",  2000, 0, false, 15));
            armorDict.Add("대마법사 로브", new Armor("대마법사 로브", 5000, 0, false, 25));

            potionDict.Add("빈 물약", new Potion("빈 물약", 0, 0, 0));
            potionDict.Add("체력 포션", new HealthPotion("체력 포션", 50, 3, 30));

        }
    }
}
