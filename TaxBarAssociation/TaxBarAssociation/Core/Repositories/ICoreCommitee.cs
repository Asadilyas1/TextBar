using System.Collections.Generic;
using System.Threading.Tasks;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Core.Repositories
{
    public interface ICoreCommitee
    {
        public Task<List<CoreCommite>> GetAllCoreCommitee();
        public Task SaveData(CoreCommite core);
        public Task<CoreCommite> EditData(int id);
        public Task UpdateData(CoreCommite core);
        public Task DeleteData(int id);
    }
}
