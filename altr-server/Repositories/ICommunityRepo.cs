using altr_server.data;

namespace altr_server.Repositories
{
    public interface ICommunityRepo
    {
        Task<Community?> CreateAsync(Community community);
        Task<Community?> GetCommunityByName(string name);
        Task<bool?> DeleteCommunityAsync(string name);
    }
}
