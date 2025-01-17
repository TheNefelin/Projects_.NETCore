using ClassLibrary.Common;
using ClassLibrary.GamesGuide.DTOs;

namespace ClassLibrary.GamesGuide.Interfaces
{
    public interface IPublicService
    {
        public Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllGamesAsync(CancellationToken cancellationToken);
    }
}
