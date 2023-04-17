using System.ComponentModel.DataAnnotations;

namespace Nhom1_DeTai1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
