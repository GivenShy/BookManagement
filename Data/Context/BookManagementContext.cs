using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public partial class BookManagementContext:DbContext
    {
        public BookManagementContext(DbContextOptions<BookManagementContext> options):base(options) 
        { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; }= null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BookManagement;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => new { r.email, r.bookId });
                entity.HasOne(r => r.book).WithMany(b=>b.Reviews).HasForeignKey(r => r.bookId);
            });

            modelBuilder.Entity<Book>()
             .HasOne(b => b.Category)
             .WithMany(c => c.Books)
             .HasForeignKey(b => b.CategoryName);


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(r => r.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(r => r.CategoryName);

                entity.HasKey(c => c.Name);
            }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

