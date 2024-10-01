using System.Linq;
using TextRPG_Team_Project.Database;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Item
{
    public class Shop
    {
        Character character = GameManager.Instance.Data.GetPlayer();
        ItemDatabase itemDB = GameManager.Instance.Data.ItemDatabase;

        void DisplayCharacterInventory()
        {
            Console.WriteLine("=====가방=====");
            Console.WriteLine("1. 무기 가방");
            Console.WriteLine("2. 방어구 가방");
            Console.WriteLine("3. 물약 가방");
            Console.WriteLine("==========");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.Write("선택: ");
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
            CharacterInventoryCheck();
            Console.WriteLine("===무기 가방===");
            Console.WriteLine(" |이름\t\t|\t공격력|\t   가격|    소지수");

            for (int i = 1; i < character.Weapon.Count; i++)
            {
<<<<<<< Updated upstream
                DisplayWeaponInventory(i);
=======
                inventoryTitle = "무기";
                itemStat = "공격력";
                inventoryCount = character.Weapons.Count;
            }
            else if (inventoryType == "방어구")
            {
                inventoryTitle = "방어구";
                itemStat = "방어력";
                inventoryCount = character.Armors.Count;
            }
            else if (inventoryType == "물약")
            {
                inventoryTitle = "물약";
                itemStat = "효과";
                inventoryCount = character.Potions.Count;
            }
            else
            {
                inventoryTitle = "????";
                itemStat = "????";
                inventoryCount = 1;
            }

            Console.WriteLine($"==={inventoryTitle} 가방===");
            Console.WriteLine($"    | 이름\t\t |  {itemStat}|    소지수|");

            for (int i = 1; i < inventoryCount; i++)
            {
                if (inventoryType == "무기")
                {
                    DisplayWeaponInventory(i);
                }
                else if (inventoryType == "방어구")
                {
                    DisplayArmorInventory(i);
                }
                else if (inventoryType == "물약")
                {
                    DisplayPotionInventory(i);
                }
                else Console.WriteLine("뭔가 잘못됨");
>>>>>>> Stashed changes
            }
            Console.WriteLine("==========");
            Console.WriteLine();
        }

        void DisplayWeaponInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string isEquipped;
            if (character.Weapons[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            } 
            else
            {
                isEquipped = "";
            }
<<<<<<< Updated upstream
                
            string weaponName = $"{character.Weapon[indexNum].Name}";
            string weaponPrice = $"{character.Weapon[indexNum].ItemPrice}";
=======

            string weaponName = $"{character.Weapons[indexNum].Name}";
            string weaponPrice = character.Weapons[indexNum].ItemPrice.ToString("D4");
>>>>>>> Stashed changes
            string weaponCount;
            if (character.Weapons[indexNum].ItemCount < character.Weapons[indexNum].ItemCountMax)
            {
                weaponCount = $"{character.Weapons[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
<<<<<<< Updated upstream
            string WeaponAttack = $"{character.Weapon[indexNum].WeaponAttack}";
=======
            string WeaponAttack = ((int)(character.Weapons[indexNum].WeaponAttack)).ToString("D2");
>>>>>>> Stashed changes

            Console.WriteLine($"{indexNumber}|{isEquipped} {weaponName}\t|\t  + {WeaponAttack}|\t {weaponPrice} G|  {weaponCount}|");
        }

        void WeaponEquipment()
        {
            Console.WriteLine("어떤 무기 장착? (0 눌러 취소)");
            int tempInput = int.Parse(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Weapons.Count)
                {
                    if (!character.Weapons[tempInput].IsEquipped)
                    {
<<<<<<< Updated upstream
                        for(int i = 0; i < character.Weapon.Count;i++)
                        {
                            if(character.Weapon[i].IsEquipped)
=======
                        for (int i = 0; i < character.Weapons.Count; i++)
                        {
                            if (character.Weapons[i].IsEquipped)
>>>>>>> Stashed changes
                            {
                                character.Weapons[i].IsEquipped = false;
                            }
                        }
                        character.Weapons[tempInput].EquipThis(character);
                    }
                    else
                    {
                        character.Weapons[tempInput].UnEquipThis(character);
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
            CharacterInventoryCheck();
            Console.WriteLine("==방어구 가방==");
            Console.WriteLine(" |이름\t\t|\t방어력|\t   가격|    소지수");

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
            string isEquipped;
            if (character.Armors[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "";
            }
<<<<<<< Updated upstream
            string armorName = $"{character.armor[indexNum].Name}";
            string armorPrice = $"{character.armor[indexNum].ItemPrice}";
=======
            string armorName = $"{character.Armors[indexNum].Name}";
            string armorPrice = character.Armors[indexNum].ItemPrice.ToString("D4");
>>>>>>> Stashed changes
            string armorCount;
            if (character.Armors[indexNum].ItemCount < character.Armors[indexNum].ItemCountMax)
            {
                armorCount = $"{character.Armors[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
<<<<<<< Updated upstream
            string armorDefence = $"{character.armor[indexNum].ArmorDefence}";
=======
            string armorDefence = character.Armors[indexNum].ArmorDefence.ToString("D2");
>>>>>>> Stashed changes

            //Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
            Console.WriteLine($"{indexNumber}|{isEquipped} {armorName}\t|\t  + {armorDefence}|\t {armorPrice} G|  {armorCount}|");
        }

        void ArmorEquipment()
        {
            Console.WriteLine("어떤 방어구 장착? (0 눌러 취소)");
            int tempInput = int.Parse(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Armors.Count)
                {
                    if (!character.Armors[tempInput].IsEquipped)
                    {
                        for (int i = 0; i < character.Armors.Count; i++)
                        {
                            if (character.Armors[i].IsEquipped)
                            {
                                character.Armors[i].IsEquipped = false;
                            }
                        }
                        character.Armors[tempInput].EquipThis(character);
                    }
                    else
                    {
                        character.Armors[tempInput].UnEquipThis(character);
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
            CharacterInventoryCheck();
            Console.WriteLine("===물약 가방===");
            Console.WriteLine(" |이름\t\t|\t효과|    소지수");
            for (int i = 0; i < character.potion.Count; i++)
            {
                DisplayPotionInventory(i);
            }
            // 디버그용 코드
            if(character.potion.Count > 0)
                character.potion[0].ConsumeThis(character);
            else 
                Console.WriteLine("물약이 없습니다.");
            // 코드 끝
            Console.WriteLine("==========");
            Console.WriteLine();
        }

        void DisplayPotionInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
<<<<<<< Updated upstream
            string potionName = $"{character.potion[indexNum].Name}";
            string potionPrice = $"{character.potion[indexNum].ItemPrice}";
=======
            string potionName = $"{character.Potions[indexNum].Name}";
            string potionPrice = character.Potions[indexNum].ItemPrice.ToString("D4");
>>>>>>> Stashed changes
            string potionCount;
            if (character.Potions[indexNum].ItemCount < character.Potions[indexNum].ItemCountMax)
            {
                potionCount = $"{character.Potions[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
<<<<<<< Updated upstream
            string potionEffect = $"{character.potion[indexNum].PotionEffect}";
                        
            Console.WriteLine($"{indexNumber}|{potionName}\t|\t+ {potionEffect}|  {potionCount}|");
        }
=======
            string potionEffect = $"{character.Potions[indexNum].PotionEffect}";
>>>>>>> Stashed changes

        // 상점 메서드

        void WeaponShop()
        {
            DisplayWeaponShopArr();

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    KeyValuePair<string, Weapon> weapon = itemDB.weaponDict.ElementAt(tempInput);
                    itemDB.weaponDict[weapon.Key].BuyThis(character);
                    break;
            }
        }

        void DisplayWeaponShopArr()
        {
            Console.WriteLine("==무기상점==");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"=====================================================");
            Console.WriteLine(" |이름\t\t|\t공격력|\t   가격|    소지수");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 1; i < itemDB.weaponDict.Count; i++)
            {
                KeyValuePair<string, Weapon> weapon = itemDB.weaponDict.ElementAt(i);
                DisplayWeapon(weapon.Key, i);
            }
            Console.WriteLine("========");
        }

        void DisplayWeapon(string weaponKey, int i)
        {
            string indexNumber = $"{i}";
            string weaponName = $"{itemDB.weaponDict[weaponKey].Name}";
            string weaponPrice = itemDB.weaponDict[weaponKey].ItemPrice.ToString("D4");
            string weaponCount;
            if (itemDB.weaponDict[weaponKey].ItemCount < itemDB.weaponDict[weaponKey].ItemCountMax)
            {
                weaponCount = $"{itemDB.weaponDict[weaponKey].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = ((int)(itemDB.weaponDict[weaponKey].WeaponAttack)).ToString("D2");

            Console.WriteLine($"{indexNumber}|{weaponName}\t|\t  + {WeaponAttack}|\t {weaponPrice} G|  {weaponCount}|");
        }


        void ArmorShop()
        {
            DisplayArmorShopArr();

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    KeyValuePair<string, Armor> armor = itemDB.armorDict.ElementAt(tempInput);
                    itemDB.armorDict[armor.Key].BuyThis(character);
                    break;
            }
        }

        void DisplayArmorShopArr()
        {
            Console.WriteLine("==방어구상점==");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"=====================================================");
            Console.WriteLine(" |이름\t\t|\t방어력|\t   가격|    소지수");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 1; i < itemDB.armorDict.Count; i++)
            {
                KeyValuePair<string, Armor> armor = itemDB.armorDict.ElementAt(i);
                DisplayArmor(armor.Key, i);
            }
            Console.WriteLine("========");
        }

        void DisplayArmor(string armorKey, int i)
        {
            string indexNumber = $"{i}";
            string armorName = $"{itemDB.armorDict[armorKey].Name}";
            string armorPrice = itemDB.armorDict[armorKey].ItemPrice.ToString("D4");
            string armorCount;
            if (itemDB.armorDict[armorKey].ItemCount < itemDB.armorDict[armorKey].ItemCountMax)
            {
                armorCount = $"{itemDB.armorDict[armorKey].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = itemDB.armorDict[armorKey].ArmorDefence.ToString("D2");

            Console.WriteLine($"{indexNumber}|{armorName}\t|\t  + {armorDefence}|\t {armorPrice} G|  {armorCount}|");
        }


        void PotionShop()
        {
            DisplayPotionShopArr();

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    KeyValuePair<string, Potion> potion = itemDB.potionDict.ElementAt(tempInput);
                    itemDB.potionDict[potion.Key].BuyThis(character);
                    break;
            }
        }

        void DisplayPotionShopArr()
        {
            Console.WriteLine("==물약상점==");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"=====================================================");
            Console.WriteLine(" |이름\t\t|\t효과|\t   가격|    소지수");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 1; i < itemDB.potionDict.Count; i++)
            {
                KeyValuePair<string, Potion> potion = itemDB.potionDict.ElementAt(i);
                DisplayPotion(potion.Key, i);
            }
            Console.WriteLine("========");
        }

        void DisplayPotion(string potionKey, int i)
        {
            string indexNumber = $"{i}";
            string potionName = $"{itemDB.potionDict[potionKey].Name}";
            string potionPrice = $"{itemDB.potionDict[potionKey].ItemPrice}";
            string potionCount;
            if (itemDB.potionDict[potionKey].ItemCount < itemDB.potionDict[potionKey].ItemCountMax)
            {
                potionCount = $"{itemDB.potionDict[potionKey].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{itemDB.potionDict[potionKey].PotionEffect}";

            Console.WriteLine($"{indexNumber}|{potionName}\t|\t+ {potionEffect}|\t   {potionPrice} G|  {potionCount}|");
        }


        // 판매 메서드

        void SellItems()
        {
            Console.WriteLine("어떤 물건 판매?");
            Console.WriteLine("1. 무기");
            Console.WriteLine("2. 방어구");
            Console.WriteLine("3. 물약");

            CharacterInventoryCheck();
            Console.Write("선택: ");
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

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    KeyValuePair<string, Weapon> weapon = itemDB.weaponDict.ElementAt(tempInput);
                    itemDB.weaponDict[weapon.Key].SellThis(character);
                    break;
            }
        }

        void SellArmors()
        {
            DisplayArmorShopArr();

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    KeyValuePair<string, Armor> armor = itemDB.armorDict.ElementAt(tempInput);
                    itemDB.armorDict[armor.Key].SellThis(character);
                    break;
            }
        }

        void SellPotions()
        {
            DisplayPotionShopArr();

            Console.Write("선택: ");
            int tempInput = int.Parse(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    KeyValuePair<string, Potion> potion = itemDB.potionDict.ElementAt(tempInput);
                    itemDB.potionDict[potion.Key].SellThis(character);
                    break;
            }
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
                Console.WriteLine("6. 1만 골드 추가");
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
                    case 6:
                        Console.WriteLine("1만 골드 획득");
                        character.Gold += 10000;
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
<<<<<<< Updated upstream
            foreach ( var weapon in itemDB.weaponDict.Values)
            {
                if(!character.Weapon.Contains(weapon))
=======
            foreach (var weapon in itemDB.WeaponDict.Values)
            {
                if (!character.Weapons.Contains(weapon)) 
>>>>>>> Stashed changes
                {
                    if (weapon.ItemCount > 0)
                    {
                        character.Weapons.Add(weapon);
                    }
<<<<<<< Updated upstream
=======
                }
                else
                {
                    if (weapon.ItemCount > 0)
                    {
                        int itemIndex = character.Weapons.IndexOf(weapon);
                        character.Weapons[itemIndex].ItemCount = weapon.ItemCount;
                    }
>>>>>>> Stashed changes
                    else
                    {
                        character.Weapons.Remove(weapon);
                    }
                }
            }
            // armor check
            foreach (var armor in itemDB.ArmorDict.Values)
            {
                if (!character.Armors.Contains(armor))
                {
                    if (armor.ItemCount > 0)
                    {
                        character.Armors.Add(armor);
                    }
                    else
                    {
                        character.Armors.Remove(armor);
                    }
                }
<<<<<<< Updated upstream
=======
                else
                {
                    if (armor.ItemCount > 0)
                    {
                        int itemIndex = character.Armors.IndexOf(armor);
                        character.Armors[itemIndex].ItemCount = armor.ItemCount;
                    }
                    else
                    {
                        character.Armors.Remove(armor);
                    }
                }
>>>>>>> Stashed changes
            }
            // potion check
            foreach (var potion in itemDB.PotionDict.Values)
            {
                if (!character.Potions.Contains(potion))
                {
                    if (potion.ItemCount > 0)
                    {
                        character.Potions.Add(potion);
                    }
                    else
                    {
                        character.Potions.Remove(potion);
                    }
                }
<<<<<<< Updated upstream
            }
        }
=======
                else
                {
                    if (potion.ItemCount > 0)
                    {
                        int itemIndex = character.Potions.IndexOf(potion);
                        character.Potions[itemIndex].ItemCount = potion.ItemCount;
                    }
                    else
                    {
                        character.Potions.Remove(potion);
                    }
                }
            }
        }

        // 이하 상점 메서드

        public void DisplayShopUI()
        {
            Console.WriteLine("어떤 상점에 갑니까?");
            Console.WriteLine("==========");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"1. 무기 상점");
            Console.WriteLine($"2. 방어구 상점");
            Console.WriteLine($"3. 물약 상점");

            Console.Write("선택: ");
            int tempInput = ShopInput(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    Console.Clear();
                    DisplayShop("무기");
                    break;
                case 2:
                    Console.Clear();
                    DisplayShop("방어구");
                    break;
                case 3:
                    DisplayShop("물약");
                    break;
                default:
                    Console.WriteLine("제대로 된 값을 입력해주세요.");
                    break;
            }
        }

        void DisplayShop(string shopType)
        {
            string ShopTitle;
            int inventoryCount;

            if (shopType == "무기")
            {
                ShopTitle = "무기";
                inventoryCount = character.Weapons.Count;
            }
            else if (shopType == "방어구")
            {
                ShopTitle = "방어구";
                inventoryCount = character.Weapons.Count;
            }
            else if (shopType == "물약")
            {
                ShopTitle = "물약";
                inventoryCount = character.Weapons.Count;
            }
            else
            {
                ShopTitle = "????";
                inventoryCount = 1;
            }
            DisplayShopItems(shopType);

            Console.WriteLine($"{ShopTitle} 상점에서 뭘 하나요?");
            Console.WriteLine($"1. 구입");
            Console.WriteLine($"2. 판매");
            int tempInput = ShopInput(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("나가기");
            }
            else if (tempInput == 1)
            {
                BuyItems(shopType);
            }
            else if (tempInput == 2)
            {
                SellItems(shopType);
            }
            else
            {
                Console.WriteLine("잘못된 입력");
                Console.ReadLine();
            }
        }

        void DisplayShopItems(string shopType)
        {
            string shopTitle;
            string itemStat;
            int shopCount;

            if (shopType == "무기")
            {
                shopTitle = "무기";
                itemStat = "공격력";
                shopCount = itemDB.WeaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopTitle = "방어구";
                itemStat = "방어력";
                shopCount = itemDB.ArmorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopTitle = "물약";
                itemStat = "효과";
                shopCount = itemDB.PotionDict.Count;
            }
            else    // 잘못된 입력시
            {
                shopTitle = "????";
                itemStat = "????";
                shopCount = 1;
            }

            Console.WriteLine($"=={shopTitle} 상점==");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"=====================================================");
            Console.WriteLine($" | 이름 \t\t| {itemStat}|   가격|    소지수|");
            Console.WriteLine("-----------------------------------------------------");
            for (int i = 1; i < shopCount; i++)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weapon = itemDB.WeaponDict.ElementAt(i);
                    DisplayWeaponShop(weapon.Key, i);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armor = itemDB.ArmorDict.ElementAt(i);
                    DisplayArmorShop(armor.Key, i);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potion = itemDB.PotionDict.ElementAt(i);
                    DisplayPotionShop(potion.Key, i);
                }
                else Console.WriteLine("뭔가 잘못됨");

            }
            Console.WriteLine("========");
        }

        void DisplayWeaponShop(string weaponKey, int i)
        {
            string indexNumber = $"{i}";
            string weaponName = $"{itemDB.WeaponDict[weaponKey].Name}";
            string weaponPrice = itemDB.WeaponDict[weaponKey].ItemPrice.ToString("D4");
            string weaponCount;
            if (itemDB.WeaponDict[weaponKey].ItemCount < itemDB.WeaponDict[weaponKey].ItemCountMax)
            {
                weaponCount = $"{itemDB.WeaponDict[weaponKey].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = ((int)(itemDB.WeaponDict[weaponKey].WeaponAttack)).ToString("D2");

            Console.WriteLine($"{indexNumber}| {weaponName} \t|   + {WeaponAttack}| {weaponPrice} G|  {weaponCount}|");
        }

        void DisplayArmorShop(string armorKey, int i)
        {
            string indexNumber = $"{i}";
            string armorName = $"{itemDB.ArmorDict[armorKey].Name}";
            string armorPrice = itemDB.ArmorDict[armorKey].ItemPrice.ToString("D4");
            string armorCount;
            if (itemDB.ArmorDict[armorKey].ItemCount < itemDB.ArmorDict[armorKey].ItemCountMax)
            {
                armorCount = $"{itemDB.ArmorDict[armorKey].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = itemDB.ArmorDict[armorKey].ArmorDefence.ToString("D2");

            Console.WriteLine($"{indexNumber}| {armorName} \t|   + {armorDefence}| {armorPrice} G|  {armorCount}|");
        }

        void DisplayPotionShop(string potionKey, int i)
        {
            string indexNumber = $"{i}";
            string potionName = $"{itemDB.PotionDict[potionKey].Name}";
            string potionPrice = $"{itemDB.PotionDict[potionKey].ItemPrice}";
            string potionCount;
            if (itemDB.PotionDict[potionKey].ItemCount < itemDB.PotionDict[potionKey].ItemCountMax)
            {
                potionCount = $"{itemDB.PotionDict[potionKey].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{itemDB.PotionDict[potionKey].PotionEffect}";

            Console.WriteLine($"{indexNumber}| {potionName}\t| + {potionEffect}|   {potionPrice} G|  {potionCount}|");
        }

        void BuyItems(string shopType)
        {
            int shopCount;

            if (shopType == "무기")
            {
                shopCount = itemDB.WeaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopCount = itemDB.ArmorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopCount = itemDB.PotionDict.Count;
            }
            else
            {
                shopCount = 1;
            }

            Console.Write("구입할 물건 선택 (0 눌러 나가기)\n>> ");

            int tempInput = ShopInput(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("상점을 나갑니다.");
                Console.ReadLine();
            }
            else if (tempInput < shopCount)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weaponBought = itemDB.WeaponDict.ElementAt(tempInput);
                    itemDB.WeaponDict[weaponBought.Key].BuyThis(character);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armorBought = itemDB.ArmorDict.ElementAt(tempInput);
                    itemDB.ArmorDict[armorBought.Key].BuyThis(character);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potionBought = itemDB.PotionDict.ElementAt(tempInput);
                    itemDB.PotionDict[potionBought.Key].BuyThis(character);
                }
                else
                {
                    Console.WriteLine("잘못된 값");
                    Console.ReadLine();
                }
            }
        }

        void SellItems(string shopType)
        {
            int shopCount;

            if (shopType == "무기")
            {
                shopCount = itemDB.WeaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopCount = itemDB.ArmorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopCount = itemDB.PotionDict.Count;
            }
            else
            {
                shopCount = 1;
            }

            Console.Write("판매할 아이템 선택 (0 눌러 취소) \n>>");

            int tempInput = ShopInput(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("상점을 나갑니다.");
            }
            else if (tempInput < shopCount)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weaponBought = itemDB.WeaponDict.ElementAt(tempInput);
                    itemDB.WeaponDict[weaponBought.Key].SellThis(character);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armorBought = itemDB.ArmorDict.ElementAt(tempInput);
                    itemDB.ArmorDict[armorBought.Key].SellThis(character);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potionBought = itemDB.PotionDict.ElementAt(tempInput);
                    itemDB.PotionDict[potionBought.Key].SellThis(character);
                }
                else
                {
                    Console.WriteLine("잘못된 값");
                    Console.ReadLine();
                }
            }
        }


        public void DebugInventory()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 디버그 시작");
                Console.WriteLine("1. 인벤토리 출력 테스트");
                Console.WriteLine("2. 상점 테스트");
                Console.WriteLine("3. 1만 골드 추가");
                Console.Write("디버그 선택: ");
                int tempInput = ShopInput(Console.ReadLine());

                switch (tempInput)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("인벤토리 출력");
                        DisplayCharacterInventoryUI();
                        break;
                    case 2:
                        Console.WriteLine("상점 출력");
                        DisplayShopUI();
                        break;
                    case 3:
                        Console.WriteLine("1만 골드 획득");
                        character.Gold += 10000;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력");
                        Console.ReadLine();
                        break;
                }
                if (tempInput == 0)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("인벤토리 디버그 종료");
        }
>>>>>>> Stashed changes
    }
}
