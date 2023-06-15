using altr_server.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace altr_server.Repositories
{
    public class CommunityRepo : ICommunityRepo
    {
        private readonly DbCtx _dbCtx;

        public CommunityRepo(DbCtx dbCtx) { this._dbCtx = dbCtx; }

        public async Task<Community?> CreateAsync(Community c)
        {
            EntityEntry<Community> add = await _dbCtx.Community.AddAsync(c);

            await _dbCtx.SaveChangesAsync();

            return c;
        }

        public async Task<Community?> GetCommunityByName(string name)
        {
            var found = await _dbCtx.Community.SingleAsync(u => u.CommunityName == name);

            return found ?? null;
        }

        public async Task<bool?> DeleteCommunityAsync(string name)
        {
            var found = await _dbCtx.Community.FindAsync(name);

            if (found is null) return false;

            _dbCtx.Community.Remove(found); 
            
            await _dbCtx.SaveChangesAsync();

            return true;
        }
    }
}
