namespace TextRPG_Team_Project.Item.EquippableItem.Weapons
{
    class Weapon : EquippableItem
    {
        float weaponAttack;

        public float WeaponAttack { get { return weaponAttack; } private set { weaponAttack = value; } }
    }

    class TestWeapon : Weapon
    {
        string name = "테스트 무기";
        int itemPrice = 0;
        int itemCount = 1;
        int itemCountMax = 5;
        bool isEquipped = false;
        float weaponAttack = 5;
    }
}
