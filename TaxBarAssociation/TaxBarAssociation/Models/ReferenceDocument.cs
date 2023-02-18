#nullable disable
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxBarAssociation.Models
{
    public class ReferenceDocument
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Upload PDF Document")]
        public string DocumentName { get; set; }

        [Required]
        [Display(Name ="Select Year")]
        
        public int DocumentYear { get; set; }
        [NotMapped]
        [Display(Name = "Upload PDF Document")]
        public IFormFile DocFile { get; set; }
    }
}
