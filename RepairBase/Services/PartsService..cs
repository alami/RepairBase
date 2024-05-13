using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class PartsService : IPartsService
    {
        private readonly ApplicationDbContext _db;
        public PartsService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Parts>> Get()
        {
            List<Parts> objList = _db.Parts.ToList();
            return objList;
        }
        public async Task<Responses<int>> Delete(int id)
        {
            Responses<int> responses = new();
            try
            {
                var obj = await _db.Parts.FindAsync(id);
                if (obj == null)
                {
                    responses.Success = false;
                    responses.Message = $"Parts/Delete/{id} Not found";
                }
                else
                {
                    _db.Parts.Remove(obj);
                    _db.SaveChanges();
                    responses.Success = true;
                    responses.Message = $"Parts/Delete/{id} was deleted";
                }
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"Parts/Delete/{id} Exception {ex.Message}";
            }
            return responses;
        }

    }
}
