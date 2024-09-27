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

        public Weapon[] weaponArr = {
            new Weapon("맨주먹", 0, 1, true, 0),
            new Weapon("무기1", 100, 1, false, 5),
            new Weapon("무기2", 200, 1, false, 10),
            new Weapon("무기3", 500, 1, false, 15),
            new Weapon("무기4", 1000, 1, false, 20)
        };
        public Armor[] armorArr = {
            new Armor("기본옷", 0, 1, true, 0),
            new Armor("아머1", 100, 1, false, 5),
            new Armor("아머2", 200, 1, false, 10),
            new Armor("아머3", 500, 1, false, 15),
            new Armor("아머4", 1000, 1, false, 20)
        };

        public Potion[] potionArr = {
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
                DisplayWeaponInventory(i);
            }
            Console.WriteLine("==========");
            Console.WriteLine();
        }

        void DisplayCharacterArmorInventory()
        {
            Console.WriteLine("==방어구 가방==");
            Console.WriteLine(" |이름|\t방어력|\t가격|  소지수");

            for (int i = 0; i < character.armor.Count; i++)
            {
                DisplayArmorInventory(i);
            }
            Console.WriteLine("==========");
            Console.WriteLine();
        }

        void DisplayCharacterPotionInventory()
        {
            Console.WriteLine("===물약 가방===");
            Console.WriteLine(" |이름|\t효과|\t가격|  소지수");
            for (int i = 0; i < character.potion.Count; i++)
            {
                DisplayPotionInventory(i);
            }
            
            Console.WriteLine("==========");
            Console.WriteLine();
        }


        public void DisplayWeaponShopArr()
        {
            Console.WriteLine("==무기상점==");
            Console.WriteLine(" |이름|\t공격력|\t가격|  소지수");
            for (int i = 1; i < weaponArr.Length; i++)
            {
                DisplayWeapon(i);
            }
            Console.WriteLine("========");
        }

        void DisplayWeapon(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string weaponName = $"{weaponArr[indexNum].Name}";
            string weaponPrice = $"{weaponArr[indexNum].ItemPrice}";
            string weaponCount;
            if (weaponArr[indexNum].ItemCount < weaponArr[indexNum].ItemCountMax)
            {
                weaponCount = $"{weaponArr[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = $"{weaponArr[indexNum].WeaponAttack}";

            Console.WriteLine($"{indexNumber}|{weaponName}|\t{WeaponAttack}|{weaponPrice}G|{weaponCount}|");
        }

        void DisplayWeaponInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string weaponName = $"{character.Weapon[indexNum].Name}";
            string weaponPrice = $"{character.Weapon[indexNum].ItemPrice}";
            string weaponCount;
            if (character.Weapon[indexNum].ItemCount < character.Weapon[indexNum].ItemCountMax)
            {
                weaponCount = $"{character.Weapon[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = $"{character.Weapon[indexNum].WeaponAttack}";

            Console.WriteLine($"{indexNumber}|{weaponName}|\t{WeaponAttack}|{weaponPrice}G|{weaponCount}|");
        }

        public void DisplayArmorShopArr()
        {
            Console.WriteLine("==방어구상점==");
            Console.WriteLine(" |\t이름|\t방어력|\t가격|  소지수");
            for (int i = 1; i < armorArr.Length; i++)
            {
                DisplayArmor(i);
            }
            Console.WriteLine("========");
        }

        void DisplayArmor(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string armorName = $"{armorArr[indexNum].Name}";
            string armorPrice = $"{armorArr[indexNum].ItemPrice}";
            string armorCount;
            if (armorArr[indexNum].ItemCount < armorArr[indexNum].ItemCountMax)
            {
                armorCount = $"{armorArr[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = $"{armorArr[indexNum].ArmorDefence}";

            Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
        }

        void DisplayArmorInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string armorName = $"{character.armor[indexNum].Name}";
            string armorPrice = $"{character.armor[indexNum].ItemPrice}";
            string armorCount;
            if (character.armor[indexNum].ItemCount < character.armor[indexNum].ItemCountMax)
            {
                armorCount = $"{character.armor[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = $"{character.armor[indexNum].ArmorDefence}";

            Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
        }

        public void DisplayPotionShopArr()
        {
            Console.WriteLine("==물약상점==");
            Console.WriteLine(" |\t이름| 효과|\t가격|  소지수");
            for (int i = 1; i < potionArr.Length; i++)
            {
                DisplayPotion(i);
            }
            Console.WriteLine("========");
        }

        void DisplayPotion(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string potionName = $"{potionArr[indexNum].Name}";
            string potionPrice = $"{potionArr[indexNum].ItemPrice}";
            string potionCount;
            if (potionArr[indexNum].ItemCount < potionArr[indexNum].ItemCountMax)
            {
                potionCount = $"{potionArr[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{potionArr[indexNum].PotionEffect}";

            Console.WriteLine($"{indexNumber}|{potionName}|\t{potionEffect}|{potionPrice}G|{potionCount}|");
        }

        void DisplayPotionInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string potionName = $"{character.potion[indexNum].Name}";
            string potionPrice = $"{character.potion[indexNum].ItemPrice}";
            string potionCount;
            if (character.potion[indexNum].ItemCount < character.potion[indexNum].ItemCountMax)
            {
                potionCount = $"{character.potion[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{character.potion[indexNum].PotionEffect}";

            Console.WriteLine($"{indexNumber}|{potionName}|\t{potionEffect}|{potionPrice}G|{potionCount}|");
        }

        void CharacterInventoryReset()
        {
            character.Weapon.Clear();
            character.armor.Clear();
            character.potion.Clear();

            // weapon check
            for (int i = 0; i < weaponArr.Length; i++)
            {
                if (weaponArr[i].ItemCount > 0)
                {
                    character.Weapon.Add(weaponArr[i]);
                }
                else
                {
                    character.Weapon.Remove(weaponArr[i]);
                }
            }
            // armor check
            for (int i = 0; i < armorArr.Length; i++)
            {
                if (armorArr[i].ItemCount > 0)
                {
                    character.armor.Add(armorArr[i]);
                }
                else
                {
                    character.armor.Remove(armorArr[i]);
                }
            }
            // potion check
            for (int i = 1; i < potionArr.Length; i++)
            {
                if (potionArr[i].ItemCount > 0)
                {
                    character.potion.Add(potionArr[i]);
                }
                else
                {
                    character.potion.Remove(potionArr[i]);
                }
            }
        }

        public void DebugInventory()
        {
            CharacterInventoryReset();

            DisplayCharacterWeaponInventory();
            DisplayCharacterArmorInventory();
            DisplayCharacterPotionInventory();

            DisplayWeaponShopArr();
            DisplayArmorShopArr();
            DisplayPotionShopArr();

            Console.WriteLine();
        }


        /*
        void CharacterInventoryCheck()
        {
            // weapon check
            for (int i = 0; i < weaponArr.Length; i++)
            {
                if (weaponArr[i].ItemCount > 0)
                {
                    character.Weapon.Add(weaponArr[i]);
                }
                else
                {
                    character.Weapon.Remove(weaponArr[i]);
                }
            }
            // armor check
            for (int i = 0; i < armorArr.Length; i++)
            {
                if (armorArr[i].ItemCount > 0)
                {
                    character.armor.Add(armorArr[i]);
                }
                else
                {
                    character.armor.Remove(armorArr[i]);
                }
            }
            // potion check
            for (int i = 1; i < potionArr.Length; i++)
            {
                if (potionArr[i].ItemCount > 0)
                {
                    character.potion.Add(potionArr[i]);
                }
                else
                {
                    character.potion.Remove(potionArr[i]);
                }
            }
        }
        */
    }
}
