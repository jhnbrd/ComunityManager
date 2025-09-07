using community_management_system.Api.Models;
using ModularCMS.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularCMS.Core.Models
{
    [Table("Announcements")]
    public class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Announcement_ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string Announcement_Type { get; set; }

        [Required]
        [StringLength(20)]
        public string Priority_Level { get; set; }

        [Required]
        [StringLength(50)]
        public string Target_Audience { get; set; }

        [ForeignKey("Target_Organization")]
        public int? Target_Organization_ID { get; set; }

        [Required]
        public bool Is_Active { get; set; }

        [Required]
        public DateTime Date_Published { get; set; }

        public DateTime? Date_Expires { get; set; }

        [StringLength(255)]
        public string? Attachment_Path { get; set; }

        [Required]
        public DateTime Created_At { get; set; }

        [Required]
        public int Created_By_ID { get; set; }

        public DateTime? Updated_At { set; get; }

        public int? Updated_By_ID { get; set; }

        public virtual Organization? Target_Organization { get; set; }

        [ForeignKey("Created_By_ID")]
        public virtual User CreatedByUser { get; set; }

        [ForeignKey("Updated_By_ID")]
        public virtual User? UpdatedByUser { get; set; }
    }
}
