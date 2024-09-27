using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
    public static class StyleConsole
    {
        public static ConsoleColor defaultForeColor = ConsoleColor.White;
		public static ConsoleColor defaultbackColor = ConsoleColor.Black;
		public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = defaultForeColor;
        }
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultForeColor;
        }
		public static void BWrite(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.Write(text);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void BWriteLine(string text, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(text);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(string text, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			
			Console.BackgroundColor = back;
			Write(text, fore);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void WriteLine(string text, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{

			Console.BackgroundColor = back;
			WriteLine(text, fore);
			Console.BackgroundColor = defaultbackColor;
		}
	}
}
