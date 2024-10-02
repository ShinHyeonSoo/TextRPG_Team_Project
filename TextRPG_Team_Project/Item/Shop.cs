using System.ComponentModel.Design;
using System.Data;
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
        InventoryScene scene = new InventoryScene();


        public static bool isReset = false;

        public void StartInventoryScene()
        {
            scene.DisplayIntro("인벤토리");
            Console.WriteLine();
            Console.WriteLine("보유한 아이템을 확인하거나 상점에서 구매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine();
            scene.DisplayOption(new List<string>() { "1. 인벤토리", "2. 상점" });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.Write(">> ");

            while (true)
            {
                string inputCheck = Console.ReadLine();
                int tempInput = ShopInput(inputCheck);

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
                    default:
                        Console.WriteLine("잘못된 입력");
                        Console.ReadLine();
                        break;
                }
                if (tempInput == 0)
                {
                    return;
                }
                break;
            }
            Console.Clear();

        }

        int ShopInput(string input)
        {
            int result = -1;
            bool tempInput = int.TryParse(input, out result);

            if (!tempInput)
            {
                Console.WriteLine("제대로된 값을 입력해주세요."); 
            }

            return result;
        }

        // 이하 인벤토리 메서드

        void DisplayCharacterInventoryUI()
        {
            scene.DisplayIntro("인벤토리");
            Console.WriteLine($"  ==============인 벤 토 리==============");

            DisplayCharacterInventory("무기");
            DisplayCharacterInventory("방어구");
            DisplayCharacterInventory("물약");

            Console.WriteLine("=============================================");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            scene.DisplayOption(new List<string>() { "1. 무기 장착 관리", "2. 방어구 장착 관리", "3. 물약 사용" });
            Console.WriteLine($"");
            Console.WriteLine($"0. 뒤로가기");

            while(true)
            {
                Console.Write(">> ");
                int tempInput = ShopInput(Console.ReadLine());

                switch (tempInput)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Clear();
                        scene.DisplayIntro("무기 가방");
                        DisplayCharacterInventory("무기");
                        WeaponEquipment();
                        break;
                    case 2:
                        Console.Clear();
                        scene.DisplayIntro("방어구 가방");
                        DisplayCharacterInventory("방어구");
                        ArmorEquipment();
                        break;
                    case 3:
                        Console.Clear();
                        scene.DisplayIntro("물약 가방");
                        DisplayCharacterInventory("물약");
                        PotionConsume();
                        break;
                }
                if(tempInput ==0)
                {
                    break;
                }
                
            }
        }

        void WeaponEquipment()
        {
            Console.WriteLine("어떤 무기를 장착합니까?");
            Console.WriteLine("장착된 장비를 선택하면 장착해제합니다.(0 눌러 취소)");
            Console.Write(">> ");
            int tempInput = ShopInput(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Weapons.Count + 1)
                {
                    Console.Clear();
                    if (!character.Weapons[tempInput - 1].IsEquipped)
                    {
                        for (int i = 0; i < character.Weapons.Count; i++)
                        {
                            if (character.Weapons[i].IsEquipped)
                            {
                                character.Weapons[i].UnEquipThis(character);
                            }
                        }
                        character.Weapons[tempInput - 1].EquipThis(character);
                    }
                    else
                    {
                        character.Weapons[tempInput - 1].UnEquipThis(character);
                    }
                    DisplayCharacterInventory("무기");
                    Console.ReadLine();
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

        void ArmorEquipment()
        {
            Console.WriteLine("어떤 방어구를 장착합니까?");
            Console.WriteLine("장착된 장비를 선택하면 장착해제합니다.(0 눌러 취소)");
            Console.Write(">> ");
            int tempInput = ShopInput(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Armors.Count + 1)
                {
                    Console.Clear();
                    if (!character.Armors[tempInput - 1].IsEquipped)
                    {
                        for (int i = 0; i < character.Armors.Count; i++)
                        {
                            if (character.Armors[i].IsEquipped)
                            {
                                character.Armors[i].UnEquipThis(character);
                            }
                        }
                        character.Armors[tempInput - 1].EquipThis(character);
                    }
                    else
                    {
                        character.Armors[tempInput - 1].UnEquipThis(character);
                    }
                    DisplayCharacterInventory("방어구");
                    Console.ReadLine();
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

        void PotionConsume()
        {
            Console.WriteLine("어떤 물약을 사용합니까?(0 눌러 취소)");
            Console.Write(">> ");
            int tempInput = ShopInput(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Potions.Count + 1)
                {
                    Console.Clear();
                    if (character.Potions[tempInput - 1].ItemCount > 0)
                    {
                        character.Potions[tempInput - 1].ConsumeThis(character);
                    }
                    else
                    {
                        Console.WriteLine("물약이 없습니다?");
                    }
                    DisplayCharacterInventory("물약");
                    Console.ReadLine();
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

        void DisplayCharacterInventory(string inventoryType)
        {
            string inventoryTitle;
            string itemStat;
            int inventoryCount;

            CharacterInventoryCheck(inventoryType);

            if (inventoryType == "무기")
            {
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

            Console.WriteLine($"  ==============={inventoryTitle} 가방===============");
            Console.WriteLine($"      | 이름\t\t |\t {itemStat}|    소지수|");
            Console.WriteLine("---------------------------------------------");
            for (int i = 0; i < inventoryCount; i++)
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
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }

        void DisplayWeaponInventory(int indexNum)
        {
            string indexNumber = $"{indexNum + 1}";
            string isEquipped;
            if (character.Weapons[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "   ";
            }

            string weaponName = $"{character.Weapons[indexNum].Name}";
            string weaponPrice = character.Weapons[indexNum].ItemPrice.ToString("D4");
            string weaponCount;
            if (character.Weapons[indexNum].ItemCount < character.Weapons[indexNum].ItemCountMax)
            {
                weaponCount = $"{character.Weapons[indexNum].ItemCount}개 보유";
            }
            else
            {
                weaponCount = "[최대보유]";
            }

            string WeaponAttack = ((int)(character.Weapons[indexNum].WeaponAttack)).ToString("D2");

            Console.WriteLine($"  {indexNumber}{isEquipped}| {weaponName}  \t |\t   + {WeaponAttack}|  {weaponCount}|");
        }

        void DisplayArmorInventory(int indexNum)
        {
            string indexNumber = $"{indexNum + 1}";
            string isEquipped;
            if (character.Armors[indexNum].IsEquipped)
            {
                isEquipped = "[E]";
            }
            else
            {
                isEquipped = "   ";
            }
            string armorName = $"{character.Armors[indexNum].Name}";
            string armorPrice = character.Armors[indexNum].ItemPrice.ToString("D4");
            string armorCount;
            if (character.Armors[indexNum].ItemCount < character.Armors[indexNum].ItemCountMax)
            {
                armorCount = $"{character.Armors[indexNum].ItemCount}개 보유";
            }
            else
            {
                armorCount = "[최대보유]";
            }
            string armorDefence = character.Armors[indexNum].ArmorDefence.ToString("D2");

            Console.WriteLine($"  {indexNumber}{isEquipped}| {armorName}  \t | \t   + {armorDefence}|  {armorCount}|");
        }

        void DisplayPotionInventory(int indexNum)
        {
            string indexNumber = $"{indexNum + 1}";
            string potionName = $"{character.Potions[indexNum].Name}";
            string potionPrice = character.Potions[indexNum].ItemPrice.ToString("D4");
            string potionCount;
            if (character.Potions[indexNum].ItemCount < character.Potions[indexNum].ItemCountMax)
            {
                potionCount = $"{character.Potions[indexNum].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = character.Potions[indexNum].PotionEffect.ToString("D3");
            Console.WriteLine($"  {indexNumber}   | {potionName}\t |  \t+ {potionEffect}|  {potionCount}|");
        }

        void CharacterInventoryCheck(string inventoryType)
        {
            if (inventoryType == "무기")
            {
                foreach (var weapon in itemDB.WeaponDict.Values)
                {
                    if (!character.Weapons.Contains(weapon))
                    {
                        if (weapon.ItemCount > 0)
                        {
                            character.Weapons.Add(weapon);
                        }
                    }
                    else
                    {
                        if (weapon.ItemCount > 0)
                        {
                            int itemIndex = character.Weapons.IndexOf(weapon);
                            character.Weapons[itemIndex].ItemCount = weapon.ItemCount;
                        }
                        else
                        {
                            character.Weapons.Remove(weapon);
                        }
                    }
                }
            }
            else if (inventoryType == "방어구")
            {
                foreach (var armor in itemDB.ArmorDict.Values)
                {
                    if (!character.Armors.Contains(armor))
                    {
                        if (armor.ItemCount > 0)
                        {
                            character.Armors.Add(armor);
                        }
                    }
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
                }
            }
            else if (inventoryType == "물약")
            {
                foreach (var potion in itemDB.PotionDict.Values)
                {
                    if (!character.Potions.Contains(potion))
                    {
                        if (potion.ItemCount > 0)
                        {
                            character.Potions.Add(potion);
                        }
                    }
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
        }

        // 이하 상점 메서드

        void DisplayShopUI()
        {
            scene.DisplayIntro("상점");
            Console.WriteLine("어떤 상점에 갑니까?");
            Console.WriteLine("=============================================");
            Console.WriteLine($"소지 골드 : {character.Gold} G");
            Console.WriteLine("---------------------------------------------");
            scene.DisplayOption(new List<string>() { "1. 무기 상점", "2. 방어구 상점", "3. 물약 상점" });
            Console.WriteLine();
            Console.Write(">> ");
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

            if (shopType == "무기")
            {
                ShopTitle = "무기";
            }
            else if (shopType == "방어구")
            {
                ShopTitle = "방어구";
            }
            else if (shopType == "물약")
            {
                ShopTitle = "물약";
            }
            else
            {
                ShopTitle = "????";
            }
            DisplayShopItems(shopType);

            Console.WriteLine($"{ShopTitle} 상점에서 뭘 하나요?");
            scene.DisplayOption(new List<string>() { "1. 구입", "2. 판매"});
            Console.WriteLine();
            Console.Write(">> ");
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

            Console.WriteLine("구입할 아이템 선택 (0 눌러 나가기)");
            Console.Write(">> ");

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
                    Console.Clear();
                    itemDB.WeaponDict[weaponBought.Key].BuyThis(character);
                    DisplayShopItems(shopType);
                }
                else if (shopType == "방어구")
                {
                    KeyValuePair<string, Armor> armorBought = itemDB.ArmorDict.ElementAt(tempInput);
                    Console.Clear();
                    itemDB.ArmorDict[armorBought.Key].BuyThis(character);
                    DisplayShopItems(shopType);
                }
                else if (shopType == "물약")
                {
                    KeyValuePair<string, Potion> potionBought = itemDB.PotionDict.ElementAt(tempInput);
                    Console.Clear();
                    itemDB.PotionDict[potionBought.Key].BuyThis(character);
                    DisplayShopItems(shopType);
                }
                else
                {
                    Console.WriteLine("잘못된 값");
                }
            }
            Console.ReadLine();
        }

        void SellItems(string shopType)
        {
            int shopCount;


            Console.Clear();
            if (shopType == "무기")
            {
                shopCount = itemDB.WeaponDict.Count;
                DisplayCharacterInventory(shopType);
            }
            else if (shopType == "방어구")
            {
                shopCount = itemDB.ArmorDict.Count;
                DisplayCharacterInventory(shopType);
            }
            else if (shopType == "물약")
            {
                shopCount = itemDB.PotionDict.Count;
                DisplayCharacterInventory(shopType);
            }
            else
            {
                shopCount = 1;
            }

            Console.WriteLine("판매할 아이템 선택 (0 눌러 나가기)");
            Console.Write(">> ");
            int tempInput = ShopInput(Console.ReadLine());

            if (tempInput == 0)
            {
                Console.WriteLine("상점을 나갑니다.");
            }
            else if (tempInput < shopCount)
            {
                if (shopType == "무기")
                {
                    Console.Clear();
                    character.Weapons[tempInput - 1].SellThis(character);
                    DisplayCharacterInventory(shopType);
                }
                else if (shopType == "방어구")
                {
                    Console.Clear();
                    character.Armors[tempInput - 1].SellThis(character);
                    DisplayCharacterInventory(shopType);
                }
                else if (shopType == "물약")
                {
                    Console.Clear();
                    character.Potions[tempInput - 1].SellThis(character);
                    DisplayCharacterInventory(shopType);
                }
                else
                {
                    Console.WriteLine("잘못된 값");
                }
            }
            Console.ReadLine();
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
                itemStat = "치료량";
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
            Console.WriteLine($"============================================================");
            Console.WriteLine($"  |\t 이름 \t\t\t|  {itemStat}|   가격|    소지수|");
            Console.WriteLine("------------------------------------------------------------");
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
            Console.WriteLine($"============================================================");
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


            Console.WriteLine($" {indexNumber}| {weaponName}      \t\t|    + {WeaponAttack}| {weaponPrice} G|  {weaponCount}|");
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
            Console.WriteLine($" {indexNumber}| {armorName}      \t\t|    + {armorDefence}| {armorPrice} G|  {armorCount}|");
        }

        void DisplayPotionShop(string potionKey, int i)
        {
            string indexNumber = $"{i}";
            string potionName = $"{itemDB.PotionDict[potionKey].Name}";
            string potionPrice = itemDB.PotionDict[potionKey].ItemPrice.ToString("D4");
            string potionCount;
            if (itemDB.PotionDict[potionKey].ItemCount < itemDB.PotionDict[potionKey].ItemCountMax)
            {
                potionCount = $"{itemDB.PotionDict[potionKey].ItemCount}개 보유";
            }
            else
            {
                potionCount = "[최대보유]";
            }
            string potionEffect = itemDB.PotionDict[potionKey].PotionEffect.ToString("D3");

            Console.WriteLine($" {indexNumber}| {potionName}            \t|   + {potionEffect}|   {potionPrice} G|  {potionCount}|");
        }

        public void ItemDatabaseCheck()
        {
            if (!isReset)
            {
                foreach (var weapon in itemDB.WeaponDict.Values)
                {
                    weapon.ItemCount = 0;
                    weapon.IsEquipped = false;
                }
                for (int i = 0; i < character.Weapons.Count; i++)
                {
                    itemDB.WeaponDict[character.Weapons[i].Name].ItemCount = character.Weapons[i].ItemCount;
                    itemDB.WeaponDict[character.Weapons[i].Name].IsEquipped = character.Weapons[i].IsEquipped;
                }
                character.Weapons.Clear();

                //

                foreach (var armor in itemDB.ArmorDict.Values)
                {
                    armor.ItemCount = 0;
                }
                for (int i = 0; i < character.Armors.Count; i++)
                {
                    itemDB.ArmorDict[character.Armors[i].Name].ItemCount = character.Armors[i].ItemCount;
                    itemDB.ArmorDict[character.Armors[i].Name].IsEquipped = character.Armors[i].IsEquipped;
                }
                character.Armors.Clear();

                //

                foreach (var potion in itemDB.PotionDict.Values)
                {
                    potion.ItemCount = 0;
                }
                for (int i = 0; i < character.Potions.Count; i++)
                {
                    itemDB.PotionDict[character.Potions[i].Name].ItemCount = character.Potions[i].ItemCount;
                }
                character.Potions.Clear();

                isReset = true;
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
