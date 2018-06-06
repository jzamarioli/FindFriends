using FindFriends.Domain.Entities;
using System.Collections.Generic;

namespace FindFriends.Application.Interfaces
{
    public interface IFriendAppService: IAppServiceBase<Friend>
    {
        void Add_CheckingDuplicatesLatitudeLongitude(Friend friend);
        IEnumerable<Friend> GetNearbyFriends(string friendname);        
    }
}
