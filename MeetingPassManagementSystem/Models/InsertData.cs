using System.ComponentModel.DataAnnotations;

namespace MeetingPassManagementSystem.Models
{
    public class InsertData
    {

        
        [StringLength(50)]
        public string? MeetingTitle { get; set; } = "";

        [Required]
        public DateTime MeetingDate { get; set; }

        [Required]
        public TimeSpan MeetingTime { get; set; }

        [StringLength(20)]
        public string? PassStatus { get; set; } = "";

        [StringLength(50)]
        public required string CreatedBy { get; set; } = "";

        public DateTime? CreatedDate { get; set; }
    }
}
