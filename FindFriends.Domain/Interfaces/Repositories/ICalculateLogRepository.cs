using FindFriends.Domain.Entities;

namespace FindFriends.Domain.Interfaces.Repositories
{
    public interface ICalculateLogRepository : IRepositoryBase<CalculateLog>
    {
        void SaveLog(CalculateLog log);
        int GetNextSearchNumber();
    }
}
