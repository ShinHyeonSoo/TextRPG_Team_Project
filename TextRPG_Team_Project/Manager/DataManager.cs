namespace TextRPG_Team_Project
{
    public class DataManager
    {
        private static DataManager _instance;

        private Random _random;
        private Character _player;

        public DataManager()
        {
            _random = new Random();
        }

        public static DataManager Instance()
        {
            if(_instance == null)
            {
                _instance = new();
            }

            return _instance;
        }

        public Random GetRandom()
        {
            if (_random == null)
                return null;

            return _random;
        }

        #region 임시 메서드
        public Character GetPlayer() 
        {
            if (_player == null)
                return null;

            return _player; 
        }

        public void CreatePlayer(string name)
        {
            _player = new Character(name, 1, 100, 3, 1);
        }
        #endregion
    }
}
