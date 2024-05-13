using RepairBase.Models;

namespace RepairBase.Services
{
    public interface IMbRepairService
    {
        Task<List<MbRepair>> Get();
    }
}
