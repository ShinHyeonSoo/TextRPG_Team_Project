using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class SaveScene : Scene
	{
		public override void DisplayInitScene()
		{
			DisplayIntro("저장하기");
			Console.WriteLine();
			Console.WriteLine("0. 나가기");
		}

		public override void PlayScene()
		{
			DisplayInitScene();
			int input = Utils.GetNumberInput(0, 1);
			GameManager.Instance.GoHomeScene();
		}
	}
}
