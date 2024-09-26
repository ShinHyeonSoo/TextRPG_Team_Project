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
                Console.WriteLine($"{{player.Name}}가 {this.Name}를 사용합니다.");
                itemCount--;
            }
            else
            {
                Console.WriteLine($"{this.Name}가 없습니다.");
            }
        }

        public void GetItem(int addItemCount)
        {
            Console.WriteLine($"{name}을(를) {addItemCount}개 얻었다.");
            itemCount += addItemCount;

            int overItemCount = itemCount - itemCountMax;

            if (overItemCount > 0)
            {
                Console.WriteLine($"{name}을(를) 더 많이 들 수 없어 {overItemCount}개 버렸다.");
                itemCount = itemCountMax;
            }
        }

        public string Name { get { return name; } }
        public int ItemPrice { get { return itemPrice; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } }
        public int PotionEffect {  get { return potionEffect; } }
    }

    class HealthPotion : Potion
    {
        string name = "체력 물약";
        int itemPrice = 0;
        int itemCount = 3;
        int itemCountMax = 30;
        int potionEffect = 30;

        public override void ConsumeThis()
        {
            // 매개변수로 플레이어 받을 예정.
            // 던전 입장 전 포션 사용

            // 보유량 충분하면 회복 완료 메세지
            if (itemCount > 0)
            {
                // 포션의 회복량은 30(potionEffect)

                // player.Health += potionEffect;           
                Console.WriteLine($"체력이 {this.potionEffect}만큼 회복되었습니다.");

                // 최대체력보다 높게 회복되지는 않음
                /*
                if(player.Health > player.HealthMax)
                {
                    player.Health = player.HealthMax;
                }
                */
                itemCount--;
            }
            // 보유량 부족하면 포션 부족 메세지
            else
            {
                Console.WriteLine($"{this.Name}이(가) 없습니다.");
            }
        }
    }
}
