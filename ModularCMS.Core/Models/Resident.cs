using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModularCMS.Core.Models;

namespace community_management_system.Api.Models
{
    public class Resident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Resident_ID { get; set; }

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
        public required bool Registered_Voter { get; set; }

        [Required]
        public required DateOnly Birth_Date { get; set; }

        [Required, MaxLength(100)]
        public required string Birth_Place { get; set; }

        [Required, MaxLength(20)]
        public required string Civil_Status { get; set; }

        [Required, MaxLength(50)]
        public required string Nationality { get; set; }

        [Required, MaxLength(50)]
        public required string Ethnicity { get; set; }

        [Required, MaxLength(100)]
        public required string Occupation { get; set; }

        [MaxLength(20)]
        public string? Contact_Number { get; set; }

        [EmailAddress, MaxLength(100)]
        public string? Email { get; set; }

        public int? Household_Head_ID { get; set; }

        [Required]
        public required int Purok { get; set; }

        [Required, MaxLength(50)]
        public required string Street { get; set; }

        [MaxLength(255)]
        public string? Profile_Picture_Url { get; set; }

        [MaxLength(100)]
        public string? Emergency_Person { get; set; }

        [MaxLength(20)]
        public string? Emergency_Number { get; set; }

        [Required]
        public required DateTime Created_At { get; set; }

        [Required]
        public required int Created_By_ID { get; set; }

        public DateTime? Updated_At { get; set; }
        public int? Updated_By_ID { get; set; }

        [ForeignKey("User_ID")]
        public required User User { get; set; }

        [ForeignKey("Household_Head_ID")]
        public Resident? HouseholdHead { get; set; }

        [ForeignKey("Created_By_ID")]
        public required User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public User? UpdatedByUser { get; set; }
    }
}
