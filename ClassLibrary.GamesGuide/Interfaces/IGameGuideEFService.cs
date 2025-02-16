using ClassLibrary.Common.DTOs;
using ClassLibrary.Common.Models;

namespace ClassLibrary.GamesGuide.Interfaces
{
    public interface IGameGuideEFService
    {
        public Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllGamesAsync(CancellationToken cancellationToken);
    }
}
