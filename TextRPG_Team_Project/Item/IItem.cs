namespace TextRPG_Team_Project.Item
{
    interface IItem
    {
        string Name { get; }
        int ItemPrice { get; }
        bool IsHave { get; }
    }

    interface IEquipable
    {
        bool IsEquipped { get; }
    }

    interface IConsumable
    {
        int ItemCount { get; }
        int ItemCountMax { get; }

        void ConsumeThis()
        {

        }
    }
}
