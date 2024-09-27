using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;

namespace TextRPG_Team_Project.Item
{
    public class Shop
    {
        public Weapon[] WeaponList = {
            new Weapon("Empty", 0, 0, false, 0),
            new Weapon("무기1", 100, 0, false, 5),
            new Weapon("무기2", 200, 0, false, 10),
            new Weapon("무기3", 500, 0, false, 15),
            new Weapon("무기4", 1000, 0, false, 20)
        };
        public Armor[] ArmorList = {
            new Armor("Empty", 0, 0, false, 0),
            new Armor("아머1", 100, 0, false, 5),
            new Armor("아머2", 200, 0, false, 10),
            new Armor("아머3", 500, 0, false, 15),
            new Armor("아머4", 1000, 0, false, 20)
            };

        public Potion[] PotionList =
        {
            new Potion(),
            new HealthPotion("체력 포션", 50, 3, 30)
        };

        public void DisplayWeaponShopList()
        {
            Console.WriteLine("==무기상점==");
            Console.WriteLine(" |이름|\t공격력|\t가격|  소지수");
            for (int i = 1; i < WeaponList.Length; i++)
            {
                DisplayWeapon(i);
            }
            Console.WriteLine("========");
        }

        void DisplayWeapon(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string weaponName = $"{WeaponList[indexNum].Name}";
            string weaponPrice = $"{WeaponList[indexNum].ItemPrice}";
            string weaponCount;
            if (WeaponList[indexNum].ItemCount < WeaponList[indexNum].ItemCountMax)
            {
                weaponCount = $"{WeaponList[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = $"{WeaponList[indexNum].WeaponAttack}";

            Console.WriteLine($"{indexNumber}|{weaponName}|\t{WeaponAttack}|{weaponPrice}G|{weaponCount}|");
        }

        public void DisplayArmorShopList()
        {
            Console.WriteLine("==방어구상점==");
            Console.WriteLine(" |이름|\t방어력|\t가격|  소지수");
            for (int i = 1; i < ArmorList.Length; i++)
            {
                DisplayArmor(i);
            }
            Console.WriteLine("========");
        }

        void DisplayArmor(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string armorName = $"{ArmorList[indexNum].Name}";
            string armorPrice = $"{ArmorList[indexNum].ItemPrice}";
            string armorCount;
            if (ArmorList[indexNum].ItemCount < ArmorList[indexNum].ItemCountMax)
            {
                armorCount = $"{ArmorList[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = $"{ArmorList[indexNum].ArmorDefence}";

            Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
        }

        public void DisplayPotionShopList()
        {
            Console.WriteLine("==물약상점==");
            Console.WriteLine(" |이름| 효과|\t가격|  소지수");
            for (int i = 1; i < PotionList.Length; i++)
            {
                DisplayPotion(i);
            }
            Console.WriteLine("========");
        }

        void DisplayPotion(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string potionName = $"{PotionList[indexNum].Name}";
            string potionPrice = $"{PotionList[indexNum].ItemPrice}";
            string potionCount;
            if (PotionList[indexNum].ItemCount < PotionList[indexNum].ItemCountMax)
            {
                potionCount = $"{PotionList[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{PotionList[indexNum].PotionEffect}";

            Console.WriteLine($"{indexNumber}|{potionName}|\t{potionEffect}|{potionPrice}G|{potionCount}|");
        }
    }
}
