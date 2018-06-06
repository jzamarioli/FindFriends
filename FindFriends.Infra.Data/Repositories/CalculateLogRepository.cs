using FindFriends.Infra.Data.Context;
using FindFriends.Domain.Entities;
using FindFriends.Domain.Interfaces.Repositories;
using System.Linq;

namespace FindFriends.Infra.Data.Repositories
{
    public class CalculateLogRepository : RepositoryBase<CalculateLog>, ICalculateLogRepository
    {
       public CalculateLogRepository(FindFriendsContext context)
        : base(context)
       { }

        public void SaveLog(CalculateLog log)
        {
            base.Add(log);
        }

        public int GetNextSearchNumber()
        {
            if (_ctx.CalculateLog.Count() == 0)
                return 1;
            else
                return _ctx.CalculateLog.Max(c => c.SearchNumber) + 1;            
        }
    }
}
