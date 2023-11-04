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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BookManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
             .HasOne(b => b.Category)
             .WithMany(c => c.Books)
             .HasForeignKey(b => b.CategoryId);


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(r => r.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(r => r.CategoryId);

                entity.HasIndex(c => c.Name).IsUnique();
                entity.HasKey(c => c.Id);
            }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

