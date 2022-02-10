using Microsoft.EntityFrameworkCore;
using Smart_Cookers.Models;

namespace Smart_Cookers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
               }

        public DbSet<Role> Roles { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
    }
}

