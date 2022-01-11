using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Entities;

namespace Store.Infrastructure.Data.Configuration
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.IsAdmin)
                .IsRequired();

            builder
                .Property(p => p.IsDeveloper)
                .IsRequired();

            builder
                .Property(p => p.IsModerator)
                .IsRequired();

            builder
                .Property(p => p.IsSupport)
                .IsRequired();
        }
    }
}
