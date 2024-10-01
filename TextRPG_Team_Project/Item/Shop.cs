using System.ComponentModel.Design;
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

        int ShopInput(string input)
        {
            int result;
            bool tempInput = int.TryParse(input, out result);

            if (!tempInput)
            {
                Console.WriteLine("제대로된 값을 입력해주세요.");
            }

            return result;
        }

        // 이하 인벤토리 메서드

        public void DisplayCharacterInventoryUI()
        {
            CharacterInventoryCheck();

            Console.WriteLine("=====가방=====");

            DisplayCharacterInventory("무기");
            DisplayCharacterInventory("방어구");
            DisplayCharacterInventory("물약");

            Console.WriteLine("==========");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine($"1. 무기 장착 관리");
            Console.WriteLine($"2. 방어구 장착 관리");

            Console.Write("선택: ");
            int tempInput = ShopInput(Console.ReadLine());

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
                default:
                    Console.WriteLine("제대로된 값을 입력해주세요.");
                    break;
            }

        }

        void DisplayCharacterInventory(string inventoryType)
        {
            string inventoryTitle;
            string itemStat;
            int inventoryCount;

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
                inventoryCount = character.Armor.Count;
            }
            else if (inventoryType == "물약")
            {
                inventoryTitle = "물약";
                itemStat = "효과";
                inventoryCount = character.Potion.Count;
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
                isEquipped = "   ";
            }

            string weaponName = $"{character.Weapon[indexNum].Name}";
            string weaponPrice = character.Weapon[indexNum].ItemPrice.ToString("D4");
            string weaponCount;
            if (character.Weapon[indexNum].ItemCount < character.Weapon[indexNum].ItemCountMax)
            {
                weaponCount = $"{character.Weapon[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }
            string WeaponAttack = ((int)(character.Weapon[indexNum].WeaponAttack)).ToString("D2");

            Console.WriteLine($"{indexNumber}{isEquipped}| {weaponName}\t |    + {WeaponAttack}|  {weaponCount}|");
        }

        void WeaponEquipment()
        {
            Console.WriteLine("어떤 무기를 장착합니까?");
            Console.WriteLine("장착된 장비를 선택하면 장착해제합니다.(0 눌러 취소)");
            int tempInput = ShopInput(Console.ReadLine());
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
            if (character.Armor[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "   ";
            }
            string armorName = $"{character.Armor[indexNum].Name}";
            string armorPrice = character.Armor[indexNum].ItemPrice.ToString("D4");
            string armorCount;
            if (character.Armor[indexNum].ItemCount < character.Armor[indexNum].ItemCountMax)
            {
                armorCount = $"{character.Armor[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = character.Armor[indexNum].ArmorDefence.ToString("D2");

            //Console.WriteLine($"{indexNumber}|{armorName}|\t{armorDefence}|{armorPrice}G|{armorCount}|");
            Console.WriteLine($"{indexNumber}{isEquipped}| {armorName}\t |  + {armorDefence}|  {armorCount}|");
        }

        void ArmorEquipment()
        {
            Console.WriteLine("어떤 방어구를 장착합니까? (0 눌러 취소)");
            Console.WriteLine("장착된 장비를 선택하면 장착해제합니다.(0 눌러 취소)");
            int tempInput = ShopInput(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Armor.Count)
                {
                    if (!character.Armor[tempInput].IsEquipped)
                    {
                        for (int i = 0; i < character.Armor.Count; i++)
                        {
                            if (character.Armor[i].IsEquipped)
                            {
                                character.Armor[i].IsEquipped = false;
                            }
                        }
                        character.Armor[tempInput].EquipThis(character);
                    }
                    else
                    {
                        character.Armor[tempInput].UnEquipThis(character);
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
            string potionName = $"{character.Potion[indexNum].Name}";
            string potionPrice = character.Potion[indexNum].ItemPrice.ToString("D4");
            string potionCount;
            if (character.Potion[indexNum].ItemCount < character.Potion[indexNum].ItemCountMax)
            {
                potionCount = $"{character.Potion[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = $"{character.Potion[indexNum].PotionEffect}";

            Console.WriteLine($"{indexNumber}   | {potionName}\t\t|  + {potionEffect}|  {potionCount}|");
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
                }
                else
                {
                    if (weapon.ItemCount > 0)
                    {
                        int itemIndex = character.Weapon.IndexOf(weapon);
                        character.Weapon[itemIndex].ItemCount = weapon.ItemCount;
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
                if (!character.Armor.Contains(armor))
                {
                    if (armor.ItemCount > 0)
                    {
                        character.Armor.Add(armor);
                    }
                    else
                    {
                        character.Armor.Remove(armor);
                    }
                }
                else
                {
                    if (armor.ItemCount > 0)
                    {
                        int itemIndex = character.Armor.IndexOf(armor);
                        character.Armor[itemIndex].ItemCount = armor.ItemCount;
                    }
                    else
                    {
                        character.Armor.Remove(armor);
                    }
                }
            }
            // potion check
            foreach (var potion in itemDB.potionDict.Values)
            {
                if (!character.Potion.Contains(potion))
                {
                    if (potion.ItemCount > 0)
                    {
                        character.Potion.Add(potion);
                    }
                    else
                    {
                        character.Potion.Remove(potion);
                    }
                }
                else
                {
                    if (potion.ItemCount > 0)
                    {
                        int itemIndex = character.Potion.IndexOf(potion);
                        character.Potion[itemIndex].ItemCount = potion.ItemCount;
                    }
                    else
                    {
                        character.Potion.Remove(potion);
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
                inventoryCount = character.Weapon.Count;
            }
            else if (shopType == "방어구")
            {
                ShopTitle = "방어구";
                inventoryCount = character.Armor.Count;
            }
            else if (shopType == "물약")
            {
                ShopTitle = "물약";
                inventoryCount = character.Potion.Count;
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
            Console.WriteLine($" | 이름 \t\t| {itemStat}|   가격|    소지수|");
            Console.WriteLine("-----------------------------------------------------");
            for (int i = 1; i < shopCount; i++)
            {
                if (shopType == "무기")
                {
                    KeyValuePair<string, Weapon> weapon = itemDB.weaponDict.ElementAt(i);
                    DisplayWeaponShop(weapon.Key, i);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armor = itemDB.armorDict.ElementAt(i);
                    DisplayArmorShop(armor.Key, i);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potion = itemDB.potionDict.ElementAt(i);
                    DisplayPotionShop(potion.Key, i);
                }
                else Console.WriteLine("뭔가 잘못됨");

            }
            Console.WriteLine("========");
        }

        void DisplayWeaponShop(string weaponKey, int i)
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

            Console.WriteLine($"{indexNumber}| {weaponName} \t|   + {WeaponAttack}| {weaponPrice} G|  {weaponCount}|");
        }

        void DisplayArmorShop(string armorKey, int i)
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

            Console.WriteLine($"{indexNumber}| {armorName} \t|   + {armorDefence}| {armorPrice} G|  {armorCount}|");
        }

        void DisplayPotionShop(string potionKey, int i)
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

            Console.WriteLine($"{indexNumber}| {potionName}\t| + {potionEffect}|   {potionPrice} G|  {potionCount}|");
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

            int tempInput = ShopInput(Console.ReadLine());

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
    }
}
