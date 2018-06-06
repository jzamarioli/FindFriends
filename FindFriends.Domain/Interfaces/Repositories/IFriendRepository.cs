using FindFriends.Domain.Entities;

namespace FindFriends.Domain.Interfaces.Repositories
{
    public interface IFriendRepository: IRepositoryBase<Friend>
    {
        void Add_CheckingDuplicatesLatitudeLongitude(Friend friend);
        Friend FindByName(string name);
    }
}
