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
    public class VaultsController : Controller
    {
        private readonly VaultRepository db;

        public VaultsController(VaultRepository repo)
        {
            db = repo;
        }

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public IEnumerable<Vault> Get(int id)
        {
            return db.GetByUserId(id);
        }

        [HttpPost]
        public Vault Post([FromBody]Vault vault)
        {
            return db.Add(vault);
        }

        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if(ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, vault);
            }
            return null;
        }
        ///api/vaults/:id
       [HttpDelete("{id}")]
       public string Delete(int id)
       {
           return db.FindByIdAndRemove(id); 
       }
    }
}