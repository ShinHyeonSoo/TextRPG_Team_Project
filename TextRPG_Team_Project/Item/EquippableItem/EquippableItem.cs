namespace TextRPG_Team_Project.Item.EquippableItem
{
    public class EquippableItem : IItem, IEquippable
    {
        protected string name = "보이면 안되는 장비이름";
        protected int itemPrice = 0;
        protected int itemCount = 0;
        protected int itemCountMax = 3;
        protected bool isEquipped = false;

        public string Name { get { return name; } private set { name = value; } }
        public int ItemPrice { get { return itemPrice; } private set { itemPrice = value; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } private set { itemCountMax = value; } }
        public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }

        public virtual void GetItem(Character character, string itemName, int addItemCount)
        {
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount < 0)
            {
                Console.WriteLine($"{name}을(를) 얻었다.");
                if (character.Armor.Contains(this) || character.Weapon.Contains(this))
                {
                    itemCount += addItemCount;
                }
                else
                {
                    this.itemCount += addItemCount;
                }
            }
            else
            {
                Console.WriteLine($"{name}은(는) 이미 가지고 있다.");
                itemCount = itemCountMax;
            }
        }

        public virtual void EquipThis(Character character)
        {
            // 장비하지 않았을 때.
            if (!isEquipped)
            {
                if (itemCount > 0)
                {
                    Console.WriteLine($"{Name} 장착.");
                    isEquipped = true;
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

        public virtual void UnEquipThis(Character character)
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
        }

        public virtual void SellThis(Character character)
        {
            // 있을 때
            if (itemCount > 0)
            {
                if (this.isEquipped)
                {
                    this.UnEquipThis(character);
                }
                Console.WriteLine($"{this.name} 판매완료");
                float sellPrice = itemPrice * 0.75f;
                this.itemCount--;
                character.Gold += (int)sellPrice;
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
        }

        public void BuyThis(Character character)
        {
            if (character.Gold >= itemPrice)
            {
                // 최대치보다 적을 때
                if (itemCount < itemCountMax)
                {
                    Console.WriteLine($"{this.name} 구입완료");
                    this.itemCount++;
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
