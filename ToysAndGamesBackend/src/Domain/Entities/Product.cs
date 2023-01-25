using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? AgeRestriction { get; set; }
        public decimal Price { get; set; }
        public string? ImageURL { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
