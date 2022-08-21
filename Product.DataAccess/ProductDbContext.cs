using Microsoft.EntityFrameworkCore;

namespace Product.DataAccess
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext() {}

        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options){}

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
                {
                    ttb.UseHistoryTable("ProductHistory", "dbo");

                    ttb.HasPeriodStart("SysStartTime").HasColumnName("SysStartTime");

                    ttb.HasPeriodEnd("SysEndTime").HasColumnName("SysEndTime");
                }
                ));
                entity.Property(e => e.Name).HasMaxLength(255);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
