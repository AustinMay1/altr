using System.Collections.Concurrent;
using altr_server.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace altr_server.Repositories;

public class UserRepo : IUserRepo
{
    private DbCtx _dbCtx;

    public UserRepo(DbCtx dbCtx) { _dbCtx = dbCtx; }

    public async Task<User?> CreateAsync(User u)
    {
        EntityEntry<User> added = await _dbCtx.User.AddAsync(u);

        int affected = await _dbCtx.SaveChangesAsync();

        return u;
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        ConcurrentDictionary<Guid, User> retreived = new ConcurrentDictionary<Guid, User>(_dbCtx.User.ToDictionary(u => u.UserId));

        return Task.FromResult(retreived is null ? Enumerable.Empty<User>() : retreived.Values);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        var found = await _dbCtx.User.SingleAsync(u => u.Username == username);

        return found ?? null;
    }

    public async Task<User?> UpdateAsync(User u, Guid userId)
    {
        _dbCtx.User.Update(u);

        await _dbCtx.SaveChangesAsync();

        return u;
    }

    public async Task<bool?> DeleteAsync(Guid userId)
    {
        User? u = await _dbCtx.User.FindAsync(userId);

        if (u is null) return false;

        return true;
    }
}
