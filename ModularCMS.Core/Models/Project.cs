using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }

        [Required]
        public required string Project_Name { get; set; }

        public string? Project_Description { get; set; }

        [Required]
        public required DateOnly Start_Date { get; set; }

        public DateOnly? End_Date { get; set; }

        [Required]
        public required int Latest_Status_ID { get; set; }

        [Required]
        public required int Presented_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Latest_Status_ID")]
        public required ProjectStatusLog LatestStatus { get; set; }

        [ForeignKey("Presented_By_ID")]
        public required Employee PresentedByEmployee { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
