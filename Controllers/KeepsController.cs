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
    public class KeepsController : Controller
    {
        private readonly KeepRepository db;

        public KeepsController(KeepRepository repo)
        {
            db = repo;
        }

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return db.GetById(id);
        }

        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            return db.Add(keep);
        }

        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if(ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, keep);
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