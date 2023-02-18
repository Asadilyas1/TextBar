using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxBarAssociation.Models
{
    [Table("Galleries")]
    public class Galleries
    {
        [Key]
        public int GalleryID { get; set; }
        public string GalleryImage { get; set; }
    }
}
