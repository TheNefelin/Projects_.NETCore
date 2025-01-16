using ClassLibrary.Common;
using ClassLibrary.GamesGuide.DTOs;

namespace ClassLibrary.GamesGuide.Interfaces
{
    public interface IGamesService
    {
        Task<ResponseApi<IEnumerable<GameDTO>>> GetAllAsync(CancellationToken cancellationToken);
        Task<ResponseApi<GameDTO>> GetByIdAsync(int Id, CancellationToken cancellationToken);
        Task<ResponseApi<GameDTO>> CreateAsync(GameDTO gameDTO, CancellationToken cancellationToken);
        Task<ResponseApi<GameDTO>> UpdateAsync(int Id, GameDTO gameDTO, CancellationToken cancellationToken);
        Task<ResponseApi<bool>> DeleteAsync(int Id, CancellationToken cancellationToken);
    }
}
