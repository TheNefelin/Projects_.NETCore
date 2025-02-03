namespace ClassLibrary.GamesGuideDapper.Interfaces
{
    public interface IApiKeyService
    {
        Task<bool> ValidateApiKey(string apiKey);
    }
}
