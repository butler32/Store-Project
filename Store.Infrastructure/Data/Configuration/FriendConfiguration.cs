using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Infrastructure.Data.Configuration
{
    class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {

        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder
                .HasKey(fs => new { fs.FirstUserId, fs.SecondUserId, fs.Status });

            //builder
            //  .HasOne(fs => fs.FirstUser)
            //  .WithMany(u => u.UsersFriends)
            //  .HasForeignKey(fs => fs.FirstUserId);

            //builder
            //  .HasOne(fs => fs.SecondUser)
            //  .WithMany(u => u.UsersFriends)
            //  .HasForeignKey(fs => fs.SecondUserId);
        }
    }
}
