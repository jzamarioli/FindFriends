using System;

namespace FindFriends.Domain.Entities
{
    public class CalculateLog
    {
        public int Id { get; set; }
        public int SearchNumber { get; set; }
        public string BaseFriendName { get; set; }
        public string NearbyFriendName { get; set; }
        public int Rank{ get; set; }
        public DateTime Created { get; set; }
    }
}
