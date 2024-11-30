using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingPassManagementSystem.Models
{
    public class MeetingPass
    {
        [Key]
       
        public int PassID { get; set; }

        public string? MeetingTitle { get; set; }

        public DateTime MeetingDate { get; set; }

        public TimeSpan MeetingTime { get; set; }

        public string? PassStatus { get; set; }

        public string? CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Use Computed to set a default value
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow; // Default value

        public int PassCount { get; set; }

        public required ICollection<Review> Reviews { get; set; }
    }
}
