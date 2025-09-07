using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Expenses_ID { get; set; }

        [Required]
        public required int Official_Receipt_ID { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required float Amount { get; set; }

        [Required]
        public required DateOnly Date_Incurred { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Official_Receipt_ID")]
        public required OfficialReceipt OfficialReceipt { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
