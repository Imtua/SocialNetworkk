using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace SocialNetworkBackground.DAL.Repositories
{
    public class BaseRepository
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using(var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
                return connection.Execute(sql, parameters);
            }
        }

        private IDbConnection CreateConnection()
        {
            return new SqliteConnection("Data Source=DAL/DB/social_network_bd.db");
        }
    }
}
