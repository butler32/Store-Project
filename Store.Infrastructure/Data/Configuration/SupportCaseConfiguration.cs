using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.Infrastructure.Data.Configuration
{
    class SupportCaseConfiguration : IEntityTypeConfiguration<SupportCase>
    {
        public void Configure(EntityTypeBuilder<SupportCase> builder)
        {
            builder
                .HasKey(sc => sc.Id);

            builder
                .HasOne(sc => sc.Initiator)
                .WithMany(u => u.InitiatedСases)
                .HasForeignKey(sc => sc.InitiatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sc => sc.Support)
                .WithMany(u => u.SupportedСases)
                .HasForeignKey(sc => sc.SupportId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}