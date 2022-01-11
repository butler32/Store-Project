using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.Infrastructure.Data.Configuration
{
    class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {

        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder
                .HasKey(fr => new { fr.RequestedById, fr.RequestedToId });

            builder
                .HasOne(fr => fr.RequestedBy)
                .WithMany(u => u.SentFriendRequests)
                .HasForeignKey(fr => fr.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fr => fr.RequestedBy)
                .WithMany(u => u.SentFriendRequests)
                .HasForeignKey(fr => fr.RequestedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
