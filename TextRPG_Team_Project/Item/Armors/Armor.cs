namespace TextRPG_Team_Project.Item.Armors
{
    class Armor : IItem, IEquipable
    {
        string name;
        int itemPrice;
        int itemCount;
        int itemCountMax = 5;
        bool isEquipped;
        int armorDefence;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public bool IsEquipped { get { return isEquipped; } }
        public int ArmorDefence { get { return armorDefence; } }
    }

    class TestArmor : Armor
    {
        string name = "Test Armor";
        int itemPrice = 0;
        int itemCount = 1;
        int itemCountMax = 5;
        bool isEquipped = false;
        int armorDefence = 5;
    }
}
