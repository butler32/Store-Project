using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infrastructure.Data.Configuration
{
    internal class LibriaryConfiguration : IEntityTypeConfiguration<Libriary>
    {
        public void Configure(EntityTypeBuilder<Libriary> builder)
        {
            builder
                .HasKey(p => new { p.UserId, p.GameId });

            builder
                .HasOne(m => m.User)
                .WithMany(u => u.Libriaries)
                .HasForeignKey(m => m.UserId);

            builder
                .HasOne(m => m.Game)
                .WithMany(r => r.Libriaries)
                .HasForeignKey(m => m.GameId);
        }
    }
}
