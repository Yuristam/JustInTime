using JustInTime.WebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustInTime.WebApp.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<JustInTimeUser,IdentityRole, string>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<JustInTimeUser>
{
    public void Configure(EntityTypeBuilder<JustInTimeUser> builder)
    {
        builder.Property(u=>u.FirstName).HasMaxLength(255);
        builder.Property(u=>u.LastName).HasMaxLength(255);
    }
}