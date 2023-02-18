using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TaxBarAssociation.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
