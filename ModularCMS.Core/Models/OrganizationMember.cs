using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class OrganizationMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Org_Member_ID { get; set; }

        [Required]
        public required int Resident_ID { get; set; }

        [Required]
        public required int Organization_ID { get; set; }

        [Required]
        public required DateOnly Date_Joined { get; set; }

        [Required]
        public required bool Is_Active { get; set; }

        [Required]
        public required string Position { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Resident_ID")]
        public required Resident Resident { get; set; }

        [ForeignKey("Organization_ID")]
        public required Organization Organization { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
