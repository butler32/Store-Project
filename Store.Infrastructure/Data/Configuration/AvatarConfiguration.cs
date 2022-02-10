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
    class AvatarConfiguration : IEntityTypeConfiguration<Avatar>
    {
        public void Configure(EntityTypeBuilder<Avatar> builder)
        {
            builder
                .HasKey(p => new { p.UserId, p.ImageId });

            builder
                .HasOne(m => m.User)
                .WithMany(u => u.Avatars)
                .HasForeignKey(m => m.UserId);

            builder
                .HasOne(m => m.Image)
                .WithMany(r => r.Avatars)
                .HasForeignKey(m => m.ImageId);
        }
    }
}
