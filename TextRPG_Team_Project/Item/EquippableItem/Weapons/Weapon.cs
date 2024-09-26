namespace TextRPG_Team_Project.Item.EquippableItem.Weapons
{
    class Weapon : EquippableItem
    {
        int weaponAttack;

        public int WeaponAttack { get { return weaponAttack; } }
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
