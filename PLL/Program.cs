using SocialNetwork.PLL.Screens;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using SocialNetwork.PLL.Views.Friends;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.PLL
{
    internal class Program
    {
        public static MessageService messageService;
        public static UserService userService;
        public static FriendService friendService;

        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static FriendsView friendsView;

        static void Main(string[] args)
        {
            messageService = new MessageService();
            userService = new UserService(new UserRepository());
            friendService = new FriendService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView();
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            friendsView = new FriendsView(userService, friendService);

            while (true) 
            {
                mainView.Show();
            }
        }
    }
}