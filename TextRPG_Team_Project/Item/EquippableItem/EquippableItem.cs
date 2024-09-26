namespace TextRPG_Team_Project.Item.EquippableItem
{
    class EquippableItem : IItem, IEquipable
    {
        string name;
        int itemPrice;
        int itemCount;
        int itemCountMax = 5;
        bool isEquipped;

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public bool IsEquipped { get { return isEquipped; } private set { isEquipped = value; } }

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
                    Console.WriteLine($"{Name}가 없습니다.");
                }
            }
            // 이미 장비되었을 때.
            else
            {
                Console.WriteLine($"{Name}은 이미 장착 중입니다.");
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
                Console.WriteLine($"{Name}은 이미 장착해제 중입니다.");
            }
        }
    }
}
