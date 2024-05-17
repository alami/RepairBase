using Microsoft.EntityFrameworkCore;
using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class Mb2PartsService(ApplicationDbContext db) : IMb2PartsService
    {
        private readonly ApplicationDbContext _db = db;
        public async Task<List<Mb2Parts>> Get()
        {
            List<Mb2Parts> objList = await _db.Mb2Parts.ToListAsync();
            return objList;
        }
        public async Task<List<Mb2Parts>> GetByMbId(int mbId)
        {
            List<Mb2Parts> objList = await _db.Mb2Parts.ToListAsync();
            return objList;
        }

        public async Task<List<Mb2Parts>> GetByPartsId(int partsId)
        {
            List<Mb2Parts> objList = await _db.Mb2Parts.ToListAsync();
            return objList;
        }
        public async Task<Responses<int>> Create(int idMb, int idParts)
        {
            Responses<int> responses = new();            
            try
            {
                Mb2Parts mb2Parts = new Mb2Parts()
                {
                    MbId = idMb,
                    PartsId = idParts,
                };
                await _db.Mb2Parts.AddAsync(mb2Parts);
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
                var obj = await _db.Mb2Parts.FindAsync(id);
                if (obj == null)
                {
                    responses.Success = false;
                    responses.Message = $"Mb2Parts/Delete/{id} Not found";
                }
                else
                {
                    _db.Mb2Parts.Remove(obj);
                    await _db.SaveChangesAsync();
                    responses.Success = true;
                    responses.Message = $"Mb2Parts/Delete/{id} was deleted";
                }
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"Mb2Parts/Delete/{id} Exception {ex.Message}";
            }
            return responses;
        }

    }
}
