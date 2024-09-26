namespace TextRPG_Team_Project.Item.EquippableItem
{
    class EquippableItem : IItem, IEquippable
    {
        string name;
        int itemPrice;
        int itemCount;
        int itemCountMax = 1;
        bool isEquipped;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public bool IsEquipped { get { return isEquipped; } private set { isEquipped = value; } }

        public void GetItem(int addItemCount)
        {
            Console.WriteLine($"{name}을(를) 얻었다.");
            itemCount += addItemCount;

            int overItemCount = itemCount - itemCountMax;

            if (overItemCount > 0)
            {
                Console.WriteLine($"{name}은(는) 이미 가지고 있다.");
                itemCount = itemCountMax;
            }
        }

        public void EquipThis()
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

        public void UnEquipThis()
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
                Console.WriteLine($"{Name}은(는) 이미 장착해제 중입니다.");
            }
        }
    }
}
