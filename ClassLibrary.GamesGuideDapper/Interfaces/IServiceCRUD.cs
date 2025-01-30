using ClassLibrary.Common.DTOs;

namespace ClassLibrary.GamesGuideDapper.Interfaces
{
    public interface IServiceCRUD<T>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
