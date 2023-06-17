using altr_server.data;

namespace altr_server.Repositories;

public interface IPostRepo
{
    Task<Post?> CreateAsync(Post p);
    Task<Post?> GetPostsById(Guid id);
}