namespace TextRPG_Team_Project.Item.EquippableItem.Armors
{
    public class Armor : EquippableItem
    {
        int armorDefence;
        // 회피율이 추가될 수도 있음

        public Armor(string _name, int _itemPrice, int _itemCount, bool _isEquipped, int _armorDefence)
        {
            name = _name;
            itemPrice = _itemPrice;
            ItemCount = _itemCount;
            isEquipped = _isEquipped;
            armorDefence = _armorDefence;
        }

        public int ArmorDefence { get { return armorDefence; } private set { armorDefence = value; } }

        public override void EquipThis(Character character)
        {
            // 장비하지 않았을 때.
            if (!isEquipped)
            {
                if (itemCount > 0)
                {
                    Console.WriteLine($"{Name} 장착.");
                    isEquipped = true;
                    character.currentArmor = this;
                }
                else
                {
                    Console.WriteLine($"{Name}이(가) 없습니다.");
                }
            }
            // 이미 장비되었을 때.
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착 중입니다.");
            }
        }

        public override void UnEquipThis(Character character)
        {
            // 장비되어 있을 때
            if (isEquipped)
            {
                Console.WriteLine($"{Name} 장착해제");
                isEquipped = false;
                // character.currentArmor = shop.ArmorList[0];
            }
            // 아닐 때
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착해제됐습니다.");
            }
        }

        public override void SellThis(Character character)
        {
            // 있을 때
            if (itemCount > 0)
            {
                if (this.isEquipped)
                {
                    this.UnEquipThis(character);
                }
                Console.WriteLine($"{this.name} 판매완료");
                this.itemCount--;
                character.Gold += this.itemPrice;
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
        }
    }
    /*
    class TestArmor : Armor
    {
        string name = "테스트 방어구";
        int itemPrice = 10;
        int itemCount = 1;
        bool isEquipped = false;
        int armorDefence = 5;
    }

    class LeatherArmor : Armor
    {
        string name = "가죽 갑옷";
        int itemPrice = 0;
        int itemCount = 0;
        bool isEquipped = false;
        int armorDefence = 5;
    }

    class LinenRobe : Armor
    {
        string name = "리넨 로브";
        int itemPrice = 0;
        int itemCount = 0;
        bool isEquipped = false;
        int armorDefence = 5;
    }
    */
}
