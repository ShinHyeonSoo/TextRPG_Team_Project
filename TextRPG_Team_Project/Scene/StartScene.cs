using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class StartScene : Scene
	{
		enum StartState
		{
			Start,
			SetCharacterName,
			SetCharacterJob,
		}
		public override void DisplayInitScene()
		{
			DisplayIntro("게임 이름"); // 게임 이름 뭐로할까용
			Console.WriteLine("어서오세요");
			Console.WriteLine("");
			DisplayOption(new List<string>() { "1. 시작하기" });
		}
		public void DisplaySetCharacterName()
		{
			DisplayIntro("게임 이름"); // 게임 이름 뭐로할까용
			Console.WriteLine("케릭터 이름을 설정해주세요,");
			Console.WriteLine("");
		}
		public void DisplaySetCharacterJob()
		{
			DisplayIntro("게임 이름"); // 게임 이름 뭐로할까용
			Console.WriteLine("케릭터 이름을 설정해주세요,");
			Console.WriteLine("");
			DisplayOption(new List<string>() { "1. 직업1", "2. 직업2", "3. 직업3" });
		}
		public override void PlayScene()
		{
			DisplayInitScene();
			Utils.GetNumberInput(1, 2);

			DisplaySetCharacterName();
			string characterName = Console.ReadLine();
			// 케릭터의 이름을 정하는  부분 추가 필요
			DisplaySetCharacterJob();
			int jobSelect = Utils.GetNumberInput(1, 3);
			// 케릭터의 직업을 정하는 부분 추가 필요
			GameManager.Instance.Data.CreatePlayer(characterName, jobSelect);		 //캐릭터 생성		
			GameManager.Instance.GoHomeScene();
		}
	}
}
