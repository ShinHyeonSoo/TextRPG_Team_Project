using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	public class StatusScene : Scene
	{
		event Func<string> UserStatusInfo; // 유저 Status를 보여주는 string을 반환하는 함수를 할당해주세요
                                        
        public override void DisplayInitScene()
		{
			Character player = GameManager.Instance.Data.GetPlayer();
			UserStatusInfo += player.GetStatus;
            DisplayIntro("상태보기");
			Console.WriteLine();
			Console.WriteLine(UserStatusInfo?.Invoke());
			Console.WriteLine();

			Console.WriteLine("0. 나가기");
			DisplayGetInputNumber();
		}

		public override void PlayScene()
		{
			DisplayInitScene();
			if (Utils.GetNumberInput(0, 1) == 0) { GameManager.Instance.GoHomeScene(); }
		}
	}
}
