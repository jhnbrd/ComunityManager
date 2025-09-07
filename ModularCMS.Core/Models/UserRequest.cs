using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class UserRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Request_ID { get; set; }

        [Required]
        public required int Resident_ID { get; set; }

        [Required]
        public required string Request_Type { get; set; }

        [Required]
        public required DateTime Date_Submitted { get; set; }

        [Required, MaxLength(255)]
        public required string Request_Details { get; set; }

        [Required]
        public required int Latest_Status_ID { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Resident_ID")]
        public required Resident Resident { get; set; }

        [ForeignKey("Latest_Status_ID")]
        public required RequestStatusLog LatestStatus { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
