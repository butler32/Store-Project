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
    class SupportMessageConfiguration : IEntityTypeConfiguration<SupportMessage>
    {
        public void Configure(EntityTypeBuilder<SupportMessage> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Message)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(p => p.Time)
                .IsRequired();
        }
    }
}
