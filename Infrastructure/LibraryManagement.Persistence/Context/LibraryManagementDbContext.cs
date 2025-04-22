using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Persistence.Context
{
    public class LibraryManagementDbContext:DbContext
    {
        public LibraryManagementDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Author> Authors { get; set; } 
        public DbSet<Book> Books { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedDate = now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
            //burda SaveChangesAsync'i ezip eklenenlere CreatedDate, güncellenenlere UpdatedDate veriyoruz , 
           // böylece her seferinde elle tarih atamakla uğraşmıyoruz

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .HasMaxLength(200)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasOne(e => e.Author)
                .WithMany(e => e.Books)
                .HasForeignKey(e => e.Author.Id)    
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");
        }
    }
}
