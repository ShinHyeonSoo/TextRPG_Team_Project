using System.ComponentModel.Design;
using System.Xml.Linq;
using TextRPG_Team_Project;
using TextRPG_Team_Project.Scene;
using System.Text.Json;
using System;
using TextRPG_Team_Project.Data;

namespace TextRPG_Team_Project
{
    public class DataManager
    {
        
        private static DataManager _instance;
        private Random _random;
        private Character _player;

        public PotionDataBase PotionDB { get; private init; }

        public DataManager()
        {
            _random = new Random();
			PotionDB = new PotionDataBase();
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

        public void Save(string filename="default1")
        {
			if (!Directory.Exists(Defines.SAVE_FOLDER)) 
				Directory.CreateDirectory(Defines.SAVE_FOLDER);
			string savePath = Path.Combine(Defines.SAVE_FOLDER, $"{filename}.json");
            
            SaveData savedata = new SaveData();
            savedata.PlayerSaveData = _player.Save();
            savedata.QuestSaves = GameManager.Instance.Quest.Save();
			string jsonString = JsonSerializer.Serialize<SaveData>(savedata, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(savePath, jsonString);
		}
        public void Load(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            SaveData savedata = JsonSerializer.Deserialize<SaveData>(jsonString);
            PlayerSaveData playerData = savedata.PlayerSaveData;
            if(playerData.Job == "전사")
            {
                CreatePlayer(playerData.Name, 1);
                _player.Load(playerData);
            }
            else if(playerData.Job == "마법사")
            {
				CreatePlayer(playerData.Name, 2);
				_player.Load(playerData);
			}
            List<QuestSaveData> questData = savedata.QuestSaves;
            GameManager.Instance.Quest.Load(questData);
		}
    }
}
