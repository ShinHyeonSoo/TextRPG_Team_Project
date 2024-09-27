namespace TextRPG_Team_Project
{
    public class DataManager
    {
        private static DataManager _instance;

        private Character _player;

        public static DataManager Instance()
        {
            if(_instance == null)
            {
                _instance = new();
            }

            return _instance;
        }

        #region 임시 메서드
        public Character GetPlayer() 
        {
            if (_player == null)
                return new Character("홍길동", 1,100,1,1);

            return _player; 
        }

        public void CreatePlayer(string name)
        {
            _player = new Character(name, 1, 100, 3, 1);
        }
        #endregion
    }
}
