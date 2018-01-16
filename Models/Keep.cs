using System;

namespace keepr_c.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal KeepReturnModel GetReturnModel()
        {
            return new KeepReturnModel()
            {
                Id = Id,
                Username = Username,
                Email = Email
            };
        }
    }
}