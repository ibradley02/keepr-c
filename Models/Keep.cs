using System;
using System.Collections.Generic;

namespace keepr_c.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string Tags { get; set; }

    }
}