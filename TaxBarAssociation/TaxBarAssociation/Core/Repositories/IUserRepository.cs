using System.Collections.Generic;
using TaxBarAssociation.Areas.Identity.Data;

namespace TaxBarAssociation.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
