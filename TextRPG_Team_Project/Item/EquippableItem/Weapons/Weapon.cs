namespace TextRPG_Team_Project.Item.EquippableItem.Weapons
{
    class Weapon : EquippableItem
    {
        float weaponAttack;
        // 치명타가 추가될 수도 있음

        public Weapon(string _name, int _itemPrice, int _itemCount, bool _isEquipped, float _weponAttack)
        {
            name = _name;
            itemPrice = _itemPrice;
            ItemCount = _itemCount;
            isEquipped = _isEquipped;
            weaponAttack = _weponAttack;
        }

        public float WeaponAttack { get { return weaponAttack; } private set { weaponAttack = value; } }

    }
    /*
    class TestWeapon : Weapon
    {
        string name = "테스트 무기";
        int itemPrice = 10;
        int itemCount = 1;
        bool isEquipped = false;
        float weaponAttack = 5f;
    }

    class IronSword : Weapon
    {
        string name = "철 검";
        int itemPrice = 0;
        int itemCount = 0;
        bool isEquipped = false;
        float weaponAttack = 10f;
    }

    class WoodenStaff : Weapon
    {
        string name = "나무 지팡이";
        int itemPrice = 0;
        int itemCount = 0;
        bool isEquipped = false;
        float weaponAttack = 10f;
    }
    */
}
