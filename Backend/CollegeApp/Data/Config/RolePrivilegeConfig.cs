using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Config
{
    public class RolePrivilegeConfig : IEntityTypeConfiguration<RolePrivillege>
    {
        public void Configure(EntityTypeBuilder<RolePrivillege> builder)
        {
            builder.ToTable("RolePrivillege");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.RolePrivilegeName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();

            builder.HasOne<Role>() // Specify the related entity type
                    .WithMany() // Configure the inverse navigation property
                    .HasForeignKey(privilege => privilege.RoleId) // Specify the foreign key
                    .HasConstraintName("FK_RolePrivileges_Roles");

            //builder.HasOne(n => n.Role)
            //    .WithMany(n => n.RolePrivilleges)
            //    .HasForeignKey(n => n.RoleId)
            //    .HasConstraintName("FK_RolePrivileges_Roles");
        }
    }
}
