using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr_c.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr_c.Repositories
{
    public class KeepRepository : DbContext
    {
        public KeepRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = @id", id);
        }

        public Keep Add(Keep keep)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO keeps (Name, Image, Description, UserId, Tags)"
                        + " VALUES(@Name, @Image, @Description, @UserId, @Tags); SELECT LAST_INSERT_ID()", new
                        {
                            keep.Name,
                            keep.Image,
                            keep.Description,
                            keep.UserId,
                            keep.Tags
                        });
            keep.Id = id;
            return keep;
        }
        public Keep GetOneByIdAndUpdate(int id, Keep keep)
        {
            return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE keeps SET  
                    Name = @Name,
                    Description = @Description,
                    UserId = @UserId
                WHERE Id = {id};
                SELECT * FROM keeps WHERE id = {id};", keep);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM keeps WHERE Id = @Id
            ", id);
            return success > 0 ? "success" : "not success";
        }
    }
}