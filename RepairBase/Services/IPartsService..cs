using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IPartsService
    {
        Task<List<Parts>> Get();        
        Task<Responses<int>> Delete(int id);
    }
}
