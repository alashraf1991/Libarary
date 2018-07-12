using LibararyData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibararyData
{
    public class LibararyContext : DbContext
    {
        public LibararyContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<CheckOut> CheckOuts { get; set; }
        public DbSet<CheckOutHistory> GetCheckOutHistories { get; set; }
        public DbSet<LibararyBranch> LibararyBranches { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<LibararyCard> LibararyCards { get; set; }        
        public DbSet<Patron> Patrons { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<LibararyAssets> libararyAssets { get; set; }
        public DbSet<Hold> Holds { get; set; }


    }
}
