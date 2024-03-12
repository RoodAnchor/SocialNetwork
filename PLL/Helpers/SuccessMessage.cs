namespace SocialNetwork.PLL.Helpers
{
    internal class SuccessMessage
    {
        public static void Show(String message)
        {
            Console.Clear();

            ConsoleColor origColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = origColor;

            Thread.Sleep(1500);
        }
    }
}
