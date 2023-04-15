﻿

namespace PmSystem.Domain.Entities
{
    public class Customer : EntityModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
