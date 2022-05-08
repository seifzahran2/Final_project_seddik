using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinalProjectSeddik.Models
{
    public class UploadProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "The Name cannot be more than 100 characters")]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Specialization cannot be more than 100 characters")]
        public string Specialization { get; set; }
        [Required]
        public string DriveLink { get; set; }

    }
}
