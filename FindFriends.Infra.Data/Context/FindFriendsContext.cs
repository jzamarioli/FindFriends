using Microsoft.EntityFrameworkCore;
using FindFriends.Infra.Data.EntityConfig;
using FindFriends.Domain.Entities;

namespace FindFriends.Infra.Data.Context
{
    public class FindFriendsContext : DbContext
    {
        public FindFriendsContext(DbContextOptions<FindFriendsContext> options)
            :base (options)
        {                  
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<CalculateLog> CalculateLog { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FriendConfiguration());
        }
    }
 
}
