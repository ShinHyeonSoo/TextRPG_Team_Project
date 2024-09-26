namespace TextRPG_Team_Project.Scene
{
    public class BattleManager
    {
        private List<Monster> _monsters;

        public List<Monster> Monsters { get { return _monsters; } private set { _monsters = value; } }

        public BattleManager(/*Func<string> callback*/) 
        {
            _monsters = new List<Monster>
            {
                new Monster("미니언", 2, 15, 3, 1, 100),
                new Monster("대포미니언", 5, 25, 2, 3, 100),
                new Monster("공허충", 3, 10, 5, 0, 100)
            };

            //AddMonsterInfo(callback);
        }

        public void AddMonsterInfo(Func<string> callback)
        {
            foreach (var monster in _monsters)
            {
                callback += monster.MonsterInfo;
            }
        }
    }
}
