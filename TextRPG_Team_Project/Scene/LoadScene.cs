using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project.Scene
{
	
	public class LoadScene : Scene
	{
		string[]? _files = null;
		List<string> _fileoOptions = new List<string>();
		int _selectedFileIndex = 0;
		public override void DisplayInitScene()
		{
			DisplayIntro("데이터 로드");
			Console.WriteLine();
			DisplayOption(_fileoOptions);
			Console.WriteLine();
			DisplayBack();
			Console.WriteLine();
			DisplayGetInputNumber();
		}
		public void DisplayLoadDataSuccess()
		{
			DisplayIntro("데이터 로드");
			Console.WriteLine();
			Console.WriteLine("데이터 로드 성공!");
			Console.WriteLine();
			StyleConsole.Write("1.", ConsoleColor.Cyan);
			StyleConsole.WriteLine("시작하기",ConsoleColor.Yellow);
			DisplayGetInputNumber();
		}

		public void DisplayLoadSaveDataFail()
		{
			DisplayIntro("데이터 로드");
			Console.WriteLine();
			Console.WriteLine("저장된 데이터가 없는 것 같아요...");
			Console.WriteLine();
			DisplayBack();
			Console.WriteLine();
			DisplayGetInputNumber();
		}

		public override void PlayScene()
		{
			if (SaveFileCheck())
			{
				DisplayInitScene();
				ProcessDataLoad();
				DisplayLoadDataSuccess();
				Utils.GetNumberInput(1, 2);
				GameManager.Instance.GoHomeScene();
			}
			else
			{
				DisplayLoadSaveDataFail();
				Utils.GetNumberInput(0, 1);
				GameManager.Instance.GoAnySScene(Defines.GameStatus.Start);
			}


		}
		public bool SaveFileCheck()
		{
			if (Directory.Exists(Defines.SAVE_FOLDER))
			{
				_files = Directory.GetFiles(Defines.SAVE_FOLDER);
				if (_files.Length>0)
				{
					for (int i = 0; i < _files.Length; i++)
					{
						_fileoOptions.Add($"{i+1}. {_files[i]}");
					}
					return true;
				}
			}
			return false;
		}

		public void ProcessDataLoad()
		{
			int userInput = Utils.GetNumberInput(0, _files.Length+1);
			if(userInput == 0) { GameManager.Instance.GoAnySScene(Defines.GameStatus.Start); return; }
			_selectedFileIndex = userInput-1;
			GameManager.Instance.Data.Load(_files[_selectedFileIndex]);


		}

	}
}
