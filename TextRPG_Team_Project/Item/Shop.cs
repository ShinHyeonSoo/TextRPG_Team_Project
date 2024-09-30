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
                DisplayWeaponInventory(i);
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
            int tempInput = int.Parse(Console.ReadLine());
            if (tempInput != 0)
            {
                if (tempInput < character.Weapon.Count)
                {
                    if (!character.Weapon[tempInput].IsEquipped)
                    {
                        for(int i = 0; i < character.Weapon.Count;i++)
                        {
                            if(character.Weapon[i].IsEquipped)
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
            int tempInput = int.Parse(Console.ReadLine());
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
            foreach ( var weapon in itemDB.weaponDict.Values)
            {
                if(!character.Weapon.Contains(weapon))
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
