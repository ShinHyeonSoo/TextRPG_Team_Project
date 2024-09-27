using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
	internal class Utils
	{
		public static int GetNumberInput(int min, int max)
		/*사용자의 숫자입력을 받는 함수
		 min : 입력가능한 최소값 (포함)
		 max : 입력가능한 최대값 (미포함)
		*/
		{
			string? input = "";
			int inputNumber = 0;

			while (true)
			{
				input = Console.ReadLine();
				if (int.TryParse(input, out inputNumber))
				{
					if (min <= inputNumber && inputNumber < max) { return inputNumber; }
					else { input = ""; }
				}
				input = "";
				Scene.Scene.WrongInput();
			}
		}
	}
}
