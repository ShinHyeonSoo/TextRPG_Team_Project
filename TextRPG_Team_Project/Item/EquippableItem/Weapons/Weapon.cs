namespace TextRPG_Team_Project.Item.EquippableItem.Weapons
{
    public class Weapon : EquippableItem
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

        public override void EquipThis(Character character)
        {
            // 장비하지 않았을 때.
            if (!isEquipped)
            {
                if (itemCount > 0)
                {
                    Console.WriteLine($"{Name} 장착.");
                    isEquipped = true;
                    character.currentWeapon = this;
                }
                else
                {
                    Console.WriteLine($"{Name}이(가) 없습니다.");
                }
            }
            // 이미 장비되었을 때.
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착 중입니다.");
            }
        }

        public override void UnEquipThis(Character character)
        {
            // 장비되어 있을 때
            if (isEquipped)
            {
                Console.WriteLine($"{Name} 장착해제");
                isEquipped = false;
                // character.currentWeapon = shop.WeaponList[0];
            }
            // 아닐 때
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착해제됐습니다.");
            }
        }

        public override void SellThis(Character character)
        {
            // 있을 때
            if (itemCount > 0)
            {
                if (this.isEquipped)
                {
                    this.UnEquipThis(character);
                }
                Console.WriteLine($"{this.name} 판매완료");
                this.itemCount--;
                character.Gold += this.itemPrice;
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
        }

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
