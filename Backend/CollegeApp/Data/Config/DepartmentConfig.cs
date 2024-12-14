using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CollegeApp.Data.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(false);

            builder.HasData(new List<Department>()
            {
                new Department { Id = 1, DepartmentName = "Venkat", Description = "aaaaaaaaaaaa" },
                new Department { Id = 2, DepartmentName = "Neahnth", Description = "bbbbbbbbbbbb" }
            });


        }
    }
}
