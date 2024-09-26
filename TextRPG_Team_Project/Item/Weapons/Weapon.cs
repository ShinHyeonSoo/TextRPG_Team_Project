namespace TextRPG_Team_Project.Item.Weapons
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
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public bool IsEquipped { get { return isEquipped; } }
        public int WeaponAttack { get { return weaponAttack; } }

        public void EquipThis()
        {
            if(itemCount>0)
            {
                Console.WriteLine($"Equip {this.Name}");
            }
            else
            {
                Console.WriteLine($"There is no {this.Name}.");
            }
        }
    }

    class TestWeapon : Weapon
    {
        string name = "Test Weapon";
        int itemPrice = 0;
        int itemCount = 1;
        int itemCountMax = 5;
        bool isEquipped = false;
        int weaponAttack = 5;
    }
}
