namespace MeetingPassManagementSystem.Models
{
    public class Review
    {
        public int ReviewID { get; set; } // Primary Key
        public required string ReviewerName { get; set; }
        public required string Comment { get; set; }
        public int Rating { get; set; } // Rating out of 5
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign Key to MeetingPass
        public int MeetingPassId { get; set; }  // This will be the foreign key
        public required MeetingPass MeetingPass { get; set; } // Navigation property
    }
}
