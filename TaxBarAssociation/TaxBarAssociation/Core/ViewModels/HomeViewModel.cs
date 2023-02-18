using System.Collections;
using System.Collections.Generic;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Core.ViewModels
{
    public class HomeViewModel
    {
        public virtual IEnumerable<Sliders> sliders { get; set; }
        public virtual IEnumerable<Galleries> galleries { get; set; }
        public virtual IEnumerable<CoreCommite> core { get; set; }
    }
}
