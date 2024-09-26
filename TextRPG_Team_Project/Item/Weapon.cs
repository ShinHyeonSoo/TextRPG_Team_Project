namespace TextRPG_Team_Project.Item
{
    class Weapon : IItem, IEquipable
    {
        string name;
        int itemPrice;
        bool isHave;
        bool isEquipped;
        int weaponAttack;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public bool IsHave { get { return isHave; } }
        public bool IsEquipped { get { return isEquipped; } }
        public int WeaponAttack { get { return weaponAttack; } }
    }

    class TestWeapon : Weapon
    {
        string name = "Test Weapon";
        int itemPrice = 0;
        bool isHave = false;
        bool isEquipped = false;
        int weaponAttack = 5;
    }
}
