using ClassLibrary.Common.Models;
using ClassLibrary.F1Dapper.DTOs;

namespace ClassLibrary.F1Dapper.Interfaces
{
    public interface IF1Service
    {
        Task<ResponseApi<IEnumerable<TeamDTO>>> GetAll_Teams_Async(CancellationToken cancellationToken);
        Task<ResponseApi<IEnumerable<PilotDTO>>> GetAll_Pilots_Async(CancellationToken cancellationToken);
        Task<ResponseApi<IEnumerable<CircuitDTO>>> GetAll_Circuits_Async(CancellationToken cancellationToken);
    }
}
