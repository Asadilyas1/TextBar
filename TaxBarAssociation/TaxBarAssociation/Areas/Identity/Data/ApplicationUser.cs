using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TaxBarAssociation.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string FaxNo { get; set; }
        public string OffNo { get; set; }
        public string ResAddress { get; set; }
        public string BarCouncil { get; set; }
        public string MemberNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {

    }
}
