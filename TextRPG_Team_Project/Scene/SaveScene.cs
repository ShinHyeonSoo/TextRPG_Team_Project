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
			StyleConsole.Write("1. ", ConsoleColor.Cyan);
			Console.WriteLine("저장하기.");
			DisplayBack();
			Console.WriteLine();
			DisplayGetInputNumber();
		}

		public void DisplayInputScneName()
		{
			DisplayIntro("저장하기");
			Console.WriteLine();
			Console.WriteLine("세이브 파일 이름을 설정하세요.");
			Console.WriteLine();
			DisplayGetInputString("세이브 파일 이름");
		}
		
		public void DisplaySaveDone()
		{
			DisplayIntro("저장하기");
			Console.WriteLine();
			Console.WriteLine("세이브 파일이 저장되었습니다");
			Console.WriteLine();
			DisplayBack();
			Console.WriteLine();
			DisplayGetInputNumber();
		}

		public override void PlayScene()
		{
			DisplayInitScene();
			int input = Utils.GetNumberInput(0, 2);
			if (input == 0) { 
				GameManager.Instance.GoHomeScene();
				return;
			}
			DisplayInputScneName();
			string filePath = Console.ReadLine();
			GameManager.Instance.Data.Save(filePath);
			DisplaySaveDone();
			input = Utils.GetNumberInput(0, 1);
			if (input == 0) {GameManager.Instance.GoHomeScene();}
		}
	}
}
