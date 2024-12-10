using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CollegeApp.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<T>
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.StudentName).IsRequired();
            builder.Property(x => x.StudentName).HasMaxLength(250);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);

            builder.HasData(new List<T>()
            {
                new T { Id = 1, StudentName = "Venkat", Address = "India", Email = "asd@gmail.com" },
                new T { Id = 2, StudentName = "Neahnth", Address = "India", Email = "asd1@gmail.com" }
            });
        }
    }
}
