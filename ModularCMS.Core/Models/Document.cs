using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Document_ID { get; set; }

        [Required]
        public required int Request_ID { get; set; }

        [Required]
        public required string Document_Type { get; set; }

        [Required]
        public required DateTime Date_Issued { get; set; }

        [Required]
        public required int Issued_By_ID { get; set; }

        [Required]
        public required string File_Path { get; set; }

        public float? Fee_Amount { get; set; }

        public int? Official_Receipt_ID { get; set; }

        [ForeignKey("Request_ID")]
        public required UserRequest Request { get; set; }

        [ForeignKey("Issued_By_ID")]
        public required Employee IssuedByEmployee { get; set; }

        [ForeignKey("Official_Receipt_ID")]
        public OfficialReceipt? OfficialReceipt { get; set; }
    }
}
