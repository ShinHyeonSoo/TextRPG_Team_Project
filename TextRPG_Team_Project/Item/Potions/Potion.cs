namespace TextRPG_Team_Project.Item.Potions
{
    class Potion : IItem, IConsumable
    {
        string name;
        int itemPrice;
        int itemCount;
        int itemCountMax;
        int potionEffect;

        public virtual void ConsumeThis()       // 후에 적절한 매개변수 넣을 예정(ex. 플레이어)
        {
            if (itemCount > 0)
            {
                Console.WriteLine($"Use {Name}");
                itemCount--;
            }
            else
            {
                Console.WriteLine($"Need More {Name}");
            }
        }

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } }
        public int ItemCountMax { get { return itemCountMax; } }
    }

    class HealthPotion : Potion
    {
        string name = "Health Potion";
        int itemPrice = 0;
        int itemCount = 3;
        int itemCountMax = 30;
        int potionEffect = 30;

        public override void ConsumeThis()
        {
            if (itemCount > 0)
            {
                Console.WriteLine($"Health is restored by {potionEffect}.");
                itemCount--;
            }
            else
            {
                Console.WriteLine($"Need More {Name}");
            }
            // 던전 입장 전 포션 사용
            // 보유량 충분하면 회복 완료 메세지
            // 보유량 부족하면 포션 부족 메세지
            // 포션의 회복량은 30
            // 최대체력보다 높게 회복되지는 않음
        }
    }
}
