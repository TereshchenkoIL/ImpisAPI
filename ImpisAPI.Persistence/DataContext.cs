using ImpisAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImpisAPI.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserPhoto> UserPhotos{ get; set; }
        public DbSet<ReservoirPhoto> ReservoirPhotos{ get; set; } 
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Topic> Topics{ get; set; }
        public DbSet<IdealResult> IdealResults { get; set; }
        public DbSet<IdealWaterParameters> IdealWaterParameters { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Reservoir> Reservoirs { get; set; }
        public DbSet<ReservoirType> ReservoirTypes { get; set; }
        public DbSet<Sales> Sales{ get; set; }
        public DbSet<Suggestion> Suggestions{ get; set; }
        public DbSet<WaterParameters> WaterParameters{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Comment>()
                .HasOne(t => t.Topic)
                .WithMany(c => c.Comments)
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}