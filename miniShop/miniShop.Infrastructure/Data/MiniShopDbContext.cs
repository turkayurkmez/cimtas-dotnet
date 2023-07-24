using Microsoft.EntityFrameworkCore;
using miniShop.Entities;

namespace miniShop.Infrastructure.Data
{
    public class MiniShopDbContext : DbContext
    {

        public MiniShopDbContext(DbContextOptions<MiniShopDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100);


            //aşağıdaki yapılandırma ZORUNLU DEĞİL! EF Core sınıflardan One-To-Many ilişkisini anlayabilir.

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);


            List<Category> categories = new List<Category>
            {
                new Category{ Id=1, Name="Giyim"},
                new Category{ Id=2, Name="Elektronik"},
                new Category{ Id=3, Name="Müzik"}
            };

            modelBuilder.Entity<Category>().HasData(categories);

            List<Product> products = new()
            {
                new(){ Name = "Şort", CategoryId = 1, Description="Bermuda", Price=250, Discount=0.10m, Id=1, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Laptop ", CategoryId = 2, Description="Dell", Price=60000, Discount=0.10m, Id=2, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Davul", CategoryId = 3, Description="Davul seti", Price=12000, Discount=0.10m, Id=3, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Tişört", CategoryId = 1, Description="V Yaka", Price=250, Discount=0.10m, Id=4, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Ceket", CategoryId = 1, Description="Blazor", Price=250, Discount=0.10m, Id=5, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Top Crop", CategoryId = 1, Description="Top Crop", Price=250, Discount=0.10m, Id=6, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
                new(){ Name = "Tayt", CategoryId = 1, Description="Insta-tihgt", Price=250, Discount=0.10m, Id=7, ImageUrl="https://cdn.dsmcdn.com/ty329/product/media/images/20220209/18/47636736/357341652/2/2_org.jpg"},
            };

            modelBuilder.Entity<Product>().HasData(products);







        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

    }
}
