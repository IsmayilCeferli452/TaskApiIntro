using ApiIntro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;

namespace ApiIntro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { 
                    Id = 1,
                    Name = "Category 1",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Id = 3,
                    Name = "Category 3",
                    CreatedDate = DateTime.Now,
                },
                new Category
                {
                    Id = 4,
                    Name = "Category 4",
                    CreatedDate = DateTime.Now,
                });


            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    Id = 1,
                    Title = "Book 1",
                    Author = "Author 1",
                    CreatedDate = DateTime.Now,
                },
                new Book
                {
                    Id = 2,
                    Title = "Book 2",
                    Author = "Author 2",
                    CreatedDate = DateTime.Now,
                },
                new Book
                {
                    Id = 3,
                    Title = "Book 3",
                    Author = "Author 3",
                    CreatedDate = DateTime.Now,
                },
                new Book
                {
                    Id = 4,
                    Title = "Book 4",
                    Author = "Author 4",
                    CreatedDate = DateTime.Now,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
