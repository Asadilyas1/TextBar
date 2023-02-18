using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TaxBarAssociation.Models
{
    [Table("Sliders")]
    public class Sliders
    {
        [Key]
        public int SliderID { get; set; }
        [Required]
        [NotMapped]
        public IFormFile imageFile { get; set; }
        public string SliderImage { get; set; }
        public int Ord { get; set; }
        public byte Visibility { get; set; }
    }
}
