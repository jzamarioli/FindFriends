using FindFriends.Domain.Entities;
using FindFriends.Domain.Interfaces.Repositories;
using FindFriends.Domain.Interfaces.Services;

namespace FindFriends.Domain.Services
{
    public class CalculateLogService : ServiceBase<CalculateLog>, ICalculateLogService
    {
        private readonly ICalculateLogRepository _calculoHistoricoLogRepository;

        public CalculateLogService(ICalculateLogRepository calculoHistoricoLogRepository)
            : base(calculoHistoricoLogRepository)
        {
            _calculoHistoricoLogRepository = calculoHistoricoLogRepository;
        }

        public int GetNextSearchNumber()
        {
            return _calculoHistoricoLogRepository.GetNextSearchNumber();
        }

        public void SaveLog(CalculateLog log)
        {
            _calculoHistoricoLogRepository.SaveLog(log);
        }
    }
}
