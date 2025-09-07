using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Employee_ID { get; set; }

        [Required]
        public required int User_ID { get; set; }

        [Required, MaxLength(50)]
        public required string First_Name { get; set; }

        [MaxLength(50)]
        public string? Middle_Name { get; set; }

        [Required, MaxLength(50)]
        public required string Last_Name { get; set; }

        [MaxLength(10)]
        public string? Suffix { get; set; }

        [Required, MaxLength(15)]
        public required string Gender { get; set; }

        [Required]
        public required string Role { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("User_ID")]
        public required User User { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
