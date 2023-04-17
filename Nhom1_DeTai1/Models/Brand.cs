using System.ComponentModel.DataAnnotations;

namespace Nhom1_DeTai1.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(50)]
        public string? BrandName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
