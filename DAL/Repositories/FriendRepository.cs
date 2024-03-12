using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(Int32 userId) =>
            Query<FriendEntity>(@"select * from friends where user_id = :user_id",
                new { user_id = userId });

        public Int32 Create(FriendEntity friendEntity) =>
            Execute(@"insert into friends (user_id, friend_id) 
                    values (:user_id, :friend_id)", friendEntity);

        public Int32 Delete(Int32 id) =>
            Execute(@"delete from friends where id = :id_p", new { id_p = id });
    }
}
