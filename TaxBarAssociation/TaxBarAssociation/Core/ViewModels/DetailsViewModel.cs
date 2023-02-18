using System.Collections.Generic;
using System.Xml.Linq;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Core.ViewModels
{
    public class DetailsViewModel
    {
        public virtual int commentCount { get; set; }
        public virtual Blog comments { get; set; }
        public virtual BlogData blogData { get; set; }
        public virtual Blog Curr { get; set; }
        public virtual Blog Next { get; set; }
        public virtual Blog Prev { get; set; }
    }
}
