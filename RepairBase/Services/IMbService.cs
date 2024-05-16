using RepairBase.Models;
using RepairBase.Models.VM;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IMbService
    {
        Task<List<Mb>> Get();
        Task<Responses<int>> Create(Mb mb);
        Task<Responses<int>> CreateWtParts(MbPartsVM mbPartsVM);
        Task<Responses<int>> Delete(int id);
        Task<Responses<Mb>> Get(int id);
        Task<Responses<Mb>> GetForUpdate(int id);
        Task<Responses<int>> Edit(int id, Mb mb);

    }
}
