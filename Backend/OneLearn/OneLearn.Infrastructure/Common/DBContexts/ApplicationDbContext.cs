using Microsoft.EntityFrameworkCore;
using OneLearn.Domain.Test;
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

            modelBuilder.Entity<Passage>();

            //modelBuilder.Entity<Test>();

            modelBuilder.Entity<Test>().HasData(
                new Test { id = 1, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 2, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 3, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 4, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 5, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 6, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 7, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 8, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 9, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) },
                new Test { id = 10, a = "a", b = "b", c = "c", d = "d", e = "e", f = "f", g = "g", h = "h", i = "i", j = "j", k = "k", l = "l", m = "m", n = "n", created_by = "asd", created_on = new DateTime(2024, 12, 16) }
             );
        }

        public DbSet<Language> Language { get; set; }
        public DbSet<Passage> Passages { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
