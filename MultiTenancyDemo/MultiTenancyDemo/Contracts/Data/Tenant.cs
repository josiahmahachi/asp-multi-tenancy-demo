using System.ComponentModel.DataAnnotations;

namespace MultiTenancyDemo.Contracts.Data
{
    public class Tenant : EntityBase
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;
        [Required, StringLength(20)]
        public string Code { get; set; } = null!;
        [Required, StringLength(500)]
        public string ConnectionString { get; set; } = null!;
    }
}
