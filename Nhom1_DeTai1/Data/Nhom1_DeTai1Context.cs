using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nhom1_DeTai1.Models;

namespace Nhom1_DeTai1.Data
{
    public class Nhom1_DeTai1Context : DbContext
    {
        public Nhom1_DeTai1Context (DbContextOptions<Nhom1_DeTai1Context> options)
            : base(options)
        {
        }

        public DbSet<Nhom1_DeTai1.Models.User> User { get; set; } = default!;

        public DbSet<Nhom1_DeTai1.Models.Category>? Category { get; set; }

        public DbSet<Nhom1_DeTai1.Models.Brand>? Brand { get; set; }

        public DbSet<Nhom1_DeTai1.Models.Product>? Product { get; set; }
        public DbSet<Nhom1_DeTai1.Models.CartItem>? CartItem { get; set; }
        public DbSet<Nhom1_DeTai1.Models.Invoice>? Invoice { get; set; }

        public DbSet<Nhom1_DeTai1.Models.InvoiceDetail>? InvoiceDetail { get; set; }
    }
}
