using Microsoft.EntityFrameworkCore;

namespace Shop.DataAcess
{
    public partial class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Shop> Shops { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("ShopHistory", "dbo");
        ttb
            .HasPeriodStart("SysStartTime")
            .HasColumnName("SysStartTime");
        ttb
            .HasPeriodEnd("SysEndTime")
            .HasColumnName("SysEndTime");
    }
));

                entity.Property(e => e.Name).HasMaxLength(255);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
