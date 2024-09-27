namespace TextRPG_Team_Project.Item.Potions
{
    public class Potion : IItem, IConsumable
    {
        protected string name = "보이면 안되는 물약이름";
        protected int itemPrice = 0;
        protected int itemCount = 0;
        protected int itemCountMax = 30;
        protected int potionEffect = 0;

        public virtual void ConsumeThis(Character character)
        {
            if (itemCount > 0)
            {
                Console.WriteLine($"{character.Name}이(가) {this.Name}를 사용합니다.");
                itemCount--;
            }
            else
            {
                Console.WriteLine($"{this.Name}이(가) 없습니다.");
            }
        }

        public void GetItem(int addItemCount)
        {
            // 획득
            Console.WriteLine($"{name}을(를) {addItemCount}개 얻었다.");
            itemCount += addItemCount;

            // 최대치 초과량 제어
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount > 0)
            {
                Console.WriteLine($"{name}을(를) 더 많이 들 수 없어 {overItemCount}개 버렸다.");
                itemCount = itemCountMax;
            }
        }

        public string Name { get { return name; } private set { name = value; } }
        public int ItemPrice { get { return itemPrice; } private set { itemPrice = value; } }
        public int ItemCount { get { return itemCount; } set { itemCount = value; } }
        public int ItemCountMax { get { return itemCountMax; } private set { itemCountMax = value; } }
        public int PotionEffect {  get { return potionEffect; } private set { potionEffect = value; } }

        public void SellThis(Character character)
        {
            // 있을 때
            if (itemCount > 0)
            {
                Console.WriteLine("판매완료");

            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 수 없습니다.");
            }
        }

        public void BuyThis(Character character)
        {
            // 최대치보다 적을 때
            if (itemCount < itemCountMax)
            {
                Console.WriteLine("구입완료");
            }
            else
            {
                Console.WriteLine("구입할 수 없습니다.");
            }
        }
    }
    /*
    class HealthPotion : Potion
    {
        string name = "체력 물약";
        int itemPrice = 0;
        int itemCount = 3;
        int itemCountMax = 30;
        int potionEffect = 30;

        public override void ConsumeThis(Character character)
        {
            // 매개변수로 플레이어 받을 예정.
            // 던전 입장 전 포션 사용

            // 보유량 충분하면 회복 완료 메세지
            if (itemCount > 0)
            {
                // 포션의 회복량은 30(potionEffect)

                // character.Health += potionEffect;                // Character의 set 접근자제한걸림
                Console.WriteLine($"체력이 {this.potionEffect}만큼 회복되었습니다.");

                // 최대체력보다 높게 회복되지는 않음
                
                if(character.Health > character.MaxHealth)
                {
                    // character.Health = character.MaxHealth;      // Character의 set 접근자제한걸림
                }
                itemCount--;
            }
            // 보유량 부족하면 포션 부족 메세지
            else
            {
                Console.WriteLine($"{this.Name}이(가) 없습니다.");
            }
        }
    }
    */
}
