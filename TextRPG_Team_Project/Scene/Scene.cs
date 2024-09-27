using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public abstract class Scene
	{
		public abstract void DisplayInitScene();
		public abstract void PlayScene();
		// 빠져나가길 원할때 GameManager.instance.GoHomeScene(); 호출

		public void DisplayIntro(string name) 
		{
			Console.Clear();
			Console.WriteLine("[name]");
		}
		public void DisplayGetInputNumber()
		{
			Console.WriteLine("원하시는 행동을 입력해주세요.");
			Console.Write(">>>   ");
		}
		public void DisplayGetInputString(string setting)
		{
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
				Console.WriteLine($" - {choiceOptions[i]}");
			}
		}
		public static void WrongInput()
		{
			Console.WriteLine("잘못입력하셨습니다.");
		}
	}
}
