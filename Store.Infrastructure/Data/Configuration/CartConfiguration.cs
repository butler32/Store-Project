using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infrastructure.Data.Configuration
{
    class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                .HasKey(p => new { p.UserId, p.GameId });

            builder
                .HasOne(m => m.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(m => m.UserId);

            builder
                .HasOne(m => m.Game)
                .WithMany(r => r.Carts)
                .HasForeignKey(m => m.GameId);
        }
    }
}
