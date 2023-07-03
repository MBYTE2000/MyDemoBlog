using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDemoBlog.Domain.Entities;

namespace MyDemoBlog.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Article> Articles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole 
            {
                Id = "4855F6EF-D1E1-4A61-BA65-D41171611686",
                Name = "admin",
                 NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "AF936675-90FC-47E3-A2DE-9A03231018D5",
                Name = "user",
                NormalizedName = "USER"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "BBC859EB-01D4-4B97-941A-0E3F7C007794",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "4855F6EF-D1E1-4A61-BA65-D41171611686",
                UserId = "BBC859EB-01D4-4B97-941A-0E3F7C007794"
            });

            builder.Entity<Article>().HasData(new Article
            {
                Id = new Guid("D0E76E14-395C-48D0-B7D8-446A918ED634"),
                UserID = new Guid("BBC859EB-01D4-4B97-941A-0E3F7C007794"),
                Title = "Test Article",
            });
        }
    }
}
