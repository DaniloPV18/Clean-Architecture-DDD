using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByName(string nombreVideo);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
