namespace TextRPG_Team_Project
{
    public class BattleManager
    {
        private List<Monster> _monsters;

        public List<Monster> Monsters { get { return _monsters; } private set { _monsters = value; } }

        public BattleManager() 
        {
            _monsters = new List<Monster>
            {
                new Minion("미니언", 2, 15, 3, 1, 100),
                new CannonMinion("대포미니언", 5, 25, 2, 3, 100),
                new Voidling("공허충", 3, 10, 5, 0, 100)
            };
        }

        public void MonsterInfo(Func<string> callback)
        {
            int count = 0;
            foreach (var monster in _monsters)
            {
                ++count;

                if (!monster.IsDead)
                {
                    callback = monster.MonsterInfo;
                }
                else
                {
                    callback = monster.DeadInfo;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                Console.WriteLine("{0}  " + callback(), count);
                Console.ResetColor();
            }
        }
    }
}
