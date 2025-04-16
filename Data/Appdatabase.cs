using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppTollCollection.Models;

namespace WebAppTollCollection.Data
{
    public class AppUser : IdentityUser<long>
    {
        public string? ProfilePicture { get; set; }
    }

    public class UserRole : IdentityRole<long>
    {

    }

    public class Appdatabase : IdentityDbContext<AppUser, UserRole, long>
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TollPlaza> TollPlazas { get; set; }
        public DbSet<TollRecord> TollRecords { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public Appdatabase(DbContextOptions op) : base(op)
        {

        }
    }
}   