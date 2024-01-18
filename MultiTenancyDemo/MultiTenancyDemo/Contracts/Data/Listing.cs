using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiTenancyDemo.Contracts.Data
{
    public class Listing : EntityBase
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;
        [Required, StringLength(150)]
        public string Slug { get; set; } = null!;
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
