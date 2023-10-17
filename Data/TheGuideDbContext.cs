using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TheGuide.Models;
using Microsoft.AspNetCore.Identity;

namespace TheGuide.Data;
public class TheGuideDbContext : IdentityDbContext<IdentityUser> //# TheGuideDbContext inherits from the IdentityDbContext<IdentityUser> class, rather than from DbContext
//# IdentityDbContext comes with a number of extra models and tables that will be added to the database. They include:
//# IdentityUser - this will hold login credentials for users
//# IdentityRole - this will hold the various roles that a use can have
//# IdentityUserRole - a many-to-many table between roles and users. These define which users have which roles.

{
    private readonly IConfiguration _configuration;
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<BikeType> BikeTypes { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    public TheGuideDbContext(DbContextOptions<TheGuideDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); //# this is a method

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole //# seeding the database with the identityrole information
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser //# seeding the database with the identityuser information
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<Owner>().HasData(new Owner[]
        {
        //
        });
        modelBuilder.Entity<BikeType>().HasData(new BikeType[]
        {

        });
        modelBuilder.Entity<Bike>().HasData(new Bike[]
        {

        });
        modelBuilder.Entity<WorkOrder>().HasData(new WorkOrder[]
        {

        });
    }
}