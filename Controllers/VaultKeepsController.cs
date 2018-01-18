using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr_c.Models;
using keepr_c.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace keepr_c.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepsController : Controller
    {
        private readonly KeepRepository keepDb;
        private readonly VaultRepository vaultDb;
        private readonly VaultKeepRepository vaultKeepDb;
        private readonly UserRepository userDb;

        public VaultKeepsController(KeepRepository KeepRepo, VaultRepository VaultRepo, VaultKeepRepository VaultKeepRepo, UserRepository UserRepo)
        {
            keepDb = KeepRepo;
            vaultDb = VaultRepo;
            vaultKeepDb = VaultKeepRepo;
            userDb = UserRepo;
        }

        [HttpGet("{id}")]
        public IEnumerable<Keep> Get(int id)
        {
            return keepDb.GetByUserId(id);
        }

        [Authorize]
        [HttpGet("vaults/{id}/keeps")]
        public IEnumerable<Keep> GetKeepsByVault(int id)
        {
            Console.WriteLine("GetByVault called!");
            return keepDb.GetByVaultId(id);
        }

        [Authorize]
        [HttpPost("vaults/{vaultId}/keeps")]
        public VaultKeep Post([FromBody]VaultKeep vaultkeep)
        {
            return vaultKeepDb.Add(vaultkeep);
        }

        [Authorize]
        [HttpDelete("vaults/{vaultId}/keeps/{keepId}")]
        public string Delete(int vaultId, int keepId)
        {
            return vaultKeepDb.FindByIdAndRemove(keepId, vaultId);
        }
    }
}