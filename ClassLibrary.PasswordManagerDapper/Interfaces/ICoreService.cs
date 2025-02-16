using ClassLibrary.Common.Models;
using ClassLibrary.PasswordManagerDapper.DTOs;

namespace ClassLibrary.PasswordManagerDapper.Interfaces
{
    public interface ICoreService
    {
        Task<ResponseApi<CoreIVDTO>> RegisterAsync(CoreRequestDTO<object> request, CancellationToken cancellationToken);
        Task<ResponseApi<CoreIVDTO>> GetIVAsync(CoreRequestDTO<object> request, CancellationToken cancellationToken);
        Task<ResponseApi<IEnumerable<CoreDTO>>> GetAllAsync(CoreRequestDTO<object> request, CancellationToken cancellationToken);
        Task<ResponseApi<CoreDTO>> GetByIdAsync(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken);
        Task<ResponseApi<CoreDTO>> InsertAsync(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken);
        Task<ResponseApi<CoreDTO>> UpdateAsync(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken);
        Task<ResponseApi<object>> DeleteAsync(CoreRequestDTO<CoreDTO> request, CancellationToken cancellationToken);
    }
}
