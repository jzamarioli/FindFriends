using FindFriends.Domain.Entities;
using System.Collections.Generic;

namespace FindFriends.Domain.Interfaces.Services
{
    public interface IFriendService: IServiceBase<Friend>
    {
        void Add_CheckingDuplicatesLatitudeLongitude(Friend friend);
        IEnumerable<Friend> GetNearbyFriends(string friendname);
    }
}
