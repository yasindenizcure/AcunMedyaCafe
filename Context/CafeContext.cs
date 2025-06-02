using AcunMedyaCafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Context
{
    public class CafeContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-8TRT9BV\\MSSQLSERVER01; initial catalog=DbAcunMedyaCafe; integrated Security=true; TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
