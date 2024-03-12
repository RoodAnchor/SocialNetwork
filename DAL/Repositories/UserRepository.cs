using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public Int32 Create(UserEntity userEntity) =>
            Execute(@"insert into users (firstname, lastname, password, email) 
                values (:firstname, :lastname, :password, :email)", userEntity);

        public IEnumerable<UserEntity> FindAll() =>
            Query<UserEntity>("select * from users");

        public UserEntity FindByEmail(String email) =>
            QueryFirstOrDefault<UserEntity>(
                "select * from users where email = :email_p", new { email_p = email });

        public UserEntity FindById(Int32 id) =>
            QueryFirstOrDefault<UserEntity>(
                "select * from users where id = :id_p", new { id_p = id });

        public Int32 Update(UserEntity userEntity) =>
            Execute(@"update users set firstname = :firstname, 
                lastname = :lastname, password = :password, 
                email = :email, photo = :photo, 
                favorite_movie = :favorite_movie, favorite_book = :favorite_book 
                where id = :id", userEntity);

        public Int32 DeleteById(Int32 id) =>
            Execute("delete from users where id = :id_p", new { id_p = id});
    }
}
