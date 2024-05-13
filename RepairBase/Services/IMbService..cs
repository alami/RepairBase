using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IMbService
    {
        Task<List<Mb>> Get();
        Task<Responses<int>> Delete(int id);
    }
}
