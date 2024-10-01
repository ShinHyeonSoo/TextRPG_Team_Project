using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class StatusScene : Scene
	{
        public override void DisplayInitScene()
		{
			Character player = GameManager.Instance.Data.GetPlayer();

            DisplayIntro("상태보기");
			Console.WriteLine();
			Console.WriteLine(player.GetStatus());
			Console.WriteLine();
			DisplayBack();
			DisplayGetInputNumber();
		}

		public override void PlayScene()
		{
			DisplayInitScene();
			if (Utils.GetNumberInput(0, 1) == 0) { GameManager.Instance.GoHomeScene(); }
		}
	}
}
