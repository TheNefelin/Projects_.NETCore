namespace ClassLibrary.Auth.Interfaces
{
    public interface IApiKeyService
    {
        Task<bool> ValidateApiKey(string apiKey);
    }
}
