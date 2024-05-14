using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IMbRepairService
    {
        Task<List<MbRepair>> Get();
        Task<Responses<int>> Create(MbRepair mbRepair);
        Task<Responses<int>> Delete(int id);
    }
}
