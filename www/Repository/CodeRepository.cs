using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using www.Models.Entities;

namespace www.Repository
{
    public class CodeRepository : IRepository<CodeEntity>
    {
        private string connectionString = "User ID=postgres;Password=tngml82@1;Host=35.185.172.0;Port=5432;Database=justsoo.net;Pooling=true;";

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(CodeEntity item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO code(code,parents_code,name,value) VALUES(@code,@parents_code,@name,@value)", item);
            }

        }

        public IEnumerable<CodeEntity> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<CodeEntity>("SELECT * FROM code");
            }
        }

        public IEnumerable<CodeEntity> FindAll(string parents_code)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<CodeEntity>("SELECT * FROM code WHERE parents_code = @parents_code ORDER BY code", new { parents_code = parents_code });
            }
        }

        public CodeEntity FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<CodeEntity>("SELECT * FROM code WHERE code_seq = @code_seq", new { code_seq = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM code WHERE code_seq=@code_seq", new { Id = id });
            }
        }

        public void Update(CodeEntity item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE code SET code = @code,  parents_code  = @parents_code, name= @name, value= @value WHERE code_seq = @code_seq", item);
            }
        }
    }
}