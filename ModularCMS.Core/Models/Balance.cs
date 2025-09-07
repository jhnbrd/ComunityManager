using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Balance_ID { get; set; }

        [Required]  
        public required float Current_Balance { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; }

        [Required]
        public required string UpdatedReason { get; set; }
    }
}
