using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FindFriends.Domain.Entities;

namespace FindFriends.Infra.Data.EntityConfig
{    
    public class CalculateLogConfiguration : IEntityTypeConfiguration<CalculateLog>
    {
        public void Configure(EntityTypeBuilder<CalculateLog> builder)
        {   
            builder.ToTable("CalculateLog");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.BaseFriendName)            
                .HasMaxLength(50);

            builder.Property(b => b.NearbyFriendName)
                .HasMaxLength(50);

            builder.Property(b => b.Created).
                HasColumnType("datetime2");

        }
    }
}
