using ClassLibrary.Common;
using ClassLibrary.Common.DTOs;

namespace ClassLibrary.GamesGuide.Interfaces
{
    public interface IGameGuideEFService
    {
        public Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllGamesAsync(CancellationToken cancellationToken);
    }
}
