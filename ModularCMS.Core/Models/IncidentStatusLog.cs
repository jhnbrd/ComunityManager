using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class IncidentStatusLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Incident_Status_ID { get; set; }

        [Required]
        public required int Incident_ID { get; set; }

        [Required]
        public required string Status { get; set; }

        [Required]
        public required DateTime timestamp { get; set; }

        [Required]
        public required int Updated_By_Employee_ID { get; set; }

        public string? Additional_Notes { get; set; }

        [ForeignKey("Incident_ID")]
        public required IncidentReport IncidentReport { get; set; }

        [ForeignKey("Updated_By_Employee_ID")]
        public required Employee UpdatedByEmployee { get; set; }
    }
}
