using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproach.Models
{
    public class MaterialDBContext : DbContext
    {
        public MaterialDBContext(DbContextOptions<MaterialDBContext> options)
            : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }

        protected MaterialDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .HasMaxLength(500);

                entity.Property(e => e.Author)
                      .HasMaxLength(100);
            });
        }
    }
}
