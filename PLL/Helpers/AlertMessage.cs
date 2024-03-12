namespace SocialNetwork.PLL.Helpers
{
    internal class AlertMessage
    {
        public static void Show(String message)
        {
            Console.Clear();

            ConsoleColor origColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = origColor;

            Thread.Sleep(1500);
        }
    }
}
