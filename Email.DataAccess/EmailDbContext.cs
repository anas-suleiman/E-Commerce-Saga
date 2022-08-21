using Microsoft.EntityFrameworkCore;

namespace Email.DataAccess
{
    public partial class EmailDbContext : DbContext
    {
        public EmailDbContext()
        {
        }

        public EmailDbContext(DbContextOptions<EmailDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Email> Emails { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("Email");

                entity.ToTable(tb => tb.IsTemporal(ttb =>
    {
        ttb.UseHistoryTable("EmailHistory", "dbo");
        ttb
            .HasPeriodStart("SysStartTime")
            .HasColumnName("SysStartTime");
        ttb
            .HasPeriodEnd("SysEndTime")
            .HasColumnName("SysEndTime");
    }
));

                entity.Property(e => e.Recipient).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
