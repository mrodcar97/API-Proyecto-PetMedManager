using Domain;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services
{
    public interface IShiftService
    {
        Task<List<Shift>> GetShifts();
        Task<Shift> GetShiftById(int id);
        Task<List<Shift>> GetShiftsByDate(DateOnly date);
        Task<List<Shift>> GetShiftsForMonth(int year, int month);
        Task AddShift(Shift Shift);
        Task UpdateShift(Shift Shift);
        Task DeleteShift(int id);
    }

    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _ShiftRepository;

        public ShiftService(IShiftRepository ShifttRepository)
        {
            _ShiftRepository = ShifttRepository ?? throw new ArgumentNullException(nameof(ShifttRepository));
        }

        public async Task<List<Shift>> GetShifts()
        {
            return await _ShiftRepository.GetShifts();
        }

        public async Task<List<Shift>> GetShiftsByDate(DateOnly date)
        {
            return await _ShiftRepository.GetShiftsByDate(date);
        }

        public async Task<List<Shift>> GetShiftsForMonth(int year, int month)
        {
            return await _ShiftRepository.GetShiftsForMonth(year,month);
        }

        public async Task<Shift> GetShiftById(int id)
        {
            return await _ShiftRepository.GetShiftById(id);
        }

        public async Task AddShift(Shift Shift)
        {
            if (Shift == null)
                throw new ArgumentNullException(nameof(Shift));

            await _ShiftRepository.AddShift(Shift);
        }

        public async Task UpdateShift(Shift Shift)
        {
            if (Shift == null)
                throw new ArgumentNullException(nameof(Shift));

            await _ShiftRepository.UpdateShift(Shift);
        }

        public async Task DeleteShift(int id)
        {
            await _ShiftRepository.DeleteShift(id);
        }
    }
}

