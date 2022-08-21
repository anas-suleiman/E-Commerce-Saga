using Microsoft.EntityFrameworkCore;

namespace Identity.DataAccess
{
    public partial class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
        {
        }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Identity> Identities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>(entity =>
            {
                entity.ToTable("Identity");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("IdentityHistory", "dbo");
        ttb
            .HasPeriodStart("SysStartTime")
            .HasColumnName("SysStartTime");
        ttb
            .HasPeriodEnd("SysEndTime")
            .HasColumnName("SysEndTime");
    }
));

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
