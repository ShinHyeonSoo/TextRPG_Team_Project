namespace TextRPG_Team_Project.Item
{
    public interface IItem
    {
        string Name { get; }
        int ItemPrice { get; }
        int ItemCount { get; }
        int ItemCountMax { get; }

        void GetItem(Character character, string itemName, int addItemCount);

        void SellThis(Character character);

        void BuyThis(Character character);
    }

    public interface IEquippable
    {
        bool IsEquipped { get; }

        void EquipThis(Character character);

        void UnEquipThis(Character character);
    }

    public interface IConsumable
    {
        void ConsumeThis(Character character);
    }
}
