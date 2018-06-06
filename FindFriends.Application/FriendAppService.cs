using System.Collections.Generic;
using FindFriends.Domain.Entities;
using FindFriends.Domain.Interfaces.Services;
using FindFriends.Application.Interfaces;

namespace FindFriends.Application
{
    public class FriendAppService : AppServiceBase<Friend>, IFriendAppService
    {
        private readonly IFriendService _friendService;

        public FriendAppService(IFriendService friendService)
             : base(friendService)
        {
            _friendService = friendService;
        }

        public void Add_CheckingDuplicatesLatitudeLongitude(Friend friend)
        {
            _friendService.Add_CheckingDuplicatesLatitudeLongitude(friend);
        }

        public IEnumerable<Friend> GetNearbyFriends(string friendname)
        {
            return _friendService.GetNearbyFriends(friendname);
        }
    }
}
