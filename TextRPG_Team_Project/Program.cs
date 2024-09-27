using TextRPG_Team_Project.Scene;

namespace TextRPG_Team_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
			GameManager.Instance.GameMain();
        }
    }
}
