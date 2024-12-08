using Microsoft.EntityFrameworkCore;
using OneLearn.Domain.Transactions.VoiceTranslation;

namespace OneLearn.Infrastructure.Common.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Language>()
                .HasIndex(x => new { x.language, x.language_Code }).IsUnique();
        }

        public DbSet<Language> Language { get; set; }
    }
}
