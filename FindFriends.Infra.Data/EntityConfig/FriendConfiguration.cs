using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindFriends.Domain.Entities;

namespace FindFriends.Infra.Data.EntityConfig
{    
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {   
            builder.ToTable("Friends");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.City)
                .HasMaxLength(40);

            builder.Property(b => b.Country)            
                .HasMaxLength(25);

            builder.Property(b => b.Latitude)
                .IsRequired();                

            builder.Property(b => b.Longitude)
                .IsRequired();

            builder.HasIndex(b => b.Name)
                .ForSqlServerIsClustered();
        }
    }
}
