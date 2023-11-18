using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineBankingSystem.Areas.Identity.Data;
using OnlineBankingSystem.Models;

namespace OnlineBankingSystem.Data;

public class OnlineBankingSystemContext : IdentityDbContext<OnlineBankingSystemUser,IdentityRole,string>
{
    public OnlineBankingSystemContext(DbContextOptions<OnlineBankingSystemContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" });
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" });

        builder.ApplyConfiguration(new EntityConfiguration());
        builder.ApplyConfiguration(new EntityRoleConfiguration());

        
    }
}

public class EntityConfiguration : IEntityTypeConfiguration<OnlineBankingSystemUser>
{
    public void Configure(EntityTypeBuilder<OnlineBankingSystemUser> builder)
    {
        builder.Property(name => name.Name).HasMaxLength(50);
    }
}

public class EntityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {

    }
}