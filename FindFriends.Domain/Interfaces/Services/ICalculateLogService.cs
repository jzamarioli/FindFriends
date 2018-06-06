using FindFriends.Domain.Entities;

namespace FindFriends.Domain.Interfaces.Services
{
    public interface ICalculateLogService : IServiceBase<CalculateLog>
    {
        void SaveLog(CalculateLog log);
        int GetNextSearchNumber();
    }
}
