using Microsoft.EntityFrameworkCore;
using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class MbService(ApplicationDbContext db) : IMbService
    {
        private readonly ApplicationDbContext _db = db;
        public async Task<List<Mb>> Get()
        {
            List<Mb> objList = await _db.Mb.ToListAsync();
            return objList;
        }
        public async Task<Responses<int>> Create(Mb mb)
        {
            Responses<int> responses = new();
            if (mb == null)
            {
                responses.Success = false;
                responses.Message = $"/Mb/create/ MB is empty";
                return responses;
            }
            try
            {
                await _db.Mb.AddAsync(mb);
                await _db.SaveChangesAsync();
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
