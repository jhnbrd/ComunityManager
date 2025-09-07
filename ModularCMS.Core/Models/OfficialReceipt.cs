using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class OfficialReceipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Receipt_ID { get; set; }

        [Required]
        public required DateTime Date_Issued { get; set; }

        [Required]
        public required float Amount_Paid { get; set; }

        [Required]
        public required string Purpose { get; set; }

        [Required]
        public required int Issued_By_ID { get; set; }

        [ForeignKey("Issued_By_ID")]
        public required User IssuedByUser { get; set; }
    }
}
