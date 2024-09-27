namespace TextRPG_Team_Project.Item.EquippableItem.Armors
{
    class Armor : EquippableItem
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
