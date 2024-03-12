using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public interface IFriendRepository
    {
        public Int32 Create(FriendEntity friendEntity);
        public IEnumerable<FriendEntity> FindAllByUserId(Int32 userId);
        public Int32 Delete(Int32 id);
    }
}
