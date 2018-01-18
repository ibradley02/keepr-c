using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr_c.Models;
using keepr_c.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr_c.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepsController : Controller
    {
        private readonly VaultKeepRepository db;

        public VaultKeepsController(VaultKeepRepository repo)
        {
            db = repo;
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
        public VaultKeep Post([FromBody]VaultKeep VaultKeep)
        {
            var user = HttpContext.User;
            var id = user.Identity.Name;

            UserReturnModel activeUser = null;

            if (id != null)
            {
                activeUser = userDb.GetUserById(id);
            }
            VaultKeep.UserId = activeUser.Id;

            return vaultKeepDb.Add(VaultKeep);
        }

        [Authorize]
        [HttpDelete("vaults/{vaultId}/keeps/{keepId}")]
        public string Delete(int vaultId, int keepId)
        {
            return vaultKeepDb.FindByRelatedIdsAndRemove(keepId, vaultId);
        }
    }
}