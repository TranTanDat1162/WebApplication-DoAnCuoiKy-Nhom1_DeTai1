using System.ComponentModel.DataAnnotations;

namespace Nhom1_DeTai1.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        [StringLength(50)]
        public string? CustomerFirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? CustomerLastName { get; set;}
        [Required]
        [StringLength(50)]
        public string? CustomerAddress { get; set;}
    }
}
