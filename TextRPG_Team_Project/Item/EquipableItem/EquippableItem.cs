namespace TextRPG_Team_Project.Item.EquipableItem
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
        public bool IsEquipped { get { return isEquipped; } }

        public void EquipThis()
        {
            // 장비하지 않았을 때.
            if (!isEquipped)
            {
                if (itemCount > 0)
                {
                    Console.WriteLine($"Equip {Name}");
                    isEquipped = true;
                }
                else
                {
                    Console.WriteLine($"There is no {Name}.");
                }
            }
            // 이미 장비되었을 때.
            else
            {
                Console.WriteLine("This is already equipped.");
            }
        }

        public void UnEquipThis()
        {
            // 장비되어 있을 때
            if (isEquipped)
            {
                Console.WriteLine($"Unequip {Name}");
                isEquipped = false;
            }
            // 아닐 때
            else
            {
                Console.WriteLine("This is already unequipped.");
            }
        }
    }
}
