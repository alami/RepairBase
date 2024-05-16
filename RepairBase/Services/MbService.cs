using Microsoft.EntityFrameworkCore;
using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Models.VM;
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

        public async Task<Responses<int>> CreateWtParts(MbPartsVM mbPartsVM)
        {
            Responses<int> responses = new();
            if (mbPartsVM == null)
            {
                responses.Success = false;
                responses.Message = $"/Mb/create/ MB with Parts is empty";
                return responses;
            }
            try
            {
                await _db.Mb.AddAsync(mbPartsVM.Mb);
                await _db.SaveChangesAsync();
                int mbId = mbPartsVM.Mb.Id;
                if (mbPartsVM.PartsIds.Length == 0)
                {
                    foreach (int partsId in mbPartsVM.PartsIds)
                    {
                        Mb2Parts mb2Parts = new Mb2Parts()
                        {
                            MbId = mbId,
                            PartsId = partsId,
                        };
                        await _db.Mb2Parts.AddAsync(mb2Parts);
                    }
                    await _db.SaveChangesAsync();
                }
                responses.Success = true;
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"/Mb/create/ Exception {ex}";
            }
            return responses;
        }

        public async Task<Responses<Mb>> Get(int id)
        {
            Responses<Mb> responses = new();
            if (id == null || id == 0)
            {
                responses.Success = false;
                responses.Message = $"Mb/Details/ no id or empty";
            }
            try
            {
                var obj = await _db.Mb.FindAsync(id);
                if (obj == null)
                {
                    responses.Success = false;
                    responses.Message = $"Mb/Details/ {id} Not found";
                }
                else
                {
                    responses.Data = obj;
                    responses.Success = true;
                };
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"Mb/Details/{id} Exception {ex.Message}";
            }
            return responses;
        }

        public async Task<Responses<Mb>> GetForUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Responses<int>> Edit(int id, Mb Mb)
        {
            throw new NotImplementedException();
        }
    }
}
