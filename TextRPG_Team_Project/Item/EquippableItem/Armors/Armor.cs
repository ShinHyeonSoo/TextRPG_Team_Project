using System.Linq;
using System.Text.Json.Serialization;
using TextRPG_Team_Project.Database;
using TextRPG_Team_Project.Item.EquippableItem.Weapons;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Item.EquippableItem.Armors
{
    public class Armor : EquippableItem
    {
        int armorDefence;
		public int ArmorDefence { get { return armorDefence; } private set { armorDefence = value; } }
		// 회피율이 추가될 수도 있음

		[JsonConstructor]
		public Armor(int ArmorDefence, string Name, int ItemPrice, int ItemCount, int ItemCountMax, bool IsEquipped) : base(Name, ItemPrice, ItemCount, ItemCountMax, IsEquipped)
		{
            this.ArmorDefence = ArmorDefence;
		}

		public Armor(string _name, int _itemPrice, int _itemCount, bool _isEquipped, int _armorDefence) : base()
        {
            name = _name;
            itemPrice = _itemPrice;
            ItemCount = _itemCount;
            isEquipped = _isEquipped;
            armorDefence = _armorDefence;
        }

        public override void GetItem(Character character, string itemName, int addItemCount)
        {
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount < 0)
            {
                Console.WriteLine($"{name}을(를) 얻었다.");
                if (character.Armors.Contains(this))
                {
                    itemCount += addItemCount;
                    int itemIndex = character.Armors.IndexOf(this);
                    character.Armors[itemIndex].ItemCount = this.ItemCount;

                }
                else
                {
                    this.itemCount += addItemCount;
                    character.Armors.Add(this);
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
                    character.currentArmor = this;
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
            Console.ReadLine();
        }

	}
}
