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
        public VaultKeepRepository(IDbConnection db) : base(db)
        {
        }

        public VaultKeep Add(VaultKeep vaultkeep)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO vaultkeeps (VaultId, KeepId, UserId)"
                        + " VALUES(@VaultId, @KeepId, @UserId); SELECT LAST_INSERT_ID()", new
                        {
                            VaultKeep.VaultId,
                            VaultKeep.KeepId,
                            VaultKeep.UserId
                        });
            VaultKeep.Id = id;
            return VaultKeep;
        }

        public string FindByIdAndRemove(int keepId, int vaultId)
        {
            var success = _db.Execute($@"
                DELETE FROM VaultKeeps WHERE vaultId = {vaultId} AND keepId = {keepId}
            ");
            return success > 0 ? "success" : "not success";
        }
    }
}