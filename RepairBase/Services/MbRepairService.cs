﻿using Microsoft.EntityFrameworkCore;
using RepairBase.Data;
using RepairBase.Models;
using RepairBase.Services.Base;

namespace RepairBase.Services
{
    public class MbRepairService(ApplicationDbContext db) : IMbRepairService
    {
        private readonly ApplicationDbContext _db=db;
        public async Task<List<MbRepair>> Get()
        {
            List<MbRepair> objList = await _db.MbRepair.ToListAsync();
            return objList;
        }
        public async Task<Responses<int>> Create(MbRepair mbRepair)
        {
            Responses<int> responses = new();
            try
            {
                await _db.MbRepair.AddAsync(mbRepair);
                await _db.SaveChangesAsync();
                responses.Success = true;

            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"/MbRepair/create/ Exception {ex}";
            }
            return responses;
        }
        public async Task<Responses<int>> Delete(int id)
        {
            Responses<int> responses = new();
            try
            {
                var obj = await _db.MbRepair.FindAsync(id);
                if (obj == null)
                {
                    responses.Success = false;
                    responses.Message = $"MbRepair/Delete/{id} Not found";
                }
                else
                {
                    _db.MbRepair.Remove(obj);
                    _db.SaveChanges();
                    responses.Success = true;
                    responses.Message = $"MbRepair/Delete/{id} was deleted";
                }
            }
            catch (Exception ex)
            {
                responses.Success = false;
                responses.Message = $"MbRepair/Delete/{id} Exception {ex.Message}";
            }
            return responses;
        }

    }
}
