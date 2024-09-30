using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Team_Project
{
	// ConsoleWrapper
	// 콘솔을 알록달록...
    public static class StyleConsole
    {
        public static ConsoleColor defaultForeColor = ConsoleColor.White;
		public static ConsoleColor defaultbackColor = ConsoleColor.Black;
		#region string
		public static void BWrite(string value, ConsoleColor color = ConsoleColor.White)
		{

			Console.BackgroundColor = color;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void BWriteLine(string value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(string value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void WriteLine(string value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		#endregion

		#region bool
		public static void BWrite(bool value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void BWriteLine(bool value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(bool value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{

			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void WriteLine(bool value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{

			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		#endregion

		#region char
		public static void BWrite(char value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void BWriteLine(char value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(char value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void WriteLine(char value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		#endregion

		#region int

		public static void BWrite(int value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void BWriteLine(int value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(int value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void WriteLine(int value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		#endregion

		#region float

		public static void BWrite(float value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void BWriteLine(float value, ConsoleColor color = ConsoleColor.White)
		{
			Console.BackgroundColor = color;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
		}
		public static void Write(float value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.Write(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		public static void WriteLine(float value, ConsoleColor fore = ConsoleColor.White, ConsoleColor back = ConsoleColor.Black)
		{
			Console.ForegroundColor = fore;
			Console.BackgroundColor = back;
			Console.WriteLine(value);
			Console.BackgroundColor = defaultbackColor;
			Console.ForegroundColor = defaultForeColor;
		}
		#endregion
	}
}
