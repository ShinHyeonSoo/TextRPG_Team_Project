namespace TextRPG_Team_Project.Item
{
    class Potion : IItem, IConsumable
    {
        string name;
        int itemPrice;
        bool isHave;
        int itemCount;
        int itemCountMax;

        public virtual void ConsumeThis()
        {

        }

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public bool IsHave { get { return isHave; } }
        public int ItemCount { get { return itemCount; } }
        public int ItemCountMax { get { return itemCountMax; } }
    }

    class HealthPotion : Potion
    {
        string name = "Health Potion";
        int itemPrice = 0;
        bool isHave = true;
        int itemCount = 3;
        int itemCountMax = 30;

        public override void ConsumeThis()
        {
            // 던전 입장 전 포션 사용
            // 보유량 충분하면 회복 완료 메세지
            // 보유량 부족하면 포션 부족 메세지
            // 포션의 회복량은 30
            // 최대체력보다 높게 회복되지는 않음
        }
    }
}
