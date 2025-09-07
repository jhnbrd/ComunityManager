using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class RequestStatusLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Request_Status_ID { get; set; }

        [Required]
        public required int Request_ID { get; set; }

        [Required, MaxLength(10)]
        public required string Status { get; set; }

        [Required]
        public required DateTime timestamp { get; set; }

        [Required]
        public required int Updated_By_Employee_ID { get; set; }

        public string? Additional_Notes { get; set; }

        [ForeignKey("Request_ID")]
        public required UserRequest Request { get; set; }

        [ForeignKey("Updated_By_Employee_ID")]
        public required Employee UpdatedByEmployee { get; set; }
    }
}