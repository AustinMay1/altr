using System.Collections.Concurrent;
using altr_server.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace altr_server.Repositories;

public class PostRepo : IPostRepo
{
    private readonly DbCtx _dbCtx;

    public PostRepo(DbCtx dbCtx) { this._dbCtx = dbCtx; }

    public async Task<Post?> CreateAsync(Post p)
    {
        EntityEntry<Post> add = await _dbCtx.Post.AddAsync(p);

        await _dbCtx.SaveChangesAsync();

        return p;
    }

    public async Task<Post?> GetPostsById(Guid id)
    {
        var found = await _dbCtx.Post.SingleAsync(p => p.PostId == id);

        return found ?? null;
    }
}