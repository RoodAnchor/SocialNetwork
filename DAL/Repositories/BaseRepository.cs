using System.Data;
using System.Data.SQLite;

using Dapper;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(String sql, Object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(String sql, Object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected Int32 Execute(String sql, Object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection() =>
            new SQLiteConnection("Data Source = DB/social_network_db.db; Version = 3");
    }
}