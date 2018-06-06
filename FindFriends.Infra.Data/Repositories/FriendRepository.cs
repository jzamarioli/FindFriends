using FindFriends.Infra.Data.Context;
using FindFriends.Domain.Entities;
using FindFriends.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace FindFriends.Infra.Data.Repositories
{
    public class FriendRepository : RepositoryBase<Friend>, IFriendRepository
    {
        public FriendRepository(FindFriendsContext context)
         : base(context)
        { }

        public void Add_CheckingDuplicatesLatitudeLongitude(Friend friend)
        {
            if (!_ctx.Friends.Any(f => f.Latitude == friend.Latitude && f.Longitude == friend.Longitude))
                base.Add(friend);
            else
                throw new Exception("Impossível adicionar.\nLatitude e longitude já existentes para outro amigo.");
        }

        public Friend FindByName(string name)
        {
            return _ctx.Friends.Where(f => f.Name == name).FirstOrDefault();
        }
    }
}
