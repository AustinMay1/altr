using altr_server.data;

namespace altr_server.Repositories;

public interface IUserRepo
{
    Task<User?> CreateAsync(User u);
    Task<User?> UpdateAsync(User u, Guid id);
    Task<bool?> DeleteAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> GetByUsernameAsync(string username);
}
