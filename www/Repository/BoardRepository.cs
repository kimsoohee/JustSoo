using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using www.Models.Entities;

namespace www.Repository
{
    public class BoardRepository : IRepository<BoardEntity>
    {
        private string connectionString = "User ID=postgres;Password=tngml82@1;Host=35.185.172.0;Port=5432;Database=justsoo.net;Pooling=true;";

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(BoardEntity item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO public.board(board_type, board_type_code, subject, contents, user_seq) " +
                    "VALUES (@board_type, @board_type_code, @subject, @contents, @user_seq);", item);
            }

        }

        public IEnumerable<BoardEntity> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BoardEntity>("SELECT * FROM public.board");
            }
        }

        public IEnumerable<BoardEntity> FindAll(string board_type, string board_type_code)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BoardEntity>("SELECT (ROW_NUMBER() OVER()) AS rownum,* FROM public.board WHERE board_type = @board_type AND board_type_code = @board_type_code " +
                    "ORDER BY reg_date DESC", new { board_type = board_type, board_type_code = board_type_code });
            }
        }

        public BoardEntity FindByTop1(string board_type, string board_type_code)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BoardEntity>("SELECT * FROM public.board WHERE board_type = @board_type AND board_type_code = @board_type_code " + 
                    "ORDER BY reg_date DESC LIMIT 1", new { board_type = board_type, board_type_code = board_type_code }).FirstOrDefault();
            }
        }

        public BoardEntity FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<BoardEntity>("SELECT * FROM public.board WHERE board_seq = @board_seq", new { board_seq = id }).FirstOrDefault();
            }
        } 

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM public.board WHERE board_seq=@board_seq", new { board_seq = id });
            }
        }

        public void Update(BoardEntity item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE  public.board SET subject = @subject,  contents  = @contents WHERE board_seq = @board_seq", item);
            }
        }
    }
}