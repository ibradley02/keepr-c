using System;

namespace keepr_c.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal VaultReturnModel GetReturnModel()
        {
            return new VaultReturnModel()
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}