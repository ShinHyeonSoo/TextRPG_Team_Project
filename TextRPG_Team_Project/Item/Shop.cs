﻿using System.ComponentModel.Design;
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

        int ShopSelect(string input)
        {
            int result;
            bool tempInput = int.TryParse(input, out result);

            if (!tempInput)
            {
                Console.WriteLine("제대로된 값을 입력해주세요.");
            }

            return result;
        }

        void DisplayCharacterInventoryUI()
        {
            Console.Clear();
            Console.WriteLine("=====가방=====");
            DisplayCharacterInventory("무기");
            DisplayCharacterInventory("방어구");
            DisplayCharacterInventory("물약");
            Console.WriteLine("==========");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"1. 무기 장착 관리");
            Console.WriteLine($"2. 방어구 장착 관리");

            Console.Write("선택: ");
            int tempInput = ShopSelect(Console.ReadLine());

            switch (tempInput)
            {
                case 0:
                    break;
                case 1:
                    Console.Clear();
                    DisplayCharacterInventory("무기");
                    WeaponEquipment();
                    break;
                case 2:
                    Console.Clear();
                    DisplayCharacterInventory("방어구");
                    ArmorEquipment();
                    break;
            }

        }

        // 인벤토리 메서드

        void DisplayCharacterInventory(string inventoryType)
        {
            string inventoryTitle;
            string itemStat;
            int inventoryCount;

            CharacterInventoryCheck();
            if (inventoryType == "무기")
            {
                inventoryTitle = "무기";
                itemStat = "공격력";
                inventoryCount = character.Weapon.Count;
            }
            else if (inventoryType == "방어구")
            {
                inventoryTitle = "방어구";
                itemStat = "방어력";
                inventoryCount = character.armor.Count;
            }
            else if (inventoryType == "물약")
            {
                inventoryTitle = "물약";
                itemStat = "효과";
                inventoryCount = character.potion.Count;
            }
            else
            {
                inventoryTitle = "????";
                itemStat = "????";
                inventoryCount = 1;
            }

            Console.WriteLine($"==={inventoryTitle} 가방===");
            Console.WriteLine($" |이름\t\t|\t{itemStat}|\t   가격|    소지수");

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
            }
            Console.WriteLine("==========");
            Console.WriteLine();
        }

        void DisplayWeaponInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string isEquipped;
            if (character.Weapon[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "";
            }

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

            Console.WriteLine($"{indexNumber}|{isEquipped} {weaponName}\t|\t  + {WeaponAttack}|\t {weaponPrice} G|  {weaponCount}|");
        }

        void WeaponEquipment()
        {
            Console.WriteLine("어떤 무기 장착? (0 눌러 취소)");
            int tempInput = ShopSelect(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Weapon.Count)
                {
                    if (!character.Weapon[tempInput].IsEquipped)
                    {
                        for (int i = 0; i < character.Weapon.Count; i++)
                        {
                            if (character.Weapon[i].IsEquipped)
                            {
                                character.Weapon[i].IsEquipped = false;
                            }
                        }
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

        void DisplayArmorInventory(int indexNum)
        {
            string indexNumber = $"{indexNum}";
            string isEquipped;
            if (character.armor[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "";
            }
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

            //Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
            Console.WriteLine($"{indexNumber}|{isEquipped} {armorName}\t|\t  + {armorDefence}|\t {armorPrice} G|  {armorCount}|");
        }

        void ArmorEquipment()
        {
            Console.WriteLine("어떤 방어구 장착? (0 눌러 취소)");
            int tempInput = ShopSelect(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.armor.Count)
                {
                    if (!character.armor[tempInput].IsEquipped)
                    {
                        for (int i = 0; i < character.armor.Count; i++)
                        {
                            if (character.armor[i].IsEquipped)
                            {
                                character.armor[i].IsEquipped = false;
                            }
                        }
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

            Console.WriteLine($"{indexNumber}|{potionName}\t|\t+ {potionEffect}|  {potionCount}|");
        }

        // 상점 메서드

        void DisplayShop(string shopType)
        {
            string ShopTitle;
            int inventoryCount;

            CharacterInventoryCheck();
            if (shopType == "무기")
            {
                ShopTitle = "무기";
                inventoryCount = character.Weapon.Count;
            }
            else if (shopType == "방어구")
            {
                ShopTitle = "방어구";
                inventoryCount = character.armor.Count;
            }
            else if (shopType == "물약")
            {
                ShopTitle = "물약";
                inventoryCount = character.potion.Count;
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
            int tempInput = ShopSelect(Console.ReadLine());

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
                shopCount = itemDB.weaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopTitle = "방어구";
                itemStat = "방어력";
                shopCount = itemDB.armorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopTitle = "물약";
                itemStat = "효과";
                shopCount = itemDB.potionDict.Count;
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
            Console.WriteLine($" |이름\t\t|\t{itemStat}|\t   가격|    소지수");
            Console.WriteLine("------------------------------------------------------");
            for (int i = 1; i < shopCount; i++)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weapon = itemDB.weaponDict.ElementAt(i);
                    DisplayWeapon(weapon.Key, i);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armor = itemDB.armorDict.ElementAt(i);
                    DisplayArmor(armor.Key, i);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potion = itemDB.potionDict.ElementAt(i);
                    DisplayPotion(potion.Key, i);
                }
                else Console.WriteLine("뭔가 잘못됨");

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


        void BuyItems(string shopType)
        {
            int shopCount;

            if (shopType == "무기")
            {
                shopCount = itemDB.weaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopCount = itemDB.armorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopCount = itemDB.potionDict.Count;
            }
            else
            {
                shopCount = 1;
            }

            Console.Write("구입할 물건 선택 (0 눌러 나가기)\n>> ");

            int tempInput = ShopSelect(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("상점을 나갑니다.");
            }
            else if (tempInput < shopCount)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weaponBought = itemDB.weaponDict.ElementAt(tempInput);
                    itemDB.weaponDict[weaponBought.Key].BuyThis(character);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armorBought = itemDB.armorDict.ElementAt(tempInput);
                    itemDB.armorDict[armorBought.Key].BuyThis(character);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potionBought = itemDB.potionDict.ElementAt(tempInput);
                    itemDB.potionDict[potionBought.Key].BuyThis(character);
                }
                else
                {
                    Console.WriteLine("잘못된 값");
                    Console.ReadLine();
                }
            }
        }
        // 판매 메서드

        void SellItems(string shopType)
        {
            int shopCount;

            if (shopType == "무기")
            {
                shopCount = itemDB.weaponDict.Count;
            }
            else if (shopType == "방어구")
            {
                shopCount = itemDB.armorDict.Count;
            }
            else if (shopType == "물약")
            {
                shopCount = itemDB.potionDict.Count;
            }
            else
            {
                shopCount = 1;
            }

            Console.Write("판매할 아이템 선택 (0 눌러 취소) \n>>");

            int tempInput = ShopSelect(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("상점을 나갑니다.");
            }
            else if (tempInput < shopCount)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weaponBought = itemDB.weaponDict.ElementAt(tempInput);
                    itemDB.weaponDict[weaponBought.Key].SellThis(character);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armorBought = itemDB.armorDict.ElementAt(tempInput);
                    itemDB.armorDict[armorBought.Key].SellThis(character);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potionBought = itemDB.potionDict.ElementAt(tempInput);
                    itemDB.potionDict[potionBought.Key].SellThis(character);
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
            // 디버깅 원할 시 원하는 Shop shop = new Shop();
            // 추가 후 shop.DebugInventory(); 로 본 메서드 출력 가능
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 디버그 시작");
                Console.WriteLine("1. 인벤토리 출력 테스트");
                Console.WriteLine("2. 무기 상점 테스트");
                Console.WriteLine("3. 방어구 상점 테스트");
                Console.WriteLine("4. 물약 상점 테스트");
                Console.WriteLine("6. 1만 골드 추가");
                Console.Write("디버그 선택: ");
                int tempInput = ShopSelect(Console.ReadLine());

                switch (tempInput)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("인벤토리 출력");
                        DisplayCharacterInventoryUI();
                        break;
                    case 2:
                        Console.WriteLine("무기 상점");
                        DisplayShop("무기");
                        break;
                    case 3:
                        Console.WriteLine("방어구 상점");
                        DisplayShop("방어구");
                        break;
                    case 4:
                        Console.WriteLine("물약 상점");
                        DisplayShop("물약");
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
            Console.Clear();
            Console.WriteLine("인벤토리 디버그 종료");
        }

        void CharacterInventoryCheck()
        {
            // weapon check
            foreach (var weapon in itemDB.weaponDict.Values)
            {
                if (!character.Weapon.Contains(weapon))
                {
                    if (weapon.ItemCount > 0)
                    {
                        character.Weapon.Add(weapon);
                    }
                    else
                    {
                        character.Weapon.Remove(weapon);
                    }
                }
            }
            // armor check
            foreach (var armor in itemDB.armorDict.Values)
            {
                if (!character.armor.Contains(armor))
                {
                    if (armor.ItemCount > 0)
                    {
                        character.armor.Add(armor);
                    }
                    else
                    {
                        character.armor.Remove(armor);
                    }
                }
            }
            // potion check
            foreach (var potion in itemDB.potionDict.Values)
            {
                if (!character.potion.Contains(potion))
                {
                    if (potion.ItemCount > 0)
                    {
                        character.potion.Add(potion);
                    }
                    else
                    {
                        character.potion.Remove(potion);
                    }
                }
            }
        }
    }
}
