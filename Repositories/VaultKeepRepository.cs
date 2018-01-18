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
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        public VaultKeep Add(VaultKeep vaultkeep)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO vaultkeeps (UserId, VaultId, KeepId)"
                        + $" VALUES(@UserId, @VaultId, @KeepId); SELECT LAST_INSERT_ID()", new
                        {
                            vaultkeep.UserId, 
                            vaultkeep.VaultId,
                            vaultkeep.KeepId
                        });
            vaultkeep.Id = id;
            return vaultkeep;
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