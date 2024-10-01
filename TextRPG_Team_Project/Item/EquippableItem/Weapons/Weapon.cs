using System.Linq;
using TextRPG_Team_Project.Database;
using TextRPG_Team_Project.Scene;

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

        public override void GetItem(Character character, string itemName, int addItemCount )
        {
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount < 0)
            {
                Console.WriteLine($"{name}을(를) 얻었다.");
                if (character.Weapon.Contains(this))
                {
                    itemCount += addItemCount;
                    int itemIndex = character.Weapon.IndexOf(this);
                    character.Weapon[itemIndex].ItemCount = this.ItemCount;
                }
                else
                {
                    this.itemCount += addItemCount;
                    character.Weapon.Add(this);
                }
            }
            else
            {
                Console.WriteLine($"{name}은(는) 이미 가지고 있다.");
                itemCount = itemCountMax;
            }
        }

        public override void EquipThis(Character character)
        {
            // 장비하지 않았을 때.
            if (!isEquipped)
            {
                if (itemCount > 0)
                {
                    Console.WriteLine($"{Name} 장착.");
                    isEquipped = true;
                    character.EquipWeapon(this);
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
            Console.ReadLine();
        }

        public override void UnEquipThis(Character character)
        {
            // 장비되어 있을 때
            if (isEquipped)
            {
                Console.WriteLine($"{Name} 장착해제");
                isEquipped = false;
                character.UnEquipWeapon();
            }
            // 아닐 때
            else
            {
                Console.WriteLine($"{Name}은(는) 이미 장착해제됐습니다.");
            }
            Console.ReadLine();
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
                
                float sellPrice = itemPrice * 0.75f;
                this.itemCount--;
                character.Gold += (int)sellPrice;
                Console.WriteLine($"{this.name} 판매완료 (+ {(int)sellPrice} G)");
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
        }

    }
}
