using RepairBase.Data;
using RepairBase.Models;

namespace RepairBase.Services
{
    public class MbRepairService : IMbRepairService
    {
        private readonly ApplicationDbContext _db;
        public MbRepairService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<MbRepair>> Get()
        {
            List<MbRepair> objList = _db.MbRepair.ToList();
            return objList;
        }
    }
}
