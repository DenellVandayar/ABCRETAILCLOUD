using CloudPart3.Areas.Identity.Data;
using CloudPart3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CloudPart3.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Items> Items { get; set; }
    public DbSet<CartOrders> CartOrders { get; set; }
    public DbSet<CheckoutOrders> CheckoutOrders { get; set; }
    public DbSet<Documents> Documents { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CartOrders>()
            .HasOne(o => o.Item)
            .WithMany() // Assuming one item can have many orders
            .HasForeignKey(o => o.ItemId);
        base.OnModelCreating(builder);
        
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
