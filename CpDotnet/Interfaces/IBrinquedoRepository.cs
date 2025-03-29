using CpDotnet.Models;

namespace CpDotnet.Interfaces
{
    public interface IBrinquedoRepository
    {
        Task<IEnumerable<Brinquedo>> GetAllAsync();
        Task<Brinquedo> GetByIdAsync(int id);
        Task AddAsync(Brinquedo brinquedo);
        Task UpdateAsync(Brinquedo brinquedo);
        Task DeleteAsync(int id);
    }
}
