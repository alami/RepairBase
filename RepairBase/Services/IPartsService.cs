using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public interface IPartsService
    {
        Task<List<Parts>> Get();
        Task<Responses<int>> Create(Parts parts);
        Task<Responses<int>> Edit(int id, Parts parts);

        Task<Responses<int>> Delete(int id);
    }
}
