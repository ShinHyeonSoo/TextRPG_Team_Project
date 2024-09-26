namespace TextRPG_Team_Project.Item
{
    class Weapon : IItem, IEquipable
    {
        string name;
        int itemPrice;
        int itemCount;
        int itemCountMax = 5;
        bool isEquipped;
        int weaponAttack;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public bool IsEquipped { get { return isEquipped; } }
        public int WeaponAttack { get { return weaponAttack; } }
    }

    class TestWeapon : Weapon
    {
        string name = "Test Weapon";
        int itemPrice = 0;
        int itemCount = 0;
        int itemCountMax = 5;
        bool isEquipped = false;
        int weaponAttack = 5;
    }
}
