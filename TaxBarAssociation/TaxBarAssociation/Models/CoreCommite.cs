using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxBarAssociation.Models
{
    [Table("CoreCommitee")]
    public class CoreCommite
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
    }
}
