using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(maximumLength:50, MinimumLength = 2)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [Range(0, 100)]
        public int? AgeRestriction { get; set; }
        [Required]
        [Range(1,1000)]
        public decimal? Price { get; set; }
        public string? ImageURL { get; set; }
        [Required]
        public int? CompanyId { get; set; }
    }
}
