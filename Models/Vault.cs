using System;
using System.Collections.Generic;

namespace keepr_c.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}