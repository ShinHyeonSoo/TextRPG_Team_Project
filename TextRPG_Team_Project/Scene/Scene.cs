using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public abstract class Scene
	{

		public abstract int PlayScene();

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
	}
	public class StartScene : Scene
	{
		public  void DisplayInitScene()
		{
			DisplayIntro("게임 이름") // 게임 이름 뭐로할까용
			Console.WriteLine("어서오세요");
			Console.WriteLine("");
			Console.WriteLine("1. 시작하기");
		}
		public override int PlayScene()
		{
			DisplayInitScene();
			return TempGameManager.GetNumberInput(1, 2);
		}
	}

	public class HomeScene : Scene
	{
		public void DisplayInitScene()
		{
			DisplayIntro("마을");
			Console.WriteLine("");
			Console.WriteLine("1. 상태보기");
			Console.WriteLine("2. 전투");
			DisplayGetInputNumber();
		}

		public override int PlayScene()
		{
			DisplayInitScene();
			return TempGameManager.GetNumberInput(1,3);
		}
	}

	public class StatusScene : Scene
	{
		event Func<string> UserStatusInfo;  // 유저 Status를 보여주는 string을 반환하는 함수를 할당해주세요
		public void DisplayInitScene(string status)
		{
			DisplayIntro("상태보기");
			Console.WriteLine();
			Console.WriteLine(status);

			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public override int PlayScene()
		{
			DisplayInitScene(UserStatusInfo.Invoke());
			return TempGameManager.GetNumberInput(0, 1);
		}
	}

	public class DebugScene : Scene
	{
		event Func<string> DebugInfo;
		public void DisplayInitScene(string strings)
		{
			DisplayIntro("Debug");
			Console.WriteLine();
			Console.WriteLine(strings);

			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public override int PlayScene()
		{
			DisplayInitScene(DebugInfo());
			return TempGameManager.GetNumberInput(0, 1);
		}
	}


}
