namespace TextRPG_Team_Project.Item.EquippableItem.Armors
{
    class Armor : EquippableItem
    {
        int armorDefence;

        public int ArmorDefence { get { return armorDefence; } private set { armorDefence = value; } }
    }

    class TestArmor : Armor
    {
        string name = "테스트 방어구";
        int itemPrice = 0;
        int itemCount = 1;
        int itemCountMax = 5;
        bool isEquipped = false;
        int armorDefence = 5;
    }
}
