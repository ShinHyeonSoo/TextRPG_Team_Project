using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Item;
using TextRPG_Team_Project.Item.EquippableItem.Armors;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Item.Potions;

namespace TextRPG_Team_Project.Scene
{
    public class InventoryScene : Scene
    {
        // 이 이하는 임시코드
        Character character = new Character("테스터", 1, 100, 15, 10);
        Shop shop = new Shop();
        // 임시코드 끝
        // 인벤토리를 받거나
        // 인벤토리의 함수들을 받기
        enum InventoryState
        {
            Start = 0,
            ManagingEuipment = 1,
            UseItem = 2,
            Shop = 3
        }
        private InventoryState _state;

        public InventoryScene() { }

        public override void DisplayInitScene()
        {
            DisplayIntro("인벤토리");
            Console.WriteLine();
            Console.WriteLine("인벤토리 목록 출력");

            shop.DisplayWeaponShopList();
            shop.DisplayArmorShopList();
            shop.DisplayPotionShopList();

            DisplayOption(new List<string>() { "1. 장착 관리", "2. 아이템 사용", "3. 아이템 구입/판매" });
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }
        public void DisplayManagingEuipment()
        {
            DisplayIntro("인벤토리");
            Console.WriteLine();
            Console.WriteLine("인벤토리 장비 목록 출력");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();

        }
        public void DisplayUsetItem()
        {
            DisplayIntro("인벤토리");
            Console.WriteLine();
            Console.WriteLine("인벤토리 사용아이템 목록 출력");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }

        public void DisplayShop()
        {
            DisplayIntro("상점");
            Console.WriteLine();
            DisplayOption(new List<string>() { "1. 무기 상점", "2. 방어구 상점", "3. 물약 상점" });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }

        public void DisplayWeaponShop()
        {
            DisplayIntro("무기 상점");
            Console.WriteLine();
            Console.WriteLine("무기 리스트");
            DisplayOption(new List<string>() { "1.", "2.", "3." });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }

        public void DisplayArmorShop()
        {
            DisplayIntro("방어구 상점");
            Console.WriteLine();
            Console.WriteLine("방어구 리스트");
            DisplayOption(new List<string>() { "1.", "2.", "3." });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }

        public void DisplayPotionShop()
        {
            DisplayIntro("물약 상점");
            Console.WriteLine();
            DisplayOption(new List<string>() { "물약 리스트" });
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            DisplayGetInputNumber();
        }

        public override int PlayScene()
        {
            switch (_state)
            {
                case InventoryState.Start:
                    DisplayInitScene();
                    _state = (InventoryState)GameManager.GetNumberInput(0, 3);
                    if (_state == InventoryState.Start) { return 0; }
                    break;
                case InventoryState.ManagingEuipment:
                    DisplayManagingEuipment();
                    break;
                case InventoryState.UseItem:
                    DisplayUsetItem();
                    break;
                case InventoryState.Shop:
                    DisplayShop();
                    break;
            }
            return 0;
        }
    }
}
