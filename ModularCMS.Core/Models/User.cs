using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace ModularCMS.Core.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }

        [Required, MaxLength(20)]
        public required string Username { get; set; }

        [Required, MaxLength(500)]
        public required string Password_Hash { get; set; }

        [Required, StringLength(255)]
        public string Password_Salt { get; set; }

        [Required]
        public required string User_Type { get; set; }

        [Required]
        public required bool Is_Active { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }
        
        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
