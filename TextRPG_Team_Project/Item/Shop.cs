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
            new Weapon("무기1", 100, 0, false, 5),
            new Weapon("무기2", 200, 0, false, 10),
            new Weapon("무기3", 500, 0, false, 15),
            new Weapon("무기4", 1000, 0, false, 20)
        };
        public Armor[] armorArr = {
            new Armor("기본옷", 0, 1, true, 0),
            new Armor("아머1", 100, 0, false, 5),
            new Armor("아머2", 200, 0, false, 10),
            new Armor("아머3", 500, 0, false, 15),
            new Armor("아머4", 1000, 0, false, 20)
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

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("무기 가방");
                    DisplayCharacterWeaponInventory();
                    WeaponEquipment();
                    break;
                case 2:
                    Console.WriteLine("방어구 가방");
                    DisplayCharacterArmorInventory();
                    ArmorEquipment();
                    break;
                case 3:
                    Console.WriteLine("물약 가방");
                    DisplayCharacterPotionInventory();
                    break;
            }
        }

        // 인벤토리 메서드

        void DisplayCharacterWeaponInventory()
        {
            CharacterInventoryReset();
            Console.WriteLine("===무기 가방===");
            Console.WriteLine(" |이름|\t공격력|\t가격|  소지수");

            for (int i = 1; i < character.Weapon.Count; i++)
            {
                DisplayWeaponInventory(i);
            }
            Console.WriteLine("==========");
            Console.WriteLine();
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

        void WeaponEquipment()
        {
            Console.WriteLine("어떤 무기 장착? (0 눌러 취소)");
            int tempInput = int.Parse(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput > character.Weapon.Count)
                {
                    if (!character.Weapon[tempInput].IsEquipped)
                    {
                        character.Weapon[tempInput].EquipThis(character);
                    }
                    else
                    {
                        character.Weapon[tempInput].UnEquipThis(character);
                    }
                }
                else
                {
                    Console.WriteLine("올바른 값 입력");
                }
            }
            else
            {
                Console.WriteLine("나갑니다.");
            }
        }

        void DisplayCharacterArmorInventory()
        {
            CharacterInventoryReset();
            Console.WriteLine("==방어구 가방==");
            Console.WriteLine(" |이름|\t방어력|\t가격|  소지수");

            for (int i = 1; i < character.armor.Count; i++)
            {
                DisplayArmorInventory(i);
            }
            Console.WriteLine("==========");
            Console.WriteLine();
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

        void ArmorEquipment()
        {
            Console.WriteLine("어떤 방어구 장착? (0 눌러 취소)");
            int tempInput = int.Parse(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput > character.armor.Count)
                {
                    if (!character.armor[tempInput].IsEquipped)
                    {
                        character.armor[tempInput].EquipThis(character);
                    }
                    else
                    {
                        character.armor[tempInput].UnEquipThis(character);
                    }
                }
                else
                {
                    Console.WriteLine("올바른 값 입력");
                }
            }
            else
            {
                Console.WriteLine("나갑니다.");
            }
        }

        void DisplayCharacterPotionInventory()
        {
            CharacterInventoryReset();
            Console.WriteLine("===물약 가방===");
            Console.WriteLine(" |이름|\t효과|\t가격|  소지수");
            for (int i = 0; i < character.potion.Count; i++)
            {
                DisplayPotionInventory(i);
            }

            Console.WriteLine("==========");
            Console.WriteLine();
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

        // 상점 메서드

        void WeaponShop()
        {
            DisplayWeaponShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    weaponArr[tempInput].BuyThis(character);
                    break;
            }
        }

        void DisplayWeaponShopArr()
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

        void ArmorShop()
        {
            DisplayArmorShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    armorArr[tempInput].BuyThis(character);
                    break;
            }
        }

        void DisplayArmorShopArr()
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

        void PotionShop()
        {
            DisplayPotionShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    potionArr[tempInput].BuyThis(character);
                    break;
            }
        }

        void DisplayPotionShopArr()
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


        void SellItems()
        {
            Console.WriteLine("어떤 물건 판매?");
            Console.WriteLine("1. 무기");
            Console.WriteLine("2. 방어구");
            Console.WriteLine("3. 물약");

            CharacterInventoryReset(); Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("무기 판매");
                    SellWeapons();
                    break;
                case 2:
                    Console.WriteLine("방어구 판매");
                    SellArmors();
                    break;
                case 3:
                    Console.WriteLine("물약 판매");
                    SellPotions();
                    break;
            }
        }

        void SellWeapons()
        {
            DisplayWeaponShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    weaponArr[tempInput].SellThis(character);
                    break;
            }
        }

        void SellArmors()
        {
            DisplayArmorShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    armorArr[tempInput].SellThis(character);
                    break;
            }
        }

        void SellPotions()
        {
            DisplayPotionShopArr();

            Console.Write("디버그 선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    potionArr[tempInput].SellThis(character);
                    break;
            }
        }

        void CharacterInventoryReset()
        {
            character.Weapon.Clear();
            character.armor.Clear();
            character.potion.Clear();

            CharacterInventoryCheck();
        }

        public void DebugInventory()
        {
            // 디버깅 원할 시 원하는 Shop shop = new Shop();
            // 추가 후 shop.DebugInventory(); 로 본 메서드 출력 가능
            while (true)
            {
                Console.WriteLine("인벤토리 디버그 시작");
                Console.WriteLine("1. 인벤토리 출력 테스트");
                Console.WriteLine("2. 무기 상점 테스트");
                Console.WriteLine("3. 방어구 상점 테스트");
                Console.WriteLine("4. 물약 상점 테스트");
                Console.WriteLine("5. 판매 테스트");
                Console.Write("디버그 선택: ");
                int tempInput = int.Parse(Console.ReadLine());

                switch (tempInput)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("인벤토리 출력");
                        DisplayCharacterInventory();
                        break;
                    case 2:
                        Console.WriteLine("무기 상점");
                        WeaponShop();
                        break;
                    case 3:
                        Console.WriteLine("방어구 상점");
                        ArmorShop();
                        break;
                    case 4:
                        Console.WriteLine("물약 상점");
                        PotionShop();
                        break;
                    case 5:
                        Console.WriteLine("아이템 판매");
                        SellItems();
                        break;

                }
                if (tempInput == 0)
                {
                    break;
                }
            }
            Console.WriteLine("인벤토리 디버그 종료");
        }

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
    }
}
