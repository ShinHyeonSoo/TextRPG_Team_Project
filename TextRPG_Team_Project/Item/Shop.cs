using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Item
{
    public class Shop
    {
        // 테스트용
        Character character = DataManager.Instance().GetPlayer();
        // 테스트용 끝

        public Weapon[] weaponList = {
            new Weapon("맨주먹", 0, 1, true, 0),
            new Weapon("무기1", 100, 0, false, 5),
            new Weapon("무기2", 200, 0, false, 10),
            new Weapon("무기3", 500, 0, false, 15),
            new Weapon("무기4", 1000, 0, false, 20)
        };
        public Armor[] armorList = {
            new Armor("기본옷", 0, 1, true, 0),
            new Armor("아머1", 100, 0, false, 5),
            new Armor("아머2", 200, 0, false, 10),
            new Armor("아머3", 500, 0, false, 15),
            new Armor("아머4", 1000, 0, false, 20)
        };

        public Potion[] potionList = {
            new Potion("빈 물약", 0, 0, 0),
            new HealthPotion("체력 포션", 50, 3, 30)
        };


        void DisplayCharacterInventory()
        {
            Console.WriteLine("=====가방=====");
            Console.WriteLine("1. 무기 가방");
            Console.WriteLine("2. 방어구 가방");
            Console.WriteLine("3. 물약 가방");
            Console.WriteLine("==========");
        }

        void DisplayCharacterWeaponInventory()
        {
            Console.WriteLine("===무기 가방===");
            Console.WriteLine(" |이름|\t공격력|\t가격|  소지수");

            for (int i = 0; i < character.Weapon.Count; i++)
            {
                DisplayWeapon(i);
            }
            Console.WriteLine("==========");
        }

        void DisplayCharacterArmorInventory()
        {
            Console.WriteLine("==방어구 가방==");
            Console.WriteLine(" |이름|\t방어력|\t가격|  소지수");

            for (int i = 0; i < character.armor.Count; i++)
            {
                DisplayArmor(i);
            }
            Console.WriteLine("==========");
        }

        void DisplayCharacterPotionInventory()
        {
            Console.WriteLine("===물약 가방===");
            Console.WriteLine(" |이름|\t효과|\t가격|  소지수");
            for (int i = 0; i < character.potion.Count; i++)
            {
                DisplayPotion(i);
            }
            Console.WriteLine("==========");
        }


        public void DisplayWeaponShopList()
        {
            Console.WriteLine("==무기상점==");
            Console.WriteLine(" |이름|\t공격력|\t가격|  소지수");
            for (int i = 1; i < weaponList.Length; i++)
            {
                DisplayWeapon(i);
            }
            Console.WriteLine("========");
        }

        void DisplayWeapon(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string weaponName = $"{weaponList[indexNum].Name}";
            string weaponPrice = $"{weaponList[indexNum].ItemPrice}";
            string weaponCount;
            if (weaponList[indexNum].ItemCount < weaponList[indexNum].ItemCountMax)
            {
                weaponCount = $"{weaponList[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = $"{weaponList[indexNum].WeaponAttack}";

            Console.WriteLine($"{indexNumber}|{weaponName}|\t{WeaponAttack}|{weaponPrice}G|{weaponCount}|");
        }

        public void DisplayArmorShopList()
        {
            Console.WriteLine("==방어구상점==");
            Console.WriteLine(" |\t이름|\t방어력|\t가격|  소지수");
            for (int i = 1; i < armorList.Length; i++)
            {
                DisplayArmor(i);
            }
            Console.WriteLine("========");
        }

        void DisplayArmor(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string armorName = $"{armorList[indexNum].Name}";
            string armorPrice = $"{armorList[indexNum].ItemPrice}";
            string armorCount;
            if (armorList[indexNum].ItemCount < armorList[indexNum].ItemCountMax)
            {
                armorCount = $"{armorList[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = $"{armorList[indexNum].ArmorDefence}";

            Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
        }

        public void DisplayPotionShopList()
        {
            Console.WriteLine("==물약상점==");
            Console.WriteLine(" |\t이름| 효과|\t가격|  소지수");
            for (int i = 1; i < potionList.Length; i++)
            {
                DisplayPotion(i);
            }
            Console.WriteLine("========");
        }

        void DisplayPotion(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string potionName = $"{potionList[indexNum].Name}";
            string potionPrice = $"{potionList[indexNum].ItemPrice}";
            string potionCount;
            if (potionList[indexNum].ItemCount < potionList[indexNum].ItemCountMax)
            {
                potionCount = $"{potionList[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{potionList[indexNum].PotionEffect}";

            Console.WriteLine($"{indexNumber}|{potionName}|\t{potionEffect}|{potionPrice}G|{potionCount}|");
        }

        void CharacterInventoryCheck()
        {
            // weapon check
            for (int i = 0; i < weaponList.Length; i++)
            {
                if (weaponList[i].ItemCount > 0)
                {
                    character.Weapon.Add(weaponList[i]);
                }
                else
                {
                    character.Weapon.Remove(weaponList[i]);
                }
            }
            // armor check
            for (int i = 0; i < armorList.Length; i++)
            {
                if (armorList[i].ItemCount > 0)
                {
                    character.armor.Add(armorList[i]);
                }
                else
                {
                    character.armor.Remove(armorList[i]);
                }
            }
            // potion check
            for (int i = 1; i < potionList.Length; i++)
            {
                if (potionList[i].ItemCount > 0)
                {
                    character.potion.Add(potionList[i]);
                }
                else
                {
                    character.potion.Remove(potionList[i]);
                }
            }
        }

        void CharacterInventoryReset()
        {
            character.Weapon.Clear();
            character.armor.Clear();
            character.potion.Clear();
        }

        public void DebugInventory()
        {
            CharacterInventoryCheck();

            DisplayCharacterWeaponInventory();
            DisplayCharacterArmorInventory();
            DisplayCharacterPotionInventory();

            DisplayWeaponShopList();
            DisplayArmorShopList();
            DisplayPotionShopList();

            CharacterInventoryReset();
            Console.WriteLine();
        }
    }
}
