using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class IncidentReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Incident_ID { get; set; }

        [Required]
        public required int Request_ID { get; set; }

        [Required]
        public required int Plaintiff_ID { get; set; }

        public int? Accused_ID { get; set; }

        [Required]
        public required string Accused_Name { get; set; }

        [Required]
        public required string Incident_Type { get; set; }

        [Required]
        public required string Location { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required DateOnly Date_Occured { get; set; }

        [Required]
        public required DateOnly Date_Reported { get; set;}

        [Required]
        public required int Latest_Status_ID { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Request_ID")]
        public required UserRequest Request { get; set; }

        [ForeignKey("Plaintiff_ID")]
        public required Resident Plaintiff { get; set; }

        [ForeignKey("Accused_ID")]
        public Resident? Accused { get; set; }

        [ForeignKey("Latest_Status_ID")]
        public required IncidentStatusLog LatestStatus { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
