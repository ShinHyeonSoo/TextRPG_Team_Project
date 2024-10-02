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
			string[] status = player.GetStatus().Split("\n");
			foreach (string s in status) 
			{
				if(s.Contains("체 력")) 
				{
					if (player.Health < player.MaxHealth) 
					{
						string[] hp = s.Split(':');
						StyleConsole.Write($"{hp[0]}:");
						StyleConsole.Write(hp[1].Split("/")[0],ConsoleColor.Red);
						StyleConsole.WriteLine($"/{hp[1].Split("/")[1]}");
					}
					else
					{
						StyleConsole.WriteLine(s);
					}
				}
				else
				{
					StyleConsole.WriteLine(s);
				}
			}
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
