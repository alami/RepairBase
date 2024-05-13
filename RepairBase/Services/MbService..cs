using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class MbService : IMbService
    {
        private readonly ApplicationDbContext _db;
        public MbService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Mb>> Get()
        {
            List<Mb> objList = _db.Mb.ToList();
            return objList;
        }
        public async Task<Responses<int>> Create(Mb mb)
        {
            Responses<int> responses = new();
            try
            {
                _db.Mb.Add(mb);
                _db.SaveChanges();
                responses.Success = true;

            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"/Mb/create/ Exception {ex}";
            }
            return responses;
        }

        public async Task<Responses<int>> Delete(int id)
        {
            Responses<int> responses = new();
            try
            {
                var obj = await _db.Mb.FindAsync(id);
                if (obj == null)
                {
                    responses.Success = false;
                    responses.Message = $"Mb/Delete/{id} Not found";
                }
                else
                {
                    _db.Mb.Remove(obj);
                    _db.SaveChanges();
                    responses.Success = true;
                    responses.Message = $"Mb/Delete/{id} was deleted";
                }
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"Mb/Delete/{id} Exception {ex.Message}";
            }
            return responses;
        }
    }
}
