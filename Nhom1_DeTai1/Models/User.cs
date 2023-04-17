using System.ComponentModel.DataAnnotations;

namespace Nhom1_DeTai1.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        [Required]
        public string? UserRole { get; set; }

    }
}
