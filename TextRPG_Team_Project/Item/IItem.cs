namespace TextRPG_Team_Project.Item
{
    interface IItem
    {
        string Name { get; }
        int ItemPrice { get; }
        int ItemCount { get; }
        int ItemCountMax { get; }

        void GetItem(int addItemCount);
    }

    interface IEquippable
    {
        bool IsEquipped { get; }

        void EquipThis();

        void UnEquipThis();
    }

    interface IConsumable
    {
        void ConsumeThis();
    }
}
