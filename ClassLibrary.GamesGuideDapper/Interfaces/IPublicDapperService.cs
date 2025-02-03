using ClassLibrary.Common;
using ClassLibrary.Common.DTOs;

namespace ClassLibrary.GamesGuideDapper.Interfaces
{
    public interface IPublicDapperService
    {
        Task<ResponseApi<IEnumerable<DataGameDTO>>> GetAllAsync(string Id_User, CancellationToken cancellationToken);
    }
}
