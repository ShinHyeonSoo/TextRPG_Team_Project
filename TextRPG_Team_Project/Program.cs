using TextRPG_Team_Project.Scene;
namespace TextRPG_Team_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "일석이조TextRPG";
			GameManager.Instance.GameMain();
        }
    }
}
