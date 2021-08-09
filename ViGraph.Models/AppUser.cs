using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
    public enum Language {
        TR,
        EN
    }

    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
        
        [Column(TypeName = "enum('TR','EN')")]
        public Language Language { get; set; }
    }
}
