using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Configuration
{
    class ScreenshotConfiguration : IEntityTypeConfiguration<Screenshot>
    {
        public void Configure(EntityTypeBuilder<Screenshot> builder)
        {
            builder
                .HasKey(p => new { p.GameId, p.ImageId });

            builder
                .HasOne(m => m.Game)
                .WithMany(u => u.Screenshots)
                .HasForeignKey(m => m.GameId);

            builder
                .HasOne(m => m.Image)
                .WithMany(r => r.Screenshots)
                .HasForeignKey(m => m.ImageId);
        }
    }
}
