namespace ClassLibrary.GamesGuideDapper.Interfaces
{
    public interface IServiceUserCRUD<T>
    {
        Task<IEnumerable<T>> GetAllByIdAsync(string Id_User, CancellationToken cancellationToken);
    }
}
