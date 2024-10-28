using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lieb_Denisa_Maria_Lab2.Models;

namespace Lieb_Denisa_Maria_Lab2.Data
{
    public class Lieb_Denisa_Maria_Lab2Context : DbContext
    {
        public Lieb_Denisa_Maria_Lab2Context (DbContextOptions<Lieb_Denisa_Maria_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Lieb_Denisa_Maria_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Lieb_Denisa_Maria_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Lieb_Denisa_Maria_Lab2.Models.Author> Author { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books) 
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
