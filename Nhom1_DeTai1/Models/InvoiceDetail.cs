using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1_DeTai1.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public Product? Product{ get; set; }
        [ForeignKey("InvoiceId")]
        public int? InvoiceId { get; set; }
        public Invoice? Invoice{ get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }

    }
}
