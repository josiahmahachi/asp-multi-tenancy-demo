using System.ComponentModel.DataAnnotations;

namespace MultiTenancyDemo.Contracts.Data
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; set; } = null;
    }
}
