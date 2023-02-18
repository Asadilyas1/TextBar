using System.Collections;
using System.Collections.Generic;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Core.ViewModels
{
    public class BlogViewModel
    {
        public string CatName { get; set; }
        public virtual BlogModel blogModel { get; set; }
    }
}
