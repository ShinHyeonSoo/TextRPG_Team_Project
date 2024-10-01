using System.Linq;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project.Item.Potions
{
    public class Potion : IItem, IConsumable
    {
        protected string name = "보이면 안되는 물약이름";
        protected int itemPrice;
        protected int itemCount;
        protected int itemCountMax = 30;
        protected int potionEffect;

        public Potion(string _name, int _itemPrice, int _itemCount, int _potionEffect)
        {
            name = _name;
            itemPrice = _itemPrice;
            itemCount = _itemCount;
            potionEffect = _potionEffect;
        }


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

        public void GetItem(Character character, string itemName, int addItemCount)
        {
            int overItemCount = itemCount - itemCountMax;

            if (overItemCount < 0)
            {
                Console.WriteLine($"{name}을(를) 얻었다.");
                if (character.Potions.Contains(this))
                {
                    itemCount += addItemCount;
                    int itemIndex = character.Potions.IndexOf(this);
                    character.Potions[itemIndex].ItemCount = this.ItemCount;
                }
                else
                {
                    this.itemCount += addItemCount;
                    character.Potions.Add(this);
                }
            }
            else
            {
                Console.WriteLine($"{name}은(는) 이미 최대로 가지고 있다.");
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
                float sellPrice = itemPrice * 0.75f;
                this.itemCount--;
                character.Gold += (int)sellPrice;
                Console.WriteLine($"{this.name} 판매완료 (+ {(int)sellPrice} G)");
            }
            // 없을 때
            else
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
            }
            Console.ReadLine();
        }

        public void BuyThis(Character character)
        {
            
            if (character.Gold >= itemPrice)
            {
                // 최대치보다 적을 때
                if (itemCount < itemCountMax)
                {
                    Console.WriteLine($"{this.name} 구입완료");
                    this.itemCount++;
                    character.Gold -= this.itemPrice;
                }
                else
                {
                    Console.WriteLine("보유 최대치에 도달해 구입할 수 없습니다.");
                }
            }
            else
            {
                Console.WriteLine("소지 골드가 부족합니다.");
            }
        }
    }

    class HealthPotion : Potion
    {
        public HealthPotion(string _name, int _itemPrice, int _itemCount, int _potionEffect) : base(_name, _itemPrice, _itemCount, _potionEffect)
        {
            name = _name;
            itemPrice = _itemPrice;
            itemCount = _itemCount;
            potionEffect = _potionEffect;
        }

        public override void ConsumeThis(Character character)
        {
            // 보유량 충분하면 회복 완료 메세지
            if (itemCount > 0)
            {
                // 포션의 회복량은 30(potionEffect)

                character.Health += potionEffect;                
                Console.WriteLine($"체력이 {this.potionEffect}만큼 회복되었습니다.");

                // 최대체력보다 높게 회복되지는 않음
                if(character.Health > character.MaxHealth)
                {
                    character.Health = character.MaxHealth;
                    Console.WriteLine($"최대 체력에 도달했다!");
                }
                itemCount--;

                // 포션퀘스트 체크용
                GameManager.Instance.PlayerRecored.IncresePotionUseCount(this.name);
            }
            // 보유량 부족하면 포션 부족 메세지
            else
            {
                Console.WriteLine($"{this.Name}이(가) 없습니다.");
            }
            Console.ReadLine();
        }
    }
}
