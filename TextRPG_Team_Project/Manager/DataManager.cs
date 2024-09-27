using System.ComponentModel.Design;
using System.Xml.Linq;

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
                return new Warrior("홍길동", 1,100,1,1);

            return _player; 
        }

        public void CreatePlayer(string name, int _jobNum)
        {

            if(_jobNum == 1)
            {
                _player = new Warrior(name, 1, 100, 10, 5);
            }

                
            else if(_jobNum == 2)
            {
                _player = new Mage(name, 1, 100, 10, 5);
            }
        }
        #endregion
    }
}
