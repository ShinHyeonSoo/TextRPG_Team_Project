namespace TextRPG_Team_Project.Item.EquippableItem.Armors
{
    class Armor : EquippableItem
    {
        int armorDefence;

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
