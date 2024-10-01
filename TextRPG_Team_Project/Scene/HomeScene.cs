using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class HomeScene : Scene
	{
		public override void DisplayInitScene()
		{
			DisplayIntro("마을");
			Console.WriteLine("");
			DisplayOption(new List<string>() { 
				"1. 상태보기", 
				$"2. 전투하기 (현재 진행 : {GameManager.Instance.Data.StageIndex} 층)",
				"3. 인벤토리", 
				"4. 퀘스트 목록", 
				"5. 저장하기" });
			Console.WriteLine();
			DisplayGetInputNumber();
		}

		public override void PlayScene()
		{
			DisplayInitScene();
			GameManager.Instance.GoAnySScene((Defines.GameStatus)Utils.GetNumberInput(1, 6));
		}
	}
}
