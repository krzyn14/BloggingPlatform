using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BloggingPlatform");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<User>(bp =>
            {
                bp.Property(bpi => bpi.Username).IsRequired().HasMaxLength(100);
                bp.Property(bpi => bpi.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<BlogPost>(bp =>
            {
                bp.Property(bpi => bpi.Title).IsRequired().HasMaxLength(100);
                bp.Property(bpi => bpi.Content).IsRequired();
                bp.Property(bpi => bpi.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
                bp.Property(bpi => bpi.UpdatedDate).HasDefaultValue(null);
                bp.Property(bpi => bpi.UserId).IsRequired();
                bp.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
            });
        }
    }
}

