using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public abstract class Scene
	{
		public abstract void DisplayInitScene();
		public abstract void PlayScene();
		// 빠져나가길 원할때 GameManager.instance.GoHomeScene(); 호출


		public void DisplayIntro()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($" **********                   **         *******   *******    ******** ");
			sb.AppendLine($"/////**///                   /**        /**////** /**////**  **//////**");
			sb.AppendLine($"    /**      *****  **   ** ******      /**   /** /**   /** **      // ");
			sb.AppendLine($"    /**     **///**//** ** ///**/       /*******  /******* /**         ");
			sb.AppendLine($"    /**    /******* //***    /**        /**///**  /**////  /**    *****");
			sb.AppendLine($"    /**    /**////   **/**   /**        /**  //** /**      //**  ////**");
			sb.AppendLine($"    /**    //****** ** //**  //**       /**   //**/**       //******** ");
			sb.AppendLine($"    //      ////// //   //    //        //     // //         ////////  ");

			Console.Clear();
			Console.WriteLine();
			foreach(char c in sb.ToString())
			{
				if( c == '*') { StyleConsole.Write(c, ConsoleColor.Yellow); }
				else if (c == '/') { StyleConsole.Write(c, ConsoleColor.DarkBlue); }
				else { StyleConsole.Write(c); }
			}
			Console.WriteLine();
		}
		public void DisplayIntro(string name)
		{
			Console.Clear();
			StyleConsole.WriteLine($"[{name}]", ConsoleColor.Yellow);
			Console.WriteLine();
		}
		public void DisplayGetInputNumber()
		{
			Console.WriteLine();
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>>   ");
		}
		public void DisplayGetInputString(string setting)
		{
			Console.WriteLine();
			Console.WriteLine($"원하시는 {setting}을 입력해주세요.");
			Console.Write(">>>   ");
		}

		public void DisplayOption(List<string> choiceOptions)
			/*
			 * 선택지들을 출력해주는 함수입니다. 매개변수 (List<string>)
			 * 숫자를 포함하여 작성해주세요.
			 */
		{
			for( int i = 0; i < choiceOptions.Count; i++)
			{
				string[] parsedOptionText = choiceOptions[i].Split(".");
				StyleConsole.Write($" {parsedOptionText[0]}. ", ConsoleColor.Cyan);
				Console.WriteLine($"{parsedOptionText[1]}");
			}
		}
		public void DisplayBack()
		{
			StyleConsole.Write("0. ",ConsoleColor.Red);
			StyleConsole.WriteLine("나가기",ConsoleColor.Yellow);
		}
		public static void WrongInput()
		{
			(int left, int top) = Console.GetCursorPosition();
			Console.SetCursorPosition(0, top-2);
			Utils.ClearBelowCursor(top - 2);
			StyleConsole.WriteLine("잘못입력하셨습니다. 다시 입력해주세요.", ConsoleColor.White, ConsoleColor.Red);
			Console.Write(">>>   ");
		}
	}
}
