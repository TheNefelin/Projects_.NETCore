using ClassLibrary.Common.Models;
using ClassLibrary.GamesGuideDapper.DTOs;

namespace ClassLibrary.GamesGuideDapper.Interfaces
{
    public interface IAuthGoogleService
    {
        Task<ResponseApi<LoggedToken>> LoginGoogleAsync(LoginGoogle login, CancellationToken cancellationToken);
    }
}
