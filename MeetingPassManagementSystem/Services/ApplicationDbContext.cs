using Microsoft.EntityFrameworkCore;
using MeetingPassManagementSystem.Models;

namespace MeetingPassManagementSystem.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<MeetingPass> MeetingPass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingPass>()
                .Property(mp => mp.CreatedDate)
                .HasDefaultValueSql("GETDATE()"); // Ensure this is set if you're using SQL Server
        }
    }

}
