using Microsoft.EntityFrameworkCore;
using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class PartsService(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) : IPartsService
    {
        private readonly ApplicationDbContext _db = db;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public async Task<List<Parts>> Get()
        {
            List<Parts> objList = await _db.Parts.ToListAsync();
            return objList;
        }
        public async Task<Responses<int>> Create(Parts parts)
        {
            Responses<int> responses = new();
            try
            {
                _db.Parts.Add(parts);
                await _db.SaveChangesAsync();
                responses.Success = true;

            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"/parts/create/ Exception {ex}";
            }
            return responses;
        }
        public async Task<Responses<int>> Edit(int id, Parts parts)
        {
            Responses<int> responses = new();
            try
            {
                _db.Parts.Update(parts);
                await _db.SaveChangesAsync();
                responses.Success = true;

            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"/parts/edit/{id} Exception {ex}";
            }
            return responses;
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
