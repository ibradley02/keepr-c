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

        public IEnumerable<Keep> GetByUserId(int id)
        {
            return _db.Query<Keep>($"SELECT * FROM keeps WHERE id = @id", id);
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = {id}", id);
        }

        public IEnumerable<Keep> GetByVaultId(int id)
        {
            return _db.Query<Keep>($@"
            SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepID
            WHERE (vaultId = {id})" );
        }

        public Keep Add(Keep keep)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO keeps (Name, Image, Description, UserId, Tags, Views)"
                        + " VALUES(@Name, @Image, @Description, @UserId, @Tags, @Views); SELECT LAST_INSERT_ID()", new
                        {
                            keep.Name,
                            keep.Image,
                            keep.Description,
                            keep.UserId,
                            keep.Tags,
                            keep.Views,
                        });
            keep.Id = id;
            return keep;
        }
        public Keep GetOneByIdAndUpdate(int id, Keep keep)
        {
            return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE keeps SET  
                    Views = @Views
                WHERE Id = {id};
                SELECT * FROM keeps WHERE id = {id};", keep);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM keeps WHERE Id = {id};");
            return success > 0 ? "success" : "not success";
        }
    }
}