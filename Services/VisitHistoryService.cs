using Domain;
using Repositories;

namespace Services
{
    public interface IVisitHistoryService
    {
        Task<List<VisitHistory>> GetVisitHistories();
        Task<VisitHistory> GetVisitHistoryById(int id);
        Task<List<VisitHistory>> GetVisitHistoriesByPet(int id);
        Task AddVisitHistory(VisitHistory VisitHistory);
        Task UpdateVisitHistory(VisitHistory VisitHistory);
        Task DeleteVisitHistory(int id);
    }

    public class VisitHistoryService : IVisitHistoryService
    {
        private readonly IVisitHistoryRepository _VisitHistoryRepository;

        public VisitHistoryService(IVisitHistoryRepository VisitHistoryRepository)
        {
            _VisitHistoryRepository = VisitHistoryRepository ?? throw new ArgumentNullException(nameof(VisitHistoryRepository));
        }

        public async Task<List<VisitHistory>> GetVisitHistories()
        {
            return await _VisitHistoryRepository.GetVisitHistories();
        }

        public async Task<VisitHistory> GetVisitHistoryById(int id)
        {
            return await _VisitHistoryRepository.GetVisitHistoryById(id);
        }

        public async Task<List<VisitHistory>> GetVisitHistoriesByPet(int id)
        {
            return await _VisitHistoryRepository.GetVisitHistoriesByPet(id);
        }


        public async Task AddVisitHistory(VisitHistory VisitHistory)
        {
            if (VisitHistory == null)
                throw new ArgumentNullException(nameof(VisitHistory));

            await _VisitHistoryRepository.AddVisitHistory(VisitHistory);
        }

        public async Task UpdateVisitHistory(VisitHistory VisitHistory)
        {
            if (VisitHistory == null)
                throw new ArgumentNullException(nameof(VisitHistory));

            await _VisitHistoryRepository.UpdateVisitHistory(VisitHistory);
        }

        public async Task DeleteVisitHistory(int id)
        {
            await _VisitHistoryRepository.DeleteVisitHistory(id);
        }
    }
}
