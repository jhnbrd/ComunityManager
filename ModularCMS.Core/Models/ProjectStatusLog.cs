using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class ProjectStatusLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Status_ID { get; set; }

        [Required]
        public required int Project_ID { get; set; }

        [Required]
        public required DateTime timestamp { get; set; }

        public string? Additional_Notes { get; set; }

        [Required]
        public required int Updated_By_Employee_ID { get; set; }

        [ForeignKey("Project_ID")]
        public required Project Project { get; set; }

        [ForeignKey("Updated_By_Employee_ID")]
        public required Employee UpdatedByEmployee { get; set; }
    }
}
