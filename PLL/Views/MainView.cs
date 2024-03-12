namespace SocialNetwork.PLL.Screens
{
    public class MainView
    {
        public void Show() 
        {
            Console.Clear();
            Console.WriteLine("Войти в профиль\t\t(Нажмите 1)");
            Console.WriteLine("Зарегестрироваться\t(Нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    Program.authenticationView.Show();
                    break;

                case "2":
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}
