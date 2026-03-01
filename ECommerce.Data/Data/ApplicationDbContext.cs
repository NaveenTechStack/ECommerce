using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); // Load all Identity tables 

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech Solution",
                    StreetAddress = "123 Tech St",
                    City = "Tech City",
                    PostalCode = "12121",
                    State = "TN",
                    PhoneNumber = "6669990000"
                },
                new Company
                {
                    Id = 2,
                    Name = "Vivid Books",
                    StreetAddress = "999 Vid St",
                    City = "Vid City",
                    PostalCode = "66666",
                    State = "IL",
                    PhoneNumber = "7779990000"
                },
                new Company
                {
                    Id = 3,
                    Name = "Readers Club",
                    StreetAddress = "999 Main St",
                    City = "Lala land",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "1113335555"
                },
                new Company
                {
                    Id = 4,
                    Name = "TCS",
                    StreetAddress = "999 Main St",
                    City = "Lala land",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "1113335555"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2
                    //ImageUrl = "\\images\\product\\ca099d7e-7a04-4c4b-8e23-1fb2acc8a75a.jpg"
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 3
                    //ImageUrl = "\\images\\product\\9ee59d00-f839-46e4-b522-6594846b4094.jpg"
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 1
                    //ImageUrl = "\\images\\product\\4a0d0803-6290-4c42-885b-e065baa05de2.jpg"
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 2
                    //ImageUrl = "\\images\\product\\8ca351b5-b750-4816-bfbc-c59dbfc784dd.jpg"
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3
                    //ImageUrl = "\\images\\product\\3307e311-5029-45a3-9542-2f907313fefe.jpg"
                }
                );

            modelBuilder.Entity<ProductImage>().HasData(

            new ProductImage
            {
                id = 1,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380690/31c0cbbd-711c-40f6-8b7b-e148ffb56bf0_wxykpt.jpg",
                ProductId = 1
            },
            new ProductImage
            {
                id = 2,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380690/2f51c4ff-0c38-4b29-aaf4-4654e25119c4_owon9f.jpg",
                ProductId = 1
            },
            new ProductImage
            {
                id = 3,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380826/d97be00d-e501-4e2b-9076-36441d302bfc_o65d90.jpg",
                ProductId = 2
            },
            new ProductImage
            {
                id = 4,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380868/5f652609-c116-4451-b420-f2dae144e355_qlupvd.jpg",
                ProductId = 3
            },
            new ProductImage
            {
                id = 5,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380916/fb44daa8-12d0-4828-b90c-42ca959fd4ee_ifgg0b.jpg",
                ProductId = 4
            },
            new ProductImage
            {
                id = 6,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380952/a9514402-1015-4c48-bf91-db8ded1bd351_p6dzuo.jpg",
                ProductId = 5
            },
            new ProductImage
            {
                id = 7,
                ImageUrl = "https://res.cloudinary.com/dwyvwdvqh/image/upload/v1772380996/bf56d857-5d8c-4e0e-97e6-a4d09cab2591_vivfca.jpg",
                ProductId = 6
            }
        );
        }
    }
}
