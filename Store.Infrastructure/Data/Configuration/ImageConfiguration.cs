using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.Infrastructure.Data.Configuration
{
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(32)
                .IsFixedLength()
                .IsRequired();

            builder
                .Property(x => x.Extension)
                .HasMaxLength(5)
                .IsRequired();

            builder
                .Ignore(x => x.Stream);

            builder
                .Ignore(x => x.IsNew);
        }
    }
}
