using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views.Friends
{
    public class FriendsView
    {
        private FriendService _friendService;
        private UserService _userService;

        public static FriendsMenuView friendMenuView;
        public static FriendsListView friendsListView;
        public static AddFriendView addFriendView;
        public static RemoveFriendView removeFriendView;

        public FriendsView(
            UserService userService,
            FriendService friendService) 
        {
            _userService = userService;
            _friendService = friendService;

            friendMenuView = new FriendsMenuView();
            friendsListView = new FriendsListView();
            addFriendView = new AddFriendView(_friendService);
            removeFriendView = new RemoveFriendView(_friendService);
        }

        public void Show(User user)
        {
            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Друзья");
                Console.WriteLine();

                List<User> friends = new List<User>();

                _friendService.GetFriends(user).ToList().ForEach(x => 
                {
                    friends.Add(_userService.FindByEmail(x.FriendEmail));
                });

                friendsListView.Show(friends);

                friendMenuView.Show(user, friends);
            }
        }
    }
}
