using ClassLibrary.Common.Models;
using ClassLibrary.PortfolioDapper.DTOs;

namespace ClassLibrary.PortfolioDapper.Interfaces
{
    public interface IPortfolioService
    {
        Task<ResponseApi<IEnumerable<DataUrlGrpDTO>>> GetAll_Urls_Async(CancellationToken cancellationToken);
        Task<ResponseApi<IEnumerable<DataProjectDTO>>> GetAll_Projects_Async(CancellationToken cancellationToken);
    }
}
