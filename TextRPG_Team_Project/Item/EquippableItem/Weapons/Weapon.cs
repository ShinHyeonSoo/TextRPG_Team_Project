using TextRPG_Team_Project.Database;
using System.Text.Json.Serialization;
using TextRPG_Team_Project.Database;

using TextRPG_Team_Project.Scene;
using System.Linq;
using System.Xml.Linq;

namespace TextRPG_Team_Project.Item.EquippableItem.Weapons
{
    public class Weapon : EquippableItem
    {
        float weaponAttack;
		public float WeaponAttack { get { return weaponAttack; } private set { weaponAttack = value; } }
		// 치명타가 추가될 수도 있음

		[JsonConstructor]
		public Weapon(float WeaponAttack, string Name, int ItemPrice, int ItemCount, int ItemCountMax, bool IsEquipped) : base(Name, ItemPrice, ItemCount, ItemCountMax, IsEquipped)
		{
			this.WeaponAttack = WeaponAttack;
		}

		public Weapon(string _name, int _itemPrice, int _itemCount, bool _isEquipped, float _weponAttack)
        {
            name = _name;
            itemPrice = _itemPrice;
            ItemCount = _itemCount;
            isEquipped = _isEquipped;
            weaponAttack = _weponAttack;
        }

        

        public override void GetItem(Character character, string itemName, int addItemCount )
        {
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount < 0)
            {
                Console.WriteLine($"{name}을(를) 얻었다.");
                if (character.Weapons.Contains(this))
                {
                    itemCount += addItemCount;
                    int itemIndex = character.Weapons.IndexOf(this);
                    character.Weapons[itemIndex].ItemCount = this.ItemCount;

                }
                else
                {
                    this.itemCount += addItemCount;
                    character.Weapons.Add(this);
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
                if(itemCount==0 && character.Weapons.Contains(this))
                {
                    character.Weapons.Remove(this);
                }
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
        }

        public override void BuyThis(Character character)
        {
            ItemDatabase itemDB = GameManager.Instance.Data.ItemDatabase;
            if (character.Gold >= itemPrice)
            {
                // 최대치보다 적을 때
                if (itemCount < itemCountMax)
                {
                    Console.WriteLine($"{itemDB.WeaponDict[this.Name].name} 구입완료");
                    if(!character.Weapons.Contains(itemDB.WeaponDict[this.Name]))
                    {
                        Weapon A = new Weapon(itemDB.WeaponDict[this.Name].Name, itemDB.WeaponDict[this.Name].ItemPrice, itemDB.WeaponDict[this.Name].ItemCount, itemDB.WeaponDict[this.Name].IsEquipped, itemDB.WeaponDict[this.Name].WeaponAttack);
                        A.itemCount++;
                        character.Weapons.Add(A);
                    }
                    else
                    {
                        int indexNum = character.Weapons.IndexOf(itemDB.WeaponDict[this.Name]);
                        character.Weapons[indexNum].itemCount++;
                    }
                    character.Gold -= this.itemPrice;
                }
                else
                {
                    Console.WriteLine("보유 최대치에 도달해 구입할 수 없습니다.");
                }
            }
            else
            {
                Console.WriteLine("소지 골드가 부족합니다.");

            }
        }

    }
}
