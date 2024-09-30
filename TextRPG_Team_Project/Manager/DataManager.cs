using System.ComponentModel.Design;
using System.Xml.Linq;

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
                return new Warrior("홍길동", 1,100,1,1, 1);

            return _player; 
        }

        public void CreatePlayer(string name, int _jobNum)
        {

            if(_jobNum == 1)
            {
                _player = new Warrior(name, 1, 50, 10, 1, 50);
            }

                
            else if(_jobNum == 2)
            {
                _player = new Mage(name, 1, 100, 10, 5, 100);
            }
        }
        #endregion
    }
}
