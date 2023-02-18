using System.Collections.Generic;

namespace TaxBarAssociation.Models
{
    public class GalleryModel
    {
        ///<summary>
        /// Gets or sets Customers.
        ///</summary>
        public List<Galleries> galleries { get; set; }

        ///<summary>
        /// Gets or sets CurrentPageIndex.
        ///</summary>
        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }
    }
}
