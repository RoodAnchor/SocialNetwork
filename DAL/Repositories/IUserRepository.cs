using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public interface IUserRepository
    {
        public Int32 Create(UserEntity userEntity);
        public UserEntity FindByEmail(String email);
        public IEnumerable<UserEntity> FindAll();
        public UserEntity FindById(Int32 id);
        public Int32 Update(UserEntity userEntity);
        public Int32 DeleteById(Int32 id);
    }
}
