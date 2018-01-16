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
    public class VaultRepository : DbContext
    {
        public VaultRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM vaults");
        }

        public Vault GetById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = @id", id);
        }

        public Vault Add(Vault vault)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO vaults (Name, Description, UserId)"
                        + " VALUES(@Name, @Description, @UserId); SELECT LAST_INSERT_ID()", new
                        {
                            vault.Name,
                            vault.Description,
                            vault.UserId
                        });
            vault.Id = id;
            return vault;
        }
        public Vault GetOneByIdAndUpdate(int id, Vault vault)
        {
            return _db.QueryFirstOrDefault<Vault>($@"
                UPDATE vaults SET  
                    Name = @Name,
                    Description = @Description,
                    UserId = @UserId
                WHERE Id = {id};
                SELECT * FROM vaults WHERE id = {id};", vault);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"
                DELETE FROM vaults WHERE Id = @id
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}