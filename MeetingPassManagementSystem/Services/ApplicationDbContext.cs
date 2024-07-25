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

        public DbSet<MeetingPass> MeetingPasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingPass>()
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
