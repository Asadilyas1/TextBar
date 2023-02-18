using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TaxBarAssociation.Areas.Identity.Data;
using TaxBarAssociation.Models;

namespace TaxBarAssociation.Core.Repositories
{
    public class CoreCommitee : ICoreCommitee
    {
        private readonly AppDBContext _dbContext;
        public CoreCommitee(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteData(int id)
        {
            var core = await _dbContext.CoreCommite.FindAsync(id);
            if(core != null)
            {
                _dbContext.CoreCommite.Remove(core);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<CoreCommite> EditData(int id)
        {
            var core = await _dbContext.CoreCommite.FindAsync(id);
            return core;
        }

        public async Task<List<CoreCommite>> GetAllCoreCommitee()
        {
            var core = await _dbContext.CoreCommite.ToListAsync();
            return core;
        }

        public async Task SaveData(CoreCommite core)
        {
            _dbContext.CoreCommite.Add(core);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateData(CoreCommite core)
        {
            _dbContext.Update(core);
            await _dbContext.SaveChangesAsync();
        }
    }
}
