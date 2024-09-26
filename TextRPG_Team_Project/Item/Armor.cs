namespace TextRPG_Team_Project.Item
{
    class Armor : IItem, IEquipable
    {
        string name;
        int itemPrice;
        bool isHave;
        bool isEquipped;
        int armorDefence;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public bool IsHave { get { return isHave; } }
        public bool IsEquipped { get { return isEquipped; } }
        public int ArmorDefence { get { return armorDefence; } }
    }

    class TestArmor : Armor
    {
        string name = "Test Armor";
        int itemPrice = 0;
        bool isHave = false;
        bool isEquipped = false;
        int armorDefence = 5;
    }
}
