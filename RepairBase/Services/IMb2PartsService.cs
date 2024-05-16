using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IMb2PartsService
    {
        Task<List<Mb2Parts>> Get();
        Task<Responses<int>> Create(int idMb, int idParts);
        Task<Responses<int>> Delete(int id);

    }
}
