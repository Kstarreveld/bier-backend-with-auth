using bier_backend_with_auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace bier_backend_with_auth.Auth
{
    public partial class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Bier> Biers { get; set; } = null!;

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bier>(entity =>
            {
                entity.ToTable("bier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brouwer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("brouwer");

                entity.Property(e => e.Gisting)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("gisting");

                entity.Property(e => e.InkoopPrijs)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("inkoop_prijs");

                entity.Property(e => e.Naam)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("naam");

                entity.Property(e => e.Perc).HasColumnName("perc");

                entity.Property(e => e.Type)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

          
            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
