using Microsoft.EntityFrameworkCore;
using MeetingPassManagementSystem.Models;

namespace MeetingPassManagementSystem.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MeetingPass> MeetingPass { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeetingPass>()
                .Property(m => m.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
        }
}
